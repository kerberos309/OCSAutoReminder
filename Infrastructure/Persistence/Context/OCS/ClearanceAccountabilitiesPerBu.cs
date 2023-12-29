using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.OCS;

public partial class ClearanceAccountabilitiesPerBu
{
    public int Id { get; set; }

    public int ClearanceAccountabilitiesId { get; set; }

    public int BusinessUnitId { get; set; }

    public byte Deleted { get; set; }

    public DateTime DateCreated { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? DateEdited { get; set; }

    public string? EditedBy { get; set; }

    public DateTime? DateDeleted { get; set; }

    public string? DeletedBy { get; set; }

    public int? FormId { get; set; }

    public int? AccNo { get; set; }

    public virtual ClearanceAccountability ClearanceAccountabilities { get; set; } = null!;
}
