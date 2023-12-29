using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.OCS;

public partial class MatrixEmployeeAccess
{
    public int Id { get; set; }

    public string? EmployeeNumber { get; set; }

    public int? MatrixId { get; set; }

    public int? EntityId { get; set; }

    public int? FormId { get; set; }
}
