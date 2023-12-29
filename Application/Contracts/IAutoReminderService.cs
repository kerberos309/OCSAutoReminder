using Domain.Entities.COMMON_DB;
using Domain.Entities.EAMS;
using Domain.Entities.OCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IAutoReminderService
    {
        int GetAutoReminderDays();
        IEnumerable<string> GetEmployeeNumberOfActiveUserProfiles();
        IEnumerable<FilingEntity> FindFilings(Expression<Func<FilingEntity,bool>> expression);
        IEnumerable<ClearanceHeaderEntity> FindClearanceHeaders(Expression<Func<ClearanceHeaderEntity,bool>> expression);
        int UpdateFilingReminder(FilingEntity filingEntity);
        IEnumerable<ClearanceFormStatusEntity> FindClearanceFormStatuses(Expression<Func<ClearanceFormStatusEntity,bool>> expression);
        IEnumerable<Domain.Entities.COMMON_DB.UserProfileEntity> GetUserProfileByRoleId(int roleId);
        IEnumerable<Domain.Entities.COMMON_DB.UserProfileEntity> GetUserProfileByEmployeeNumber(string employeeNumber);
        IEnumerable<MatrixFormEntity> FindMatrixForms(Expression<Func<MatrixFormEntity,bool>> expression);
        int AddEmailNotifications(EmailNotificationEntity emailNotificationEntity);
        IEnumerable<Domain.Entities.EAMS.UserProfileEntity> GetEAMSUserProfileByEmployeeNumber(string employeeNumber);
        int UpdateClearanceFormStatusReminder(ClearanceFormStatusEntity clearanceFormStatusEntity);
        int AddDebuggerLogs(string fromAction, string fromClass, string message);
    }
}
