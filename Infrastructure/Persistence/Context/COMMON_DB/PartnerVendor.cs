using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.COMMON_DB;

public partial class PartnerVendor
{
    public int Id { get; set; }

    public int? BuId { get; set; }

    public int VendorId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateTime? DateEdited { get; set; }

    public bool Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DateDeleted { get; set; }

    public string? VendorDescription { get; set; }

    public virtual PartnerBu? Bu { get; set; }
}
