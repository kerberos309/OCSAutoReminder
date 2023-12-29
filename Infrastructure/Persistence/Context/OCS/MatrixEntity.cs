using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.OCS;

public partial class MatrixEntity
{
    public int EntityId { get; set; }

    public string? EntityName { get; set; }

    public string? EntityCategory { get; set; }

    public int? EntityConfig { get; set; }

    public string? EntityDesc { get; set; }
}
