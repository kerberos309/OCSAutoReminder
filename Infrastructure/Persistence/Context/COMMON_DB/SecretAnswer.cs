using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.COMMON_DB;

public partial class SecretAnswer
{
    public int Id { get; set; }

    public int UserProfileId { get; set; }

    public int SecretQuestionId { get; set; }

    public string Answer { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateTime? DateEdited { get; set; }

    public virtual SecretQuestion SecretQuestion { get; set; } = null!;

    public virtual UserProfile UserProfile { get; set; } = null!;
}
