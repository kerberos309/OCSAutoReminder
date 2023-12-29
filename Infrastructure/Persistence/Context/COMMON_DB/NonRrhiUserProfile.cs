using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Context.COMMON_DB;

public partial class NonRrhiUserProfile
{
    public int Id { get; set; }

    public string EmployeeNumber { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int Gender { get; set; }

    public DateTime Birthday { get; set; }

    public string SssNumber { get; set; } = null!;

    public int NonRrhiCompanyId { get; set; }

    public string Position { get; set; } = null!;

    public string JobGradeLevel { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public int Status { get; set; }

    public bool SharedServices { get; set; }

    public string Signatory { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public string? EditedBy { get; set; }

    public DateTime? DateEdited { get; set; }

    public bool Deleted { get; set; }

    public DateTime? DateDeleted { get; set; }

    public bool? RrhiWide { get; set; }

    public virtual NonRrhiCompany NonRrhiCompany { get; set; } = null!;
}
