using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.COMMON_DB;

public partial class BusinessUnitResource
{
    public Guid Id { get; set; }

    public int BusinessUnitId { get; set; }

    public int DivisionId { get; set; }

    public string BannerSmallFilename { get; set; } = null!;

    public byte[] BannerSmall { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateTime? DateEdited { get; set; }

    public bool Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DateDeleted { get; set; }

    public virtual BusinessUnit BusinessUnit { get; set; } = null!;

    public virtual Division Division { get; set; } = null!;
}
