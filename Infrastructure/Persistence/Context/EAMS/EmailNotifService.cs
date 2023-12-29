using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.EAMS;

public partial class EmailNotifService
{
    public int Id { get; set; }

    public TimeOnly Time { get; set; }

    public bool OnOff { get; set; }

    public int SendBefore { get; set; }
}
