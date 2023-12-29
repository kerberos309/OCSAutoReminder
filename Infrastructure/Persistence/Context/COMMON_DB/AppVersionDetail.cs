using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.COMMON_DB;

public partial class AppVersionDetail
{
    public int Id { get; set; }

    public int HeaderId { get; set; }

    public string Description { get; set; } = null!;

    public virtual AppVersionHeader Header { get; set; } = null!;
}
