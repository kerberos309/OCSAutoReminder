using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.COMMON_DB;

public partial class Application
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

    public virtual ICollection<AppApiService> AppApiServices { get; set; } = new List<AppApiService>();

    public virtual ICollection<AppUser> AppUsers { get; set; } = new List<AppUser>();

    public virtual ICollection<AppVersionHeader> AppVersionHeaders { get; set; } = new List<AppVersionHeader>();

    public virtual ICollection<ApplicationAccessRequest> ApplicationAccessRequests { get; set; } = new List<ApplicationAccessRequest>();

    public virtual ICollection<BusinessUnitAdminAccess> BusinessUnitAdminAccesses { get; set; } = new List<BusinessUnitAdminAccess>();

    public virtual ICollection<Module> Modules { get; set; } = new List<Module>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();

    public virtual ICollection<UserCoverage> UserCoverages { get; set; } = new List<UserCoverage>();

    public virtual ICollection<UserNotification> UserNotifications { get; set; } = new List<UserNotification>();
}
