using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.OCS;

public partial class MatrixSetup
{
    public int Id { get; set; }

    public int MatrixId { get; set; }

    public int EntityId { get; set; }

    public int? FormId { get; set; }
}
