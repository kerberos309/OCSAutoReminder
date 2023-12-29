using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.COMMON_DB;

public partial class UserProfile
{
    public int Id { get; set; }

    public string EmployeeNumber { get; set; } = null!;

    public bool NonAd { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public int? Status { get; set; }

    public string AccessNumber { get; set; } = null!;

    public string? Signatory { get; set; }

    public int? CompanyId { get; set; }

    public int? DepartmentId { get; set; }

    public string SapId { get; set; } = null!;

    public bool NonSwipe { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateTime? DateEdited { get; set; }

    public bool Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DateDeleted { get; set; }

    public bool? Active { get; set; }

    public string? RegistrationStatus { get; set; }

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

    public string? StoreCode { get; set; }

    public string? WorkScheduleRuleCode { get; set; }

    public bool? SharedService { get; set; }

    public string? LegalEntityCode { get; set; }

    public bool NonRrhi { get; set; }

    public DateTime? WsrFrom { get; set; }

    public DateTime? WsrTo { get; set; }

    public virtual ICollection<AppUser> AppUsers { get; set; } = new List<AppUser>();

    public virtual ICollection<ApplicationAccessRequest> ApplicationAccessRequests { get; set; } = new List<ApplicationAccessRequest>();

    public virtual ICollection<AuthenticationToken> AuthenticationTokens { get; set; } = new List<AuthenticationToken>();

    public virtual BusinessUnit? BusinessUnit { get; set; }

    public virtual ICollection<BusinessUnitAdminAccess> BusinessUnitAdminAccesses { get; set; } = new List<BusinessUnitAdminAccess>();

    public virtual Company? Company { get; set; }

    public virtual Department? Department { get; set; }

    public virtual Division? Division { get; set; }

    public virtual JobLevel? JobLevelCodeNavigation { get; set; }

    public virtual LegalEntity? LegalEntityCodeNavigation { get; set; }

    public virtual Location? LocationCodeNavigation { get; set; }

    public virtual OrganizationalUnit? OrganizationalUnitCodeNavigation { get; set; }

    public virtual Position? PositionCodeNavigation { get; set; }

    public virtual ICollection<SecretAnswer> SecretAnswers { get; set; } = new List<SecretAnswer>();

    public virtual ICollection<UserCoverage> UserCoverages { get; set; } = new List<UserCoverage>();

    public virtual ICollection<UserEmail> UserEmails { get; set; } = new List<UserEmail>();

    public virtual ICollection<UserNotification> UserNotifications { get; set; } = new List<UserNotification>();

    public virtual ICollection<UserProfilePicture> UserProfilePictures { get; set; } = new List<UserProfilePicture>();
}
