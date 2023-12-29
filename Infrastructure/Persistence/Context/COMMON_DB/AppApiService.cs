using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.COMMON_DB;

public partial class AppApiService
{
    public int Id { get; set; }

    public int ApplicationId { get; set; }

    public string Name { get; set; } = null!;

    public string BaseUrl { get; set; } = null!;

    public string ApiMethod { get; set; } = null!;

    public string HttpVerb { get; set; } = null!;

    public string? ParameterFormat { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? CreatedBy { get; set; }

    public DateTime DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateTime? DateEdited { get; set; }

    public bool? Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DateDeleted { get; set; }

    public virtual Application Application { get; set; } = null!;
}
