using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.OCS;

public partial class MatrixFormApproval
{
    public int ApprovalId { get; set; }

    public int FormId { get; set; }

    public int ApprovalLevel { get; set; }

    public string DepartmentValue { get; set; } = null!;

    public int? MatrixId { get; set; }

    public int? InOrder { get; set; }
}
