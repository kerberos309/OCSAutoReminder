using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.OCS;

public partial class ClearanceAccountabilitiesEmail
{
    public int Id { get; set; }

    public int? AccId { get; set; }

    public int? BuId { get; set; }

    public string? Email { get; set; }

    public DateTime? DateCreated { get; set; }

    public string? CreatedBy { get; set; }
}
