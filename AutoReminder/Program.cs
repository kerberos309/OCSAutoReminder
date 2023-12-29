using Application;
using Application.Contracts;
using Domain.Entities.OCS;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Configuration;

namespace Service
{
    internal class Program
    {
        private static readonly string _emailSender = ConfigurationManager.AppSettings["EmailSender"] ?? string.Empty;
        private static readonly string _buHREmail = ConfigurationManager.AppSettings["BUHREmail"] ?? string.Empty;
        private static readonly string _centralHREmail = ConfigurationManager.AppSettings["CentralHREmail"] ?? string.Empty;
        private static readonly int _ihpaempbenDayInterval = Convert.ToInt32(ConfigurationManager.AppSettings["IHPAEMPBENDayInterval"]);
        private static readonly int _aspenEmpbenRoleId = Convert.ToInt32(ConfigurationManager.AppSettings["EMPBENRoleId"]);
        private static readonly int _r7MaxReminderDay = Convert.ToInt32(ConfigurationManager.AppSettings["R7MaxReminderDay"]);
        private static readonly int _maxFormReminder = Convert.ToInt32(ConfigurationManager.AppSettings["MaxFormReminderDay"]);
        private static readonly int _aspenPA = Convert.ToInt32(ConfigurationManager.AppSettings["ASPENPARoleId"]);
        private static readonly int _paEP = Convert.ToInt32(ConfigurationManager.AppSettings["PAEPRoleId"]);
        private static readonly int _paNONEP = Convert.ToInt32(ConfigurationManager.AppSettings["PANONEPRoleId"]);
        private static readonly string _paEmpbenIHExternalEmail = ConfigurationManager.AppSettings["PAEMPBEIHExternalEmail"] ?? string.Empty;
        public Program()
        {
            if (string.IsNullOrEmpty(_emailSender)) { throw new ArgumentNullException(); }
            if (string.IsNullOrEmpty(_buHREmail)) { throw new ArgumentNullException(); }
            if (string.IsNullOrEmpty(_centralHREmail)) { throw new ArgumentNullException(); }
            if (string.IsNullOrEmpty(_paEmpbenIHExternalEmail)) { throw new ArgumentNullException(); }
            if (_ihpaempbenDayInterval == 0) { throw new ArgumentNullException(); }
            if (_aspenEmpbenRoleId == 0) { throw new ArgumentNullException(); }
            if (_r7MaxReminderDay == 0) { throw new ArgumentNullException(); }
            if (_maxFormReminder == 0) { throw new ArgumentNullException(); }
            if (_aspenPA == 0) { throw new ArgumentNullException(); }
            if (_paEP == 0) { throw new ArgumentNullException(); }
            if (_paNONEP == 0) { throw new ArgumentNullException(); }
        }
        static void Main(string[] args)
        {
            IHost host = CreateHost();
            var _service = host.Services.GetRequiredService<IAutoReminderService>();
            _service.AddDebuggerLogs(nameof(Program),nameof(Main),"AUTO REMINDER STARTS...");
            #region EMPBEN
            _service.AddDebuggerLogs("EMPBEN", nameof(Main), "EMPBEN REMINDER START...");
            var empbenFilings = _service.FindFilings(x => x.Status == "I" && x.IsDraft == false).ToList();
            var empbenUserProfiles = _service.GetUserProfileByRoleId(_aspenEmpbenRoleId);
            foreach (var filing in empbenFilings)
            {
                _service.AddDebuggerLogs("EMPBEN", nameof(Main), $"CHECKING TRACKING #: {filing.TrackingNumber}");
                var clearanceHeader = _service.FindClearanceHeaders(x => x.ClearanceStatus == "I" && x.TrackingNumber == filing.TrackingNumber && x.EmployeeNumber == filing.EmployeeNumber).FirstOrDefault() ?? new ClearanceHeaderEntity();
                if (clearanceHeader.DateReceived.HasValue && clearanceHeader.DateReceived.Value.AddDays(_ihpaempbenDayInterval).Date <= DateTime.Now.Date)
                {
                    string additionalEmails = string.Empty;
                    if (filing.Empbenreminder == null)
                    {
                        filing.Empbenreminder = 1;
                    }
                    else
                    {
                        filing.Empbenreminder += 1;
                    }
                    FilingEntity updatedFilingEntity = filing;
                    if (_service.UpdateFilingReminder(updatedFilingEntity) > 0)
                    {
                        if (filing.Empbenreminder == 2)
                        {
                            additionalEmails = string.Concat(_paEmpbenIHExternalEmail, ";", _buHREmail);
                        }
                        if (filing.Empbenreminder >= 3)
                        {
                            additionalEmails = string.Concat(_paEmpbenIHExternalEmail, ";", _buHREmail, ";", _centralHREmail);
                        }

                        string userProfileFullName = _service.GetUserProfileByEmployeeNumber(filing.EmployeeNumber ?? string.Empty)
                            .Select(x => string.Concat(x.FirstName, ",", x.LastName))
                            .FirstOrDefault() ?? string.Empty;

                        string displayReminder = string.Empty;
                        switch (filing.Empbenreminder)
                        {
                            case 1:
                                displayReminder = " - First Reminder";
                                break;
                            case 2:
                                displayReminder = " - Second Reminder";
                                break;
                            case 3:
                                displayReminder = " - Third Reminder";
                                break;
                            case > 3:
                                displayReminder = " - Final Reminder";
                                break;
                            default:
                                break;
                        }
                        int empbenReminderDay = _maxFormReminder - filing.Empbenreminder ?? 0;
                        string remainingDaysText = empbenReminderDay > 1 ?
                            $"You have {empbenReminderDay} day/s to process this request" :
                            $"This is your final reminder to process. You have 24 hours to approve";
                        Dictionary<string, string> emailData = new Dictionary<string, string>()
                        {
                            { "{TrackingNumber}",filing.TrackingNumber??string.Empty},
                            { "{EffectiveDate}",filing.DateSeparation.HasValue ? filing.DateSeparation.Value.ToString("MM/dd/yyyy"):string.Empty},
                            { "{DateSubmitted}",filing.DateCreated.HasValue?filing.DateCreated.Value.ToString("MM/dd/yyyy"):string.Empty},
                            { "{EmployeeFirstName}",userProfileFullName.Split(',')[0]},
                            { "{EmployeeLastName}",userProfileFullName.Split(',')[1]},
                            { "{RemainingDays}", remainingDaysText}
                        };
                        EmailNotificationEntity emailNotificationEntity = new EmailNotificationEntity()
                        {
                            DateCreated = DateTime.Now,
                            EmailData = JsonConvert.SerializeObject(emailData),
                            EmailFrom = _emailSender,
                            EmailTemplate = "AutoReminderForEMPBEN2ndAnd3rdLevelTemplate",
                            EmailSubject = $"Approved Resignation of {userProfileFullName.Replace(",", " ")} For Clearance Releasing - {filing.TrackingNumber} (OCS){displayReminder}"
                        };
                        empbenUserProfiles.ToList().ForEach(empben =>
                        {
                            emailNotificationEntity.EmailTo = string.IsNullOrEmpty(additionalEmails) ?
                                empben.UserEmails.Select(x => x.EmailAddress).FirstOrDefault() :
                                string.Concat(empben.UserEmails.Select(x => x.EmailAddress).FirstOrDefault(), ";", additionalEmails);
                            _service.AddDebuggerLogs("EMPBEN", nameof(Main), $"SENDING EMAIL FOR TRACKING #:{filing.TrackingNumber}");
                            _service.AddEmailNotifications(emailNotificationEntity);
                        });
                    }
                }
            }
            #endregion
            #region IMMEDIATEHEAD
            _service.AddDebuggerLogs("IMMEDIATEHEAD", nameof(Main), "IMMEDIATE HEAD REMINDER STARTS...");
            var ihFilings = _service.FindFilings(x => x.Status == "S" && x.IsDraft == false)
                .ToList();

            foreach (var filing in ihFilings)
            {
                _service.AddDebuggerLogs("IMMEDIATEHEAD", nameof(Main), $"CHECKING TRACKING #: {filing.TrackingNumber}");
                if (filing.DateCreated.HasValue && filing.DateCreated.Value.AddDays(_ihpaempbenDayInterval).Date <= DateTime.Now.Date)
                {
                    string userProfileFullName = _service.GetUserProfileByEmployeeNumber(filing.EmployeeNumber ?? string.Empty)
                        .Select(x => string.Concat(x.FirstName, ",", x.LastName))
                        .FirstOrDefault() ?? string.Empty;

                    string displayReminder = string.Empty;

                    var signatoryEAMSUserProfile = _service.GetEAMSUserProfileByEmployeeNumber(filing.EmployeeNumber ?? string.Empty).FirstOrDefault() ?? new Domain.Entities.EAMS.UserProfileEntity();
                    var signatory2ndLvlEAMSUserProfile = _service.GetEAMSUserProfileByEmployeeNumber(signatoryEAMSUserProfile.EmployeeNumber ?? string.Empty).FirstOrDefault() ?? new Domain.Entities.EAMS.UserProfileEntity();

                    string signatoryEAMSUserProfileEmail = _service.GetUserProfileByEmployeeNumber(signatoryEAMSUserProfile?.EmployeeNumber ?? string.Empty)
                        .SelectMany(x => x.UserEmails)
                        .FirstOrDefault()?
                        .EmailAddress ?? string.Empty;
                    string signatory2ndLvlEAMSUserProfileEmail = _service.GetUserProfileByEmployeeNumber(signatory2ndLvlEAMSUserProfile?.EmployeeNumber ?? string.Empty)
                        .SelectMany(x => x.UserEmails)
                        .FirstOrDefault()?
                        .EmailAddress ?? string.Empty;

                    string additionalEmails = string.Empty;
                    if (filing.Ihreminder == null)
                    {
                        filing.Ihreminder = 1;
                    }
                    else
                    {
                        filing.Ihreminder += 1;
                    }
                    FilingEntity updatedFilingEntity = filing;
                    if (_service.UpdateFilingReminder(updatedFilingEntity) != 0)
                    {
                        if (filing.Ihreminder == 1)
                        {
                            displayReminder = " - First Reminder";
                        }
                        if (filing.Ihreminder == 2 && !string.IsNullOrEmpty(signatory2ndLvlEAMSUserProfileEmail))
                        {
                            displayReminder = " - Second Reminder";
                            additionalEmails = string.Concat(signatory2ndLvlEAMSUserProfileEmail, ";", _buHREmail);
                        }
                        if (filing.Ihreminder == 3 && !string.IsNullOrEmpty(signatory2ndLvlEAMSUserProfileEmail))
                        {
                            displayReminder = " - Third Reminder";
                            additionalEmails = string.Concat(signatory2ndLvlEAMSUserProfileEmail, ";", _buHREmail, ";", _centralHREmail);
                        }
                        if (filing.Ihreminder > 3 && !string.IsNullOrEmpty(signatory2ndLvlEAMSUserProfileEmail))
                        {
                            displayReminder = " - Final Reminder";
                            additionalEmails = string.Concat(signatory2ndLvlEAMSUserProfileEmail, ";", _buHREmail, ";", _centralHREmail);
                        }
                    }
                    int ihReminder = filing.Ihreminder ?? 0;
                    int ihReminderDay = _maxFormReminder - ihReminder;
                    string remainingDaysText = ihReminderDay > 1 ?
                        $"You have {ihReminderDay} day/s to process this request" :
                        "This is your final reminder to process. You have 24 hours to approve.";

                    Dictionary<string, string> emailData = new Dictionary<string, string>()
                    {
                        { "{TrackingNumber}",filing.TrackingNumber??string.Empty},
                        { "{EffectiveDate}",filing.DateSeparation.HasValue ? filing.DateSeparation.Value.ToString("MM/dd/yyyy"):string.Empty},
                        { "{DateSubmitted}",filing.DateCreated.HasValue?filing.DateCreated.Value.ToString("MM/dd/yyyy"):string.Empty},
                        { "{EmployeeFirstName}",userProfileFullName.Split(',')[0]},
                        { "{EmployeeLastName}",userProfileFullName.Split(',')[1]},
                        { "{RemainingDays}", remainingDaysText}
                    };
                    EmailNotificationEntity emailNotificationEntity = new EmailNotificationEntity()
                    {
                        DateCreated = DateTime.Now,
                        EmailData = JsonConvert.SerializeObject(emailData),
                        EmailFrom = _emailSender,
                        EmailTemplate = "ApprovalNotification",
                        EmailSubject = $"Resignation Approval of {userProfileFullName.Replace(",", " ")} - {filing.TrackingNumber} (OCS){displayReminder}"
                    };

                    if (!string.IsNullOrEmpty(additionalEmails))
                    {
                        emailNotificationEntity.EmailTo = string.Concat(signatoryEAMSUserProfileEmail, ";", additionalEmails);
                    }
                    else
                    {
                        emailNotificationEntity.EmailTo = signatoryEAMSUserProfileEmail;
                    }
                    _service.AddDebuggerLogs("IMMEDIATEHEAD", nameof(Main), $"SENDING EMAIL FOR TRACKING #:{filing.TrackingNumber}");
                    _service.AddEmailNotifications(emailNotificationEntity);
                }
            }
            #endregion
            #region PA
            _service.AddDebuggerLogs("PA", nameof(Main), "PA REMINDER STARTS...");
            var paFilings = _service.FindFilings(x => x.Status == "A" && x.IsDraft == false)
                .ToList();
            var aspenPAUserProfiles = _service.GetUserProfileByRoleId(_aspenPA);
            var paEPUserProfiles = _service.GetUserProfileByRoleId(_paEP);
            var paNonEPUserProfiles = _service.GetUserProfileByRoleId(_paNONEP);

            foreach (var filing in paFilings)
            {
                _service.AddDebuggerLogs("PA", nameof(Main), $"CHECKING TRACKING #: {filing.TrackingNumber}");

                if (filing.DateApproved.HasValue && filing.DateApproved.Value.AddDays(_ihpaempbenDayInterval).Date <= DateTime.Now.Date)
                {
                    string additionalEmails = string.Empty;
                    if (filing.Pareminder == null)
                    {
                        filing.Pareminder = 1;
                    }
                    else
                    {
                        filing.Pareminder += 1;
                    }
                    FilingEntity updatedFilingEntity = filing;
                    if (_service.UpdateFilingReminder(updatedFilingEntity) > 0)
                    {
                        if (filing.Pareminder == 2)
                        {
                            additionalEmails = string.Concat(_buHREmail, ";", _paEmpbenIHExternalEmail);
                        }
                        if (filing.Pareminder >= 3)
                        {
                            additionalEmails = string.Concat(_buHREmail, ";", _paEmpbenIHExternalEmail, ";", _centralHREmail);
                        }

                        string userProfileFullName = _service.GetUserProfileByEmployeeNumber(filing.EmployeeNumber ?? string.Empty)
                            .Select(x => string.Concat(x.FirstName, ",", x.LastName))
                            .FirstOrDefault() ?? string.Empty;

                        string userProfileRole = _service.GetUserProfileByEmployeeNumber(filing.EmployeeNumber ?? string.Empty)
                            .Select(x => x.PayrollAreaCode)
                            .FirstOrDefault() ?? string.Empty;

                        string displayReminder = string.Empty;

                        switch (filing.Pareminder)
                        {
                            case 1:
                                displayReminder = " - First Reminder";
                                break;
                            case 2:
                                displayReminder = " - Second Reminder";
                                break;
                            case 3:
                                displayReminder = " - Third Reminder";
                                break;
                            case > 3:
                                displayReminder = " - Final Reminder";
                                break;
                            default:
                                break;
                        }
                        int paReminderDay = _maxFormReminder - filing.Pareminder ?? 0;
                        string remainingDaysText = paReminderDay > 1 ?
                            $"You have {paReminderDay} day/s to process this request" :
                            $"This is your final reminder to process. You have 24 hours to approve.";
                        Dictionary<string, string> emailData = new Dictionary<string, string>()
                        {
                            { "{TrackingNumber}",filing.TrackingNumber??string.Empty},
                            { "{EffectiveDate}",filing.DateSeparation.HasValue ? filing.DateSeparation.Value.ToString("MM/dd/yyyy"):string.Empty},
                            { "{DateSubmitted}",filing.DateCreated.HasValue?filing.DateCreated.Value.ToString("MM/dd/yyyy"):string.Empty},
                            { "{EmployeeFirstName}",userProfileFullName.Split(',')[0]},
                            { "{EmployeeLastName}",userProfileFullName.Split(',')[1]},
                            { "{RemainingDays}", remainingDaysText}
                        };
                        EmailNotificationEntity emailNotificationEntity = new EmailNotificationEntity()
                        {
                            DateCreated = DateTime.Now,
                            EmailData = JsonConvert.SerializeObject(emailData),
                            EmailFrom = _emailSender,
                            EmailTemplate = "AutoReminderForPA2ndAnd3rdLevelTemplate",
                            EmailSubject = $"Resignation Approval of {userProfileFullName.Replace(",", " ")} - {filing.TrackingNumber} (OCS){displayReminder}"
                        };
                        string processorsEmail = string.Empty;
                        //for ASPEN PA
                        aspenPAUserProfiles.ToList().ForEach(aspenpa =>
                        {
                            processorsEmail = aspenpa.UserEmails.Select(x => x.EmailAddress).FirstOrDefault() ?? string.Empty;
                            emailNotificationEntity.EmailTo = string.IsNullOrEmpty(additionalEmails) ?
                                processorsEmail :
                                string.Concat(processorsEmail, ";", additionalEmails);
                            _service.AddDebuggerLogs("PA", nameof(Main), $"SENDING EMAIL FOR TRACKING #:{filing.TrackingNumber}");
                            _service.AddEmailNotifications(emailNotificationEntity);
                        });

                        if (userProfileRole == "EP")
                        {
                            //for PA-EP
                            paEPUserProfiles.ToList().ForEach(paep =>
                            {
                                processorsEmail = paep.UserEmails.Select(x => x.EmailAddress).FirstOrDefault() ?? string.Empty;
                                emailNotificationEntity.EmailTo = string.IsNullOrEmpty(additionalEmails) ?
                                    processorsEmail :
                                    string.Concat(processorsEmail, ";", additionalEmails);
                                _service.AddDebuggerLogs("PA", nameof(Main), $"SENDING EMAIL FOR TRACKING #:{filing.TrackingNumber}");
                                _service.AddEmailNotifications(emailNotificationEntity);
                            });
                        }
                        else
                        {
                            //for PA-NONEP
                            paNonEPUserProfiles.ToList().ForEach(panonep =>
                            {
                                processorsEmail = panonep.UserEmails.Select(x => x.EmailAddress).FirstOrDefault() ?? string.Empty;
                                emailNotificationEntity.EmailTo = string.IsNullOrEmpty(additionalEmails) ?
                                    processorsEmail :
                                    string.Concat(processorsEmail, ";", additionalEmails);
                                _service.AddDebuggerLogs("PA", nameof(Main), $"SENDING EMAIL FOR TRACKING #:{filing.TrackingNumber}");
                                _service.AddEmailNotifications(emailNotificationEntity);
                            });
                        }

                    }

                }
            }
            #endregion
            #region FORMS
            _service.AddDebuggerLogs("FORMS", nameof(Main), "FORMS REMINDER STARTS...");
            int day = _service.GetAutoReminderDays();

            var empbenEmailAddresses = _service.GetUserProfileByRoleId(_aspenEmpbenRoleId);
            string empbenEmailAddressesWithSeparator = string.Empty;
            empbenEmailAddresses.ToList().ForEach(e =>
            {
                empbenEmailAddressesWithSeparator = string.IsNullOrEmpty(empbenEmailAddressesWithSeparator) ?
                    e.UserEmails.Select(x => x.EmailAddress ?? string.Empty).FirstOrDefault() ?? string.Empty :
                    string.Concat(empbenEmailAddressesWithSeparator, ";", e.UserEmails.Select(x => x.EmailAddress).FirstOrDefault() ?? string.Empty);
            });
            var formFilings = _service.FindFilings(x => x.Status == "F" && x.IsDraft == false)
                .ToList();

            foreach (var filing in formFilings)
            {
                _service.AddDebuggerLogs("FORMS", nameof(Main), $"CHECKING TRACKING #: {filing.TrackingNumber}");

                string userProfileFullName = _service.GetUserProfileByEmployeeNumber(filing.EmployeeNumber ?? string.Empty)
                    .Select(x => string.Concat(x.FirstName, ",", x.LastName))
                    .FirstOrDefault() ?? string.Empty;

                var clearanceHeader = _service.FindClearanceHeaders(x => x.TrackingNumber == filing.TrackingNumber).ToList();
                if (clearanceHeader.Any())
                {
                    string additionalEmails = string.Empty;
                    if (filing.FormReminder == null)
                    {
                        filing.FormReminder = 1;
                    }
                    else
                    {
                        filing.FormReminder += 1;
                    }
                    FilingEntity updatedFilingEntity = filing;
                    if (_service.UpdateFilingReminder(updatedFilingEntity) != 0)
                    {
                        if (filing.FormReminder == 2)
                        {
                            additionalEmails = _buHREmail;
                        }

                        if (filing.FormReminder >= 3)
                        {
                            additionalEmails = _centralHREmail;
                        }
                    }
                    var clearanceFormStatuses = _service.FindClearanceFormStatuses(x => x.EmployeeNumber == filing.EmployeeNumber && x.TrackingNumber == filing.TrackingNumber && x.FormStatus == "F").ToList();
                    foreach (var clearanceFormStatus in clearanceFormStatuses)
                    {
                        if (clearanceHeader.FirstOrDefault()?.DateCreated?.AddDays(day).Date <= DateTime.Now
                            && clearanceFormStatus.FormStatus == "F")
                        {
                            string matrixFormName = _service.FindMatrixForms(x => x.FormId == clearanceFormStatus.FormId)
                                .Select(x => x.Title)
                                .FirstOrDefault() ?? string.Empty;
                            string displayReminder = string.Empty;
                            int r7FormReminder = 0;
                            int r7FormReminderDay = 0;
                            int formReminderDay = _maxFormReminder - filing.FormReminder ?? 0;
                            if (matrixFormName == "R7")
                            {
                                //forwarded
                                if (!string.IsNullOrEmpty(clearanceFormStatus.ForwardTo))
                                {
                                    //put reminder to clearance form status
                                    if (clearanceFormStatus.Reminder == null)
                                    {
                                        clearanceFormStatus.Reminder = 1;
                                    }
                                    else
                                    {
                                        clearanceFormStatus.Reminder += 1;
                                    }
                                    ClearanceFormStatusEntity updatedClearanceFormStatus = clearanceFormStatus;
                                    _service.UpdateClearanceFormStatusReminder(updatedClearanceFormStatus);
                                    switch (clearanceFormStatus.Reminder)
                                    {
                                        case 1:
                                            displayReminder = " - First Reminder";
                                            break;
                                        case 2:
                                            displayReminder = " - Second Reminder";
                                            break;
                                        case >= 3:
                                            displayReminder = " - Final Reminder";
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                //not yet forwarded
                                else
                                {
                                    if (filing.R7reminder == null)
                                    {
                                        filing.R7reminder = 1;
                                    }
                                    else
                                    {
                                        filing.R7reminder += 1;
                                    }

                                    FilingEntity filingEntityForR7Reminder = filing;
                                    _service.UpdateFilingReminder(filingEntityForR7Reminder);

                                    switch (filing.R7reminder)
                                    {
                                        case 1:
                                            displayReminder = " - First Reminder";
                                            break;
                                        case 2:
                                            displayReminder = " - Second Reminder";
                                            break;
                                        case >= 3:
                                            displayReminder = " - Final Reminder";
                                            break;
                                        default:
                                            break;
                                    }
                                }

                                r7FormReminder = clearanceFormStatus.Reminder == 0 ?
                                        filing.R7reminder ?? 0 :
                                        clearanceFormStatus.Reminder ?? 0;
                                r7FormReminderDay = clearanceFormStatus.Reminder == 0 ?
                                    _r7MaxReminderDay - r7FormReminderDay :
                                    _r7MaxReminderDay - clearanceFormStatus.Reminder ?? 0;
                            }
                            else
                            {
                                switch (filing.FormReminder)
                                {
                                    case 1:
                                        displayReminder = " - First Reminder";
                                        break;
                                    case 2:
                                        displayReminder = " - Second Reminder";
                                        break;
                                    case 3:
                                        displayReminder = " - Third Reminder";
                                        break;
                                    case > 3:
                                        displayReminder = " - Final Reminder";
                                        break;
                                    default:
                                        break;
                                }
                            }

                            string deptVal = clearanceFormStatus.DepartmentValue ?? string.Empty;
                            string remainingDaysText = r7FormReminderDay == 0 ?
                                                        formReminderDay > 1 ?
                                                            $"You have {formReminderDay} day/s to process this request" : "This is your final reminder to process. You have 24 hours to approve." :
                                                        r7FormReminderDay > 1 ?
                                                            $"You have {r7FormReminderDay} day/s to process this request" : "This is your final reminder to process. You have 24 hours to approve.";
                            Dictionary<string, string> emailData = new Dictionary<string, string>()
                            {
                                { "{TrackingNumber}",filing.TrackingNumber??string.Empty},
                                { "{EffectiveDate}",filing.DateSeparation.HasValue ? filing.DateSeparation.Value.ToString("MM/dd/yyyy"):string.Empty},
                                { "{DateSubmitted}",filing.DateCreated.HasValue?filing.DateCreated.Value.ToString("MM/dd/yyyy"):string.Empty},
                                { "{EmployeeFirstName}",userProfileFullName.Split(',')[0]},
                                { "{EmployeeLastName}",userProfileFullName.Split(',')[1]},
                                { "{RemainingDays}",remainingDaysText}
                            };
                            EmailNotificationEntity emailNotificationEntity = new EmailNotificationEntity()
                            {
                                DateCreated = DateTime.Now,
                                EmailData = JsonConvert.SerializeObject(emailData),
                                EmailFrom = _emailSender,
                                EmailTemplate = "AutoReminderTemplate",
                                EmailSubject = $"Form({matrixFormName}) Approval of {userProfileFullName.Replace(",", " ")} - {filing.TrackingNumber} (OCS){displayReminder}"
                            };
                            if (deptVal.Contains(','))
                            {
                                foreach (var singleDeptVal in deptVal.Split(','))
                                {
                                    if (!clearanceFormStatus.EnableForward)
                                    {
                                        //not fowardable
                                        _service.GetUserProfileByRoleId(Convert.ToInt32(singleDeptVal)).ToList().ForEach(p =>
                                        {
                                            emailData.Remove("{ApproverName}");
                                            emailData.Add("{ApproverName}", p.FirstName);
                                            if (!string.IsNullOrEmpty(additionalEmails))
                                            {
                                                emailNotificationEntity.EmailTo = string.Concat(p.UserEmails.FirstOrDefault()?.EmailAddress, ";", additionalEmails);
                                            }
                                            else
                                            {
                                                emailNotificationEntity.EmailTo = p.UserEmails.FirstOrDefault()?.EmailAddress;
                                            }
                                            _service.AddDebuggerLogs("FORMS", nameof(Main), $"SENDING EMAIL FOR TRACKING #:{filing.TrackingNumber}");
                                            _service.AddEmailNotifications(emailNotificationEntity);
                                        });
                                    }
                                    else
                                    {
                                        //forwardable
                                        if (!string.IsNullOrEmpty(clearanceFormStatus.ForwardTo))
                                        {
                                            //already forwarded
                                            _service.GetUserProfileByRoleId(Convert.ToInt32(clearanceFormStatus.ForwardTo)).ToList().ForEach(p =>
                                            {
                                                emailData.Remove("{ApproverName}");
                                                emailData.Add("{ApproverName}", p.FirstName);
                                                if (!string.IsNullOrEmpty(additionalEmails))
                                                {
                                                    emailNotificationEntity.EmailTo = string.Concat(p.UserEmails.FirstOrDefault()?.EmailAddress, ";", additionalEmails);
                                                }
                                                else
                                                {
                                                    emailNotificationEntity.EmailTo = p.UserEmails.FirstOrDefault()?.EmailAddress;
                                                }
                                                _service.AddDebuggerLogs("FORMS", nameof(Main), $"SENDING EMAIL FOR TRACKING #:{filing.TrackingNumber}");
                                                _service.AddEmailNotifications(emailNotificationEntity);
                                            });
                                        }
                                        else
                                        {
                                            //not yet forwarded
                                            _service.GetUserProfileByRoleId(Convert.ToInt32(singleDeptVal)).ToList().ForEach(p =>
                                            {
                                                emailData.Remove("{ApproverName}");
                                                emailData.Add("{ApproverName}", p.FirstName);
                                                if (!string.IsNullOrEmpty(additionalEmails))
                                                {
                                                    emailNotificationEntity.EmailTo = string.Concat(p.UserEmails.FirstOrDefault()?.EmailAddress, ";", additionalEmails);
                                                }
                                                else
                                                {
                                                    emailNotificationEntity.EmailTo = p.UserEmails.FirstOrDefault()?.EmailAddress;
                                                }
                                                _service.AddDebuggerLogs("FORMS", nameof(Main), $"SENDING EMAIL FOR TRACKING #:{filing.TrackingNumber}");
                                                _service.AddEmailNotifications(emailNotificationEntity);
                                            });
                                        }

                                    }

                                }
                            }
                            else
                            {
                                if (deptVal.Length == 8)
                                {
                                    //R1
                                    _service.GetUserProfileByEmployeeNumber(deptVal).ToList().ForEach(ih =>
                                    {
                                        emailData.Remove("{ApproverName}");
                                        emailData.Add("{ApproverName}", ih.FirstName);

                                        if (!string.IsNullOrEmpty(additionalEmails))
                                        {
                                            emailNotificationEntity.EmailTo = string.Concat(ih.UserEmails.FirstOrDefault()?.EmailAddress, ";", additionalEmails);
                                        }
                                        else
                                        {
                                            emailNotificationEntity.EmailTo = ih.UserEmails.FirstOrDefault()?.EmailAddress;
                                        }
                                        _service.AddDebuggerLogs("FORMS", nameof(Main), $"SENDING EMAIL FOR TRACKING #:{filing.TrackingNumber}");
                                        _service.AddEmailNotifications(emailNotificationEntity);
                                    });
                                }
                                else
                                {
                                    //R2A-R10
                                    if (!clearanceFormStatus.EnableForward)
                                    {
                                        //not forwardable
                                        _service.GetUserProfileByRoleId(Convert.ToInt32(deptVal)).ToList().ForEach(p =>
                                        {
                                            emailData.Remove("{ApproverName}");
                                            emailData.Add("{ApproverName}", p.FirstName);
                                            if (!string.IsNullOrEmpty(additionalEmails))
                                            {
                                                emailNotificationEntity.EmailTo = string.Concat(p.UserEmails.FirstOrDefault()?.EmailAddress, ";", additionalEmails);
                                            }
                                            else
                                            {
                                                emailNotificationEntity.EmailTo = p.UserEmails.FirstOrDefault()?.EmailAddress;
                                            }
                                            _service.AddDebuggerLogs("FORMS", nameof(Main), $"SENDING EMAIL FOR TRACKING #:{filing.TrackingNumber}");
                                            _service.AddEmailNotifications(emailNotificationEntity);
                                        });
                                    }
                                    else
                                    {
                                        //forwardable
                                        if (!string.IsNullOrEmpty(clearanceFormStatus.ForwardTo))
                                        {
                                            //already forwarded
                                            _service.GetUserProfileByRoleId(Convert.ToInt32(clearanceFormStatus.ForwardTo)).ToList().ForEach(p =>
                                            {
                                                emailData.Remove("{ApproverName}");
                                                emailData.Add("{ApproverName}", p.FirstName);
                                                if (!string.IsNullOrEmpty(additionalEmails))
                                                {
                                                    emailNotificationEntity.EmailTo = string.Concat(p.UserEmails.FirstOrDefault()?.EmailAddress, ";", additionalEmails);
                                                }
                                                else
                                                {
                                                    emailNotificationEntity.EmailTo = p.UserEmails.FirstOrDefault()?.EmailAddress;
                                                }
                                                _service.AddDebuggerLogs("FORMS", nameof(Main), $"SENDING EMAIL FOR TRACKING #:{filing.TrackingNumber}");
                                                _service.AddEmailNotifications(emailNotificationEntity);
                                            });
                                        }
                                        else
                                        {
                                            //not yet forwarded
                                            _service.GetUserProfileByRoleId(Convert.ToInt32(deptVal)).ToList().ForEach(p =>
                                            {
                                                emailData.Remove("{ApproverName}");
                                                emailData.Add("{ApproverName}", p.FirstName);
                                                if (!string.IsNullOrEmpty(additionalEmails))
                                                {
                                                    emailNotificationEntity.EmailTo = string.Concat(p.UserEmails.FirstOrDefault()?.EmailAddress, ";", additionalEmails);
                                                }
                                                else
                                                {
                                                    emailNotificationEntity.EmailTo = p.UserEmails.FirstOrDefault()?.EmailAddress;
                                                }
                                                _service.AddDebuggerLogs("FORMS", nameof(Main), $"SENDING EMAIL FOR TRACKING #:{filing.TrackingNumber}");
                                                _service.AddEmailNotifications(emailNotificationEntity);
                                            });
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
            }
            #endregion
            _service.AddDebuggerLogs(nameof(Program), nameof(Main), "AUTO REMINDER ENDS...");

        }
        private static IHost CreateHost() => Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) => 
            {
                services.AddApplication();
                services.AddInfrastructure();
            })
            .Build();
    }
}