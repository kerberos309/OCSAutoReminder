using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.EAMS
{
    public class UserProfileEntity
    {
        public int Id { get; set; }

        public Guid Code { get; set; }

        public string EmployeeNumber { get; set; } = null!;

        public bool NonAd { get; set; }

        public string? UserName { get; set; }

        public string FirstName { get; set; } = null!;

        public string? MiddleName { get; set; }

        public string LastName { get; set; } = null!;

        public int? Status { get; set; }

        public string AccessNumber { get; set; } = null!;

        public string? Signatory { get; set; }

        public Guid? ImmediateSupervisor { get; set; }

        public bool NonSwipe { get; set; }

        public bool? Active { get; set; }

        public int? CompanyId { get; set; }

        public int? DepartmentId { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime DateCreated { get; set; }

        public string? EditedBy { get; set; }

        public DateTime? DateEdited { get; set; }

        public bool Deleted { get; set; }

        public string? DeletedBy { get; set; }

        public DateTime? DateDeleted { get; set; }

        public int? BusinessUnitId { get; set; }

        public int? DivisionId { get; set; }

        public string? PersonnelAreaCode { get; set; }

        public string? OrganizationalUnitCode { get; set; }

        public string? JobLevelCode { get; set; }

        public string? LocationCode { get; set; }

        public string? PositionCode { get; set; }

        public int? Gender { get; set; }

        public DateTime? Birthday { get; set; }

        public DateTime? DateHired { get; set; }

        public DateTime? DateRegularized { get; set; }

        public string? SssNumber { get; set; }

        public string? PayrollAreaCode { get; set; }

        /// <summary>
        /// Cost Center
        /// </summary>
        public string? StoreCode { get; set; }

        public string? WorkScheduleRuleCode { get; set; }

        public bool? SharedService { get; set; }

        public string? LegalEntityCode { get; set; }

        public string? SapId { get; set; }

        public bool NonRrhi { get; set; }

        public DateTime? WsrFrom { get; set; }

        public DateTime? WsrTo { get; set; }

        public virtual ICollection<ApproverDelegationEntity> ApproverDelegationDelegatedEmployeeCodeNavigations { get; set; } = new List<ApproverDelegationEntity>();

        public virtual ICollection<ApproverDelegationEntity> ApproverDelegationEmployeeCodeNavigations { get; set; } = new List<ApproverDelegationEntity>();

        public virtual ICollection<AttendanceSummaryEntity> AttendanceSummaries { get; set; } = new List<AttendanceSummaryEntity>();

        public virtual ICollection<AttendanceSummaryStatusEntity> AttendanceSummaryStatusApproverCodeNavigations { get; set; } = new List<AttendanceSummaryStatusEntity>();

        public virtual ICollection<AttendanceSummaryStatusEntity> AttendanceSummaryStatusEmployeeCodeNavigations { get; set; } = new List<AttendanceSummaryStatusEntity>();

        public virtual ICollection<DtrRawEntity> DtrRaws { get; set; } = new List<DtrRawEntity>();

        public virtual ICollection<ExemptedEmployeeEntity> ExemptedEmployees { get; set; } = new List<ExemptedEmployeeEntity>();

        public virtual ICollection<TasApplicationEntity> TasApplications { get; set; } = new List<TasApplicationEntity>();

        public virtual ICollection<TasApprovalEntity> TasApprovals { get; set; } = new List<TasApprovalEntity>();

        public virtual ICollection<TasEmailNotificationEntity> TasEmailNotifications { get; set; } = new List<TasEmailNotificationEntity>();

        public virtual ICollection<TimekeeperEntity> Timekeepers { get; set; } = new List<TimekeeperEntity>();

        public virtual ICollection<UserDefaultScheduleEntity> UserDefaultSchedules { get; set; } = new List<UserDefaultScheduleEntity>();

        public virtual ICollection<UserDefineApproverEntity> UserDefineApproverApproverEmployeeCodeNavigations { get; set; } = new List<UserDefineApproverEntity>();

        public virtual ICollection<UserDefineApproverEntity> UserDefineApproverEmployeeCodeNavigations { get; set; } = new List<UserDefineApproverEntity>();

        public virtual ICollection<UserScheduleEntity> UserSchedules { get; set; } = new List<UserScheduleEntity>();
    }
}
