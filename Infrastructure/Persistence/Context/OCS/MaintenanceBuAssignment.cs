using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.OCS;

public partial class MaintenanceBuAssignment
{
    public int Id { get; set; }

    public int RoleId { get; set; }

    public bool Deleted { get; set; }

    public DateTime DateCreated { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? DeletedBy { get; set; }

    public DateTime? DateDeleted { get; set; }
}
