namespace Domain.Entities.COMMON_DB
{
    public class UserProfileEntity
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

        public virtual ICollection<AppUserEntity> AppUsers { get; set; } = new List<AppUserEntity>();

        public virtual ICollection<ApplicationAccessRequestEntity> ApplicationAccessRequests { get; set; } = new List<ApplicationAccessRequestEntity>();

        public virtual ICollection<AuthenticationTokenEntity> AuthenticationTokens { get; set; } = new List<AuthenticationTokenEntity>();

        public virtual BusinessUnitEntity? BusinessUnit { get; set; }

        public virtual ICollection<BusinessUnitAdminAccessEntity> BusinessUnitAdminAccesses { get; set; } = new List<BusinessUnitAdminAccessEntity>();

        public virtual CompanyEntity? Company { get; set; }

        public virtual DepartmentEntity? Department { get; set; }

        public virtual DivisionEntity? Division { get; set; }

        public virtual JobLevelEntity? JobLevelCodeNavigation { get; set; }

        public virtual LegalEntityEntity? LegalEntityCodeNavigation { get; set; }

        public virtual LocationEntity? LocationCodeNavigation { get; set; }

        public virtual OrganizationalUnitEntity? OrganizationalUnitCodeNavigation { get; set; }

        public virtual PositionEntity? PositionCodeNavigation { get; set; }

        public virtual ICollection<SecretAnswerEntity> SecretAnswers { get; set; } = new List<SecretAnswerEntity>();

        public virtual ICollection<UserCoverageEntity> UserCoverages { get; set; } = new List<UserCoverageEntity>();

        public virtual ICollection<UserEmailEntity> UserEmails { get; set; } = new List<UserEmailEntity>();

        public virtual ICollection<UserNotificationEntity> UserNotifications { get; set; } = new List<UserNotificationEntity>();

        public virtual ICollection<UserProfilePictureEntity> UserProfilePictures { get; set; } = new List<UserProfilePictureEntity>();
    }
}