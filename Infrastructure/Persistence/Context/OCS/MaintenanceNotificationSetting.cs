using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.OCS;

public partial class MaintenanceNotificationSetting
{
    public int Id { get; set; }

    public string StatusName { get; set; } = null!;

    public int? Recipient { get; set; }

    public DateTime? DateCreated { get; set; }

    public string? CreatedBy { get; set; }

    public int? Deleted { get; set; }

    public string? DeletedBy { get; set; }
}
