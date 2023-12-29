using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.OCS;

public partial class MatrixForm
{
    public int FormId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public int? FormVersion { get; set; }

    public DateTime? DateCreated { get; set; }

    public string? CreatedBy { get; set; }
}
