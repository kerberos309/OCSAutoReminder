using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.COMMON_DB;

public partial class AppVersion
{
    public int Id { get; set; }

    public string Version { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<AppVersionHeader> AppVersionHeaders { get; set; } = new List<AppVersionHeader>();
}
