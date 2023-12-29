using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.COMMON_DB;

public partial class CategoryHome
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? ImageUrl { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateTime? DateEdited { get; set; }

    public bool? Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DateDeleted { get; set; }

    public int Priority { get; set; }

    public string? Description { get; set; }

    public bool ForcedDisplay { get; set; }

    public string? AltText { get; set; }
}
