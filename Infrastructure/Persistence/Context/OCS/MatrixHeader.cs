using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.OCS;

public partial class MatrixHeader
{
    public int MatrixId { get; set; }

    public Guid PkId { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    public DateTime? EffectivityFrom { get; set; }

    public DateTime? EffectivityTo { get; set; }

    public int? FormVersion { get; set; }

    public DateTime? DateCreated { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastEditedDate { get; set; }

    public string? LastEditedBy { get; set; }

    public DateTime? ActivationDate { get; set; }

    public int? IsActive { get; set; }

    public int? Deleted { get; set; }
}
