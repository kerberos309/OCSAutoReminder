using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.OCS;

public partial class DebuggerLog
{
    public int Id { get; set; }

    public string Message { get; set; } = null!;

    public string FromClass { get; set; } = null!;

    public string FromAction { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public bool Deleted { get; set; }
}
