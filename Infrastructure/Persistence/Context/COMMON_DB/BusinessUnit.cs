using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.COMMON_DB;

public partial class BusinessUnit
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string ShortName { get; set; } = null!;

    public string JdaLibrary { get; set; } = null!;

    public string JdaIpAddress { get; set; } = null!;

    public string JdaLinkedServerCatalog { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateTime? DateEdited { get; set; }

    public bool Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DateDeleted { get; set; }

    public string? SapProfitCenter { get; set; }

    public string? SapTitle { get; set; }

    public string? SapBucode { get; set; }

    public string? JdaCloneDb { get; set; }

    public string? JdaCloneDbDev { get; set; }

    public string? RbeeDb { get; set; }

    public string? JdaCloneDbName { get; set; }

    public string? RbeeDbName { get; set; }

    public int VoucherLimits { get; set; }

    public virtual ICollection<BusinessStore> BusinessStores { get; set; } = new List<BusinessStore>();

    public virtual ICollection<BusinessUnitResource> BusinessUnitResources { get; set; } = new List<BusinessUnitResource>();

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();

    public virtual ICollection<Division> Divisions { get; set; } = new List<Division>();

    public virtual ICollection<NonRrhiCompany> NonRrhiCompanies { get; set; } = new List<NonRrhiCompany>();

    public virtual ICollection<PartnerBu> PartnerBus { get; set; } = new List<PartnerBu>();

    public virtual ICollection<UserCoverage> UserCoverages { get; set; } = new List<UserCoverage>();

    public virtual ICollection<UserProfile> UserProfiles { get; set; } = new List<UserProfile>();
}
