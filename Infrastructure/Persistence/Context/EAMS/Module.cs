using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.EAMS;

public partial class Module
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Url { get; set; }

    public string? Action { get; set; }

    public string? Controller { get; set; }

    public string? Icon { get; set; }

    public string? Description { get; set; }

    public string? Title { get; set; }

    public string? Subtitle { get; set; }

    public int? SortOrder { get; set; }

    public string? GroupName { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateTime? DateEdited { get; set; }

    public bool Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DateDeleted { get; set; }

    public string? EamsAppCode { get; set; }
}
