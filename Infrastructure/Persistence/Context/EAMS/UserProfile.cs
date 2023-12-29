using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.EAMS;

public partial class UserProfile
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

    public virtual ICollection<ApproverDelegation> ApproverDelegationDelegatedEmployeeCodeNavigations { get; set; } = new List<ApproverDelegation>();

    public virtual ICollection<ApproverDelegation> ApproverDelegationEmployeeCodeNavigations { get; set; } = new List<ApproverDelegation>();

    public virtual ICollection<AttendanceSummary> AttendanceSummaries { get; set; } = new List<AttendanceSummary>();

    public virtual ICollection<AttendanceSummaryStatus> AttendanceSummaryStatusApproverCodeNavigations { get; set; } = new List<AttendanceSummaryStatus>();

    public virtual ICollection<AttendanceSummaryStatus> AttendanceSummaryStatusEmployeeCodeNavigations { get; set; } = new List<AttendanceSummaryStatus>();

    public virtual ICollection<DtrRaw> DtrRaws { get; set; } = new List<DtrRaw>();

    public virtual ICollection<ExemptedEmployee> ExemptedEmployees { get; set; } = new List<ExemptedEmployee>();

    public virtual ICollection<TasApplication> TasApplications { get; set; } = new List<TasApplication>();

    public virtual ICollection<TasApproval> TasApprovals { get; set; } = new List<TasApproval>();

    public virtual ICollection<TasEmailNotification> TasEmailNotifications { get; set; } = new List<TasEmailNotification>();

    public virtual ICollection<Timekeeper> Timekeepers { get; set; } = new List<Timekeeper>();

    public virtual ICollection<UserDefaultSchedule> UserDefaultSchedules { get; set; } = new List<UserDefaultSchedule>();

    public virtual ICollection<UserDefineApprover> UserDefineApproverApproverEmployeeCodeNavigations { get; set; } = new List<UserDefineApprover>();

    public virtual ICollection<UserDefineApprover> UserDefineApproverEmployeeCodeNavigations { get; set; } = new List<UserDefineApprover>();

    public virtual ICollection<UserSchedule> UserSchedules { get; set; } = new List<UserSchedule>();
}
