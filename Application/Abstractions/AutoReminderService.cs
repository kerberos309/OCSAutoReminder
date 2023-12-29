using Application.Contracts;
using Domain.Entities.COMMON_DB;
using Domain.Entities.OCS;
using Domain.RepositoryInterface.COMMON_DB;
using Domain.RepositoryInterface.OCS;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public class AutoReminderService : IAutoReminderService
    {
        private readonly IMatrixAccessRepository _matrixAccessRepository;
        private readonly IMatrixEntityRepository _matrixEntityRepository;
        private readonly IMatrixFormRepository _matrixFormRepository;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IClearanceHeaderRepository _clearanceHeaderRepository;
        private readonly IFilingRepository _filingRepository;
        private readonly IClearanceFormStatusRepository _clearanceFormStatusRepository;
        private readonly IUserEmailRepository _userEmailRepository;
        private readonly IUserCoverageRepository _userCoverageRepository;
        private readonly IEmailNotificationRepository _emailNotificationRepository;
        private readonly Domain.RepositoryInterface.EAMS.IUserProfileRepository _eamsUserProfileRepository;
        private readonly Domain.RepositoryInterface.EAMS.IUserDefineApproverRepository _userDefineApproverRepository;
        private readonly ISystemLogsRepository _systemLogsRepository;
        private readonly IDebuggerLogsRepository _debuggerLogsRepository;
        public AutoReminderService(IMatrixEntityRepository matrixEntityRepository,
            IMatrixFormRepository matrixFormRepository,
            IMatrixAccessRepository matrixAccessRepository,
            IUserProfileRepository userProfileRepository,
            IClearanceHeaderRepository clearanceHeaderRepository,
            IFilingRepository filingRepository,
            IClearanceFormStatusRepository clearanceFormStatusRepository,
            IUserEmailRepository userEmailRepository,
            IUserCoverageRepository userCoverageRepository,
            IEmailNotificationRepository emailNotificationRepository,
            Domain.RepositoryInterface.EAMS.IUserProfileRepository eamsUserProfileRepository,
            Domain.RepositoryInterface.EAMS.IUserDefineApproverRepository userDefineApproverRepository,
            ISystemLogsRepository systemLogsRepository,
            IDebuggerLogsRepository debuggerLogsRepository
            )
        {
            _matrixEntityRepository = matrixEntityRepository;
            _matrixFormRepository = matrixFormRepository;
            _matrixAccessRepository = matrixAccessRepository;
            _userProfileRepository = userProfileRepository;
            _clearanceHeaderRepository = clearanceHeaderRepository;
            _filingRepository = filingRepository;
            _clearanceFormStatusRepository = clearanceFormStatusRepository;
            _userEmailRepository = userEmailRepository;
            _userCoverageRepository = userCoverageRepository;
            _emailNotificationRepository = emailNotificationRepository;
            _eamsUserProfileRepository = eamsUserProfileRepository;
            _userDefineApproverRepository = userDefineApproverRepository;
            _systemLogsRepository = systemLogsRepository;
            _debuggerLogsRepository = debuggerLogsRepository;
        }

        public IEnumerable<ClearanceFormStatusEntity> FindClearanceFormStatuses(Expression<Func<ClearanceFormStatusEntity, bool>> expression)
        {
            try
            {
                return _clearanceFormStatusRepository.FindClearanceFormStatus(expression);
            }
            catch (Exception ex)
            {
                _systemLogsRepository.AddSystemLogs(new SystemLogsEntity 
                {
                    DateCreated = DateTime.Now,
                    InnerException = ex.InnerException?.Message,
                    Message = ex.Message,
                    LoggedUsername = nameof(AutoReminderService),
                    Method = nameof(FindClearanceFormStatuses),
                    StackTrace = ex.StackTrace,
                    Type = "error"
                });
                throw;
            }
        }

        public IEnumerable<ClearanceHeaderEntity> FindClearanceHeaders(Expression<Func<ClearanceHeaderEntity, bool>> expression)
        {
            try
            {
                return _clearanceHeaderRepository.FindClearanceHeader(expression);
            }
            catch (Exception ex)
            {
                _systemLogsRepository.AddSystemLogs(new SystemLogsEntity
                {
                    DateCreated = DateTime.Now,
                    InnerException = ex.InnerException?.Message,
                    Message = ex.Message,
                    LoggedUsername = nameof(AutoReminderService),
                    Method = nameof(FindClearanceHeaders),
                    StackTrace = ex.StackTrace,
                    Type = "error"
                });
                throw;
            }
            
        }

        public IEnumerable<FilingEntity> FindFilings(Expression<Func<FilingEntity, bool>> expression)
        {
            try
            {
                return _filingRepository.FindFiling(expression);
            }
            catch (Exception ex)
            {
                _systemLogsRepository.AddSystemLogs(new SystemLogsEntity
                {
                    DateCreated = DateTime.Now,
                    InnerException = ex.InnerException?.Message,
                    Message = ex.Message,
                    LoggedUsername = nameof(AutoReminderService),
                    Method = nameof(FindFilings),
                    StackTrace = ex.StackTrace,
                    Type = "error"
                });
                throw;
            }
            
        }

        public IEnumerable<string> GetEmployeeNumberOfActiveUserProfiles()
        {
            try
            {
                return _userProfileRepository.FindUserProfile(x => x.Deleted == false && x.Active == true).Select(x => x.EmployeeNumber);
            }
            catch (Exception ex)
            {
                _systemLogsRepository.AddSystemLogs(new SystemLogsEntity
                {
                    DateCreated = DateTime.Now,
                    InnerException = ex.InnerException?.Message,
                    Message = ex.Message,
                    LoggedUsername = nameof(AutoReminderService),
                    Method = nameof(GetEmployeeNumberOfActiveUserProfiles),
                    StackTrace = ex.StackTrace,
                    Type = "error"
                });
                throw;
            }
        }

        public int GetAutoReminderDays()
        {
            try
            {
                string matrix = _matrixAccessRepository.GetAutoReminderDay(9, 1);

                int day = 0;
                if (!string.IsNullOrEmpty(matrix))
                {
                    if (int.TryParse(matrix, out int res))
                    {
                        day = res;
                    }
                }
                return day;
            }
            catch (Exception ex)
            {
                _systemLogsRepository.AddSystemLogs(new SystemLogsEntity
                {
                    DateCreated = DateTime.Now,
                    InnerException = ex.InnerException?.Message,
                    Message = ex.Message,
                    LoggedUsername = nameof(AutoReminderService),
                    Method = nameof(GetAutoReminderDays),
                    StackTrace = ex.StackTrace,
                    Type = "error"
                });
                throw;
            }
            

        }

        public IEnumerable<UserProfileEntity> GetUserProfileByEmployeeNumber(string employeeNumber)
        {
            try
            {
                var userProfiles = _userProfileRepository.FindUserProfile(x => x.EmployeeNumber == employeeNumber && x.Active == true && x.Deleted == false).ToList();
                userProfiles.ForEach(x =>
                {
                    x.UserEmails = _userEmailRepository.FindUserEmail(y => y.UserProfileId == x.Id && y.Primary == true && y.Deleted == false).ToList();
                });
                return userProfiles;
            }
            catch (Exception ex)
            {
                _systemLogsRepository.AddSystemLogs(new SystemLogsEntity
                {
                    DateCreated = DateTime.Now,
                    InnerException = ex.InnerException?.Message,
                    Message = ex.Message,
                    LoggedUsername = nameof(AutoReminderService),
                    Method = nameof(GetUserProfileByEmployeeNumber),
                    StackTrace = ex.StackTrace,
                    Type = "error"
                });
                throw;
            }
            
        }

        public IEnumerable<UserProfileEntity> GetUserProfileByRoleId(int roleId)
        {
            try
            {
                var userProfiles = _userProfileRepository.FindUserProfile(x => x.Active == true && x.Deleted == false)
                .Join(_userCoverageRepository.FindUserCoverage(x => x.RoleId == roleId && x.Deleted == false), up => up.Id, uc => uc.UserProfileId, (up, uc) => new { up, uc })
                .Select(x => x.up)
                .ToList();
                userProfiles.ForEach(x =>
                {
                    x.UserEmails = _userEmailRepository.FindUserEmail(y => y.UserProfileId == x.Id && y.Primary == true && y.Deleted == false).ToList();
                });
                return userProfiles;
            }
            catch (Exception ex)
            {
                _systemLogsRepository.AddSystemLogs(new SystemLogsEntity
                {
                    DateCreated = DateTime.Now,
                    InnerException = ex.InnerException?.Message,
                    Message = ex.Message,
                    LoggedUsername = nameof(AutoReminderService),
                    Method = nameof(GetUserProfileByRoleId),
                    StackTrace = ex.StackTrace,
                    Type = "error"
                });
                throw;
            }
            
        }

        public int UpdateFilingReminder(FilingEntity filingEntity)
        {
            try
            {
                return _filingRepository.UpdateFiling(filingEntity);
            }
            catch (Exception ex)
            {
                _systemLogsRepository.AddSystemLogs(new SystemLogsEntity
                {
                    DateCreated = DateTime.Now,
                    InnerException = ex.InnerException?.Message,
                    Message = ex.Message,
                    LoggedUsername = nameof(AutoReminderService),
                    Method = nameof(UpdateFilingReminder),
                    StackTrace = ex.StackTrace,
                    Type = "error"
                });
                throw;
            }
        }

        public IEnumerable<MatrixFormEntity> FindMatrixForms(Expression<Func<MatrixFormEntity, bool>> expression)
        {
            try
            {
                return _matrixFormRepository.FindMatrixForm(expression);
            }
            catch (Exception ex)
            {
                _systemLogsRepository.AddSystemLogs(new SystemLogsEntity
                {
                    DateCreated = DateTime.Now,
                    InnerException = ex.InnerException?.Message,
                    Message = ex.Message,
                    LoggedUsername = nameof(AutoReminderService),
                    Method = nameof(FindMatrixForms),
                    StackTrace = ex.StackTrace,
                    Type = "error"
                });
                throw;
            }
        }

        public int AddEmailNotifications(EmailNotificationEntity emailNotificationEntity)
        {
            try
            {
                return _emailNotificationRepository.AddEmailNotification(emailNotificationEntity);
            }
            catch (Exception ex) 
            { 
                _systemLogsRepository.AddSystemLogs(new SystemLogsEntity 
                { 
                    DateCreated = DateTime.Now, 
                    InnerException = ex.InnerException?.Message, 
                    Message = ex.Message, 
                    LoggedUsername = nameof(AutoReminderService), 
                    Method = nameof(AddEmailNotifications), 
                    StackTrace = ex.StackTrace, Type = "error" 
                }); 
                throw; 
            }
        }

        public IEnumerable<Domain.Entities.EAMS.UserProfileEntity> GetEAMSUserProfileByEmployeeNumber(string employeeNumber)
        {
            try
            {
                var eamsUserProfile = _eamsUserProfileRepository.FindUserProfile(x => x.EmployeeNumber == employeeNumber && x.Active == true && x.Deleted == false).FirstOrDefault() ?? new Domain.Entities.EAMS.UserProfileEntity();
                var userDefineApprover = _userDefineApproverRepository.FindUserDefineApprover(x => x.EmployeeCode == eamsUserProfile.Code && x.Active == true && x.Status == "Active").FirstOrDefault() ?? new Domain.Entities.EAMS.UserDefineApproverEntity();
                if (userDefineApprover.Id != 0)
                {
                    return _eamsUserProfileRepository.FindUserProfile(x => x.Code == userDefineApprover.ApproverEmployeeCode && x.Active == true && x.Deleted == false);
                }
                else
                {
                    return _eamsUserProfileRepository.FindUserProfile(x => x.EmployeeNumber == eamsUserProfile.Signatory && x.Code == eamsUserProfile.ImmediateSupervisor && x.Active == true && x.Deleted == false);
                }
            }
            catch (Exception ex)
            {
                _systemLogsRepository.AddSystemLogs(new SystemLogsEntity
                {
                    DateCreated = DateTime.Now,
                    InnerException = ex.InnerException?.Message,
                    Message = ex.Message,
                    LoggedUsername = nameof(AutoReminderService),
                    Method = nameof(GetEAMSUserProfileByEmployeeNumber),
                    StackTrace = ex.StackTrace,
                    Type = "error"
                });
                throw;
            }
        }

        public int UpdateClearanceFormStatusReminder(ClearanceFormStatusEntity clearanceFormStatusEntity)
        {
            try
            {
                return _clearanceFormStatusRepository.UpdateClearanceFormStatus(clearanceFormStatusEntity);
            }
            catch (Exception ex) 
            { 
                _systemLogsRepository.AddSystemLogs(new SystemLogsEntity 
                { DateCreated = DateTime.Now, 
                    InnerException = ex.InnerException?.Message, 
                    Message = ex.Message, 
                    LoggedUsername = nameof(AutoReminderService), 
                    Method = nameof(UpdateClearanceFormStatusReminder), 
                    StackTrace = ex.StackTrace, Type = "error" 
                }); 
                throw; 
            }
        }

        public int AddDebuggerLogs(string fromAction,string fromClass,string message)
        {
            try
            {
                DebuggerLogsEntity newData = new DebuggerLogsEntity()
                {
                    DateCreated = DateTime.Now,
                    FromAction = fromAction,
                    FromClass = fromClass,
                    Message = message,
                };
                return _debuggerLogsRepository.AddDebuggerLogs(newData);
            }
            catch (Exception ex)
            {
                _systemLogsRepository.AddSystemLogs(new SystemLogsEntity
                {
                    DateCreated = DateTime.Now,
                    InnerException = ex.InnerException?.Message,
                    Message = ex.Message,
                    LoggedUsername = nameof(AutoReminderService),
                    Method = nameof(AddDebuggerLogs),
                    StackTrace = ex.StackTrace,
                    Type = "error"
                });
                throw;
            }
        }
    }
}
