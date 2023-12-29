using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.OCS;

public partial class MaintenanceDelegation
{
    public int Id { get; set; }

    public int RoleId { get; set; }

    public string DelegatedTo { get; set; } = null!;

    public string DelegatedBy { get; set; } = null!;

    public DateTime DateDelegated { get; set; }

    public DateTime DelegatedUntil { get; set; }

    public bool Active { get; set; }

    public int? BuId { get; set; }

    public bool? Deleted { get; set; }
}
