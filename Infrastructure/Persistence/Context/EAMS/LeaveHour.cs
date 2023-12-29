using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.EAMS;

public partial class LeaveHour
{
    public int Id { get; set; }

    public string StoreCode { get; set; } = null!;

    public string LegalEntityCode { get; set; } = null!;

    public double HalfDayHours { get; set; }

    public double WholeDayHours { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateOnly DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateOnly? DateEdited { get; set; }

    public bool Deleted { get; set; }

    public DateTime? DateDeleted { get; set; }

    public string? DeletedBy { get; set; }
}
