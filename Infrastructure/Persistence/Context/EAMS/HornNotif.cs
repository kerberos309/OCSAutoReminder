using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.EAMS;

public partial class HornNotif
{
    public int Id { get; set; }

    public string? NotifMsg { get; set; }

    public bool? FifteenthDay { get; set; }

    public bool? LastDay { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateTime? DateEdited { get; set; }

    public bool? Deleted { get; set; }

    public DateTime? DateDeleted { get; set; }

    public string? DeletedBy { get; set; }

    public string? NotifTitle { get; set; }

    public virtual ICollection<HornNotifViewed> HornNotifVieweds { get; set; } = new List<HornNotifViewed>();
}
