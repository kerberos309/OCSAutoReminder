using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.EAMS;

public partial class TasType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? ShortName { get; set; }

    public string? Description { get; set; }

    public bool Active { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateTime? DateEdited { get; set; }

    public bool Deleted { get; set; }

    public DateTime? DateDeleted { get; set; }

    public string? Code { get; set; }

    public string? InfoType { get; set; }

    public string? SubType { get; set; }

    public virtual ICollection<TasApplication> TasApplications { get; set; } = new List<TasApplication>();

    public virtual ICollection<TasApprovalRule> TasApprovalRules { get; set; } = new List<TasApprovalRule>();
}
