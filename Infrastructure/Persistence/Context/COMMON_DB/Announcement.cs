using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.COMMON_DB;

public partial class Announcement
{
    public int Id { get; set; }

    public string ImagePath { get; set; } = null!;

    public DateTime DateFrom { get; set; }

    public DateTime DateTo { get; set; }

    public DateTime DateCreated { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? DateEdited { get; set; }

    public string? EditedBy { get; set; }

    public bool Active { get; set; }

    public DateTime? DateDeleted { get; set; }

    public string? DeletedBy { get; set; }
}
