using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.COMMON_DB;

public partial class Ad
{
    public int Id { get; set; }

    public int Position { get; set; }

    public string Url { get; set; } = null!;

    public string CreatedBuCode { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? EditedBuCode { get; set; }

    public DateTime? DateEdited { get; set; }

    public string? EditedBy { get; set; }

    public string? DeletedBuCode { get; set; }

    public bool Deleted { get; set; }

    public string? DeletedBy { get; set; }
}
