using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.COMMON_DB;

public partial class Store
{
    public int Id { get; set; }

    public int BusinessUnitId { get; set; }

    public string CompanyCode { get; set; } = null!;

    public decimal Number { get; set; }

    public string Name { get; set; } = null!;

    public string ShortName { get; set; } = null!;

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? Address3 { get; set; }

    public string? City { get; set; }

    public string? ProvinceStateCode { get; set; }

    public string? CountryId { get; set; }

    public string? CountryCode { get; set; }

    public string? ZipCode { get; set; }

    public string? PhoneNumber { get; set; }

    public string? FaxNumber { get; set; }

    public decimal? RegionNumber { get; set; }

    public string? ManagerName { get; set; }

    public decimal? Scen { get; set; }

    public decimal? DateOpened { get; set; }

    public decimal? Retail { get; set; }

    public string? Poll { get; set; }

    public string? OpenSunday { get; set; }

    public string? Hdo { get; set; }

    public decimal? BankAccount { get; set; }

    public decimal? WarehouseNumber { get; set; }

    public decimal? DistrictNumber { get; set; }

    public string? Cmp { get; set; }

    public string? Type { get; set; }

    public string? PrintQueue { get; set; }

    public decimal? CompanyNumber { get; set; }

    public string? Cntr { get; set; }

    public string? Glyn { get; set; }

    public string? Apyn { get; set; }

    public string? Aryn { get; set; }

    public decimal? LastMerchantCount { get; set; }

    public decimal? ZoneNumber { get; set; }

    public string? CostingMethod { get; set; }

    public string? SalesAuditClerk { get; set; }

    public string? ModelStoreCode { get; set; }

    public string? Ayes { get; set; }

    public decimal? Afct { get; set; }

    public decimal? ReplenishmentZone { get; set; }

    public string? Prms { get; set; }

    public string? Pon { get; set; }

    public decimal? Clcn { get; set; }

    public decimal? DateClosed { get; set; }

    public string? HomeCurrency { get; set; }

    public string? TaxCurrency { get; set; }

    public string? LanguageCode { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateTime? DateEdited { get; set; }

    public bool Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DateDeleted { get; set; }
}
