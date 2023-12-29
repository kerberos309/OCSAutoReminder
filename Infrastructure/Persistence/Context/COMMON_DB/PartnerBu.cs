using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.COMMON_DB;

public partial class PartnerBu
{
    public int Id { get; set; }

    public string PartnerEmployeeNumber { get; set; } = null!;

    public int BuId { get; set; }

    public bool? Status { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateTime? DateEdited { get; set; }

    public bool Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DateDeleted { get; set; }

    public virtual BusinessUnit Bu { get; set; } = null!;

    public virtual NonRrhiPartner PartnerEmployeeNumberNavigation { get; set; } = null!;

    public virtual ICollection<PartnerVendor> PartnerVendors { get; set; } = new List<PartnerVendor>();
}
