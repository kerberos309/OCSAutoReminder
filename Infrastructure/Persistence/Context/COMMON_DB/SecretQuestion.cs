using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.COMMON_DB;

public partial class SecretQuestion
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Question { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateTime? DateEdited { get; set; }

    public bool? Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DateDeleted { get; set; }

    public virtual ICollection<SecretAnswer> SecretAnswers { get; set; } = new List<SecretAnswer>();
}
