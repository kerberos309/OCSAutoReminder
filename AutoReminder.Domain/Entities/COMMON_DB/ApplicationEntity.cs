using System.Data;
using System.Reflection;

namespace Domain.Entities.COMMON_DB
{
    public class ApplicationEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string CreatedBy { get; set; } = null!;

        public DateTime DateCreated { get; set; }

        public string? EditedBy { get; set; }

        public DateTime? DateEdited { get; set; }

        public bool Deleted { get; set; }

        public string? DeletedBy { get; set; }

        public DateTime? DateDeleted { get; set; }

        public string? Url { get; set; }

        public string? DbConnectionString { get; set; }

        public bool? AutoRegister { get; set; }

        public int? ApiServiceId { get; set; }

        public int? DefaultRoleId { get; set; }

        public bool? CentralIsdApp { get; set; }

        public byte[]? Image { get; set; }

        public string? DevUrl { get; set; }

        public string? DevDbConn { get; set; }

        public virtual ICollection<AppApiServiceEntity> AppApiServices { get; set; } = new List<AppApiServiceEntity>();

        public virtual ICollection<AppUserEntity> AppUsers { get; set; } = new List<AppUserEntity>();

        public virtual ICollection<AppVersionHeaderEntity> AppVersionHeaders { get; set; } = new List<AppVersionHeaderEntity>();

        public virtual ICollection<ApplicationAccessRequestEntity> ApplicationAccessRequests { get; set; } = new List<ApplicationAccessRequestEntity>();

        public virtual ICollection<BusinessUnitAdminAccessEntity> BusinessUnitAdminAccesses { get; set; } = new List<BusinessUnitAdminAccessEntity>();

        public virtual ICollection<ModuleEntity> Modules { get; set; } = new List<ModuleEntity>();
        public virtual ICollection<RoleEntity> Roles { get; set; } = new List<RoleEntity>();

        public virtual ICollection<UserCoverageEntity> UserCoverages { get; set; } = new List<UserCoverageEntity>();

        public virtual ICollection<UserNotificationEntity> UserNotifications { get; set; } = new List<UserNotificationEntity>();
    }
}