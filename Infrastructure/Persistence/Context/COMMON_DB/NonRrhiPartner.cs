using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.COMMON_DB;

public partial class NonRrhiPartner
{
    public int Id { get; set; }

    public string EmployeeNumber { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string? Password { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? CompanyName { get; set; }

    public string? Position { get; set; }

    public string? ContactNumber { get; set; }

    public string? Email { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateTime? DateEdited { get; set; }

    public bool Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DateDeleted { get; set; }

    public string? UserRole { get; set; }

    public virtual ICollection<PartnerBu> PartnerBus { get; set; } = new List<PartnerBu>();
}
