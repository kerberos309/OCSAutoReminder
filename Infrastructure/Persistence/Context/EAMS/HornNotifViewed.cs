using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.EAMS;

public partial class HornNotifViewed
{
    public int Id { get; set; }

    public int HornNotifId { get; set; }

    public Guid? EmployeeCode { get; set; }

    public DateTime? DateViewed { get; set; }

    public DateOnly? CutoffDate { get; set; }

    public virtual HornNotif HornNotif { get; set; } = null!;
}
