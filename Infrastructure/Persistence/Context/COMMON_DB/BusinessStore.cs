using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.COMMON_DB;

public partial class BusinessStore
{
    public int Id { get; set; }

    public string StoreCode { get; set; } = null!;

    public string StoreName { get; set; } = null!;

    public int? BusinessUnitId { get; set; }

    public string JdaCstcod { get; set; } = null!;

    public string Tender { get; set; } = null!;

    public string? DateEdited { get; set; }

    public string? EditedBy { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public string? MappingCodeHeader { get; set; }

    public string? MappingCodeDetail { get; set; }

    public string? SalesDelimeter { get; set; }

    public string? AccountNumber { get; set; }

    public string? SearchTerm { get; set; }

    public string? SalesFileFormat { get; set; }

    public string? SalesPath { get; set; }

    public string? SalesUserName { get; set; }

    public string? SalesPassword { get; set; }

    public string? PaymentPath { get; set; }

    public string? PaymentUserName { get; set; }

    public string? PaymentPassword { get; set; }

    public string? PaymentStoredProcedure { get; set; }

    public string? SalesStoredProcedure { get; set; }

    public string? PaymentDelimeter { get; set; }

    public string? SalesDateFormat { get; set; }

    public string? PaymentDateFormat { get; set; }

    public string? CompanyCode { get; set; }

    public string? PrefixReclass { get; set; }

    public string? PrefixRecon { get; set; }

    public string? PrefixAssignment { get; set; }

    public virtual BusinessUnit? BusinessUnit { get; set; }
}
