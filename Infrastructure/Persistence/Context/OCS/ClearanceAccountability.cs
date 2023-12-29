using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.OCS;

public partial class ClearanceAccountability
{
    public int Id { get; set; }

    public int? AccNo { get; set; }

    public string? AccName { get; set; }

    public int? FormId { get; set; }

    public DateTime? DateCreated { get; set; }

    public string? CreatedBy { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<ClearanceAccountabilitiesPerBu> ClearanceAccountabilitiesPerBus { get; set; } = new List<ClearanceAccountabilitiesPerBu>();
}
