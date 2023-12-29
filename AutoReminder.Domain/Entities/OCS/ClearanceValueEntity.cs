using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OCS
{
    public class ClearanceValueEntity
    {
        public int Id { get; set; }
        public int? FormId { get; set; }
        public int? AccId { get; set; }
        public int? TurnOver { get; set; }
        public int? Paid { get; set; }
        public int? NotApplicable { get; set; }
        public decimal? ForDeduction { get; set; }
        public decimal? ForAddition { get; set; }
        public string? Remarks { get; set; }
        public bool Deactivated { get; set; }
        public int? RemainingBalance { get; set; }
        public int? PasswordReset { get; set; }
        public string? EmployeeNumber { get; set; }
        public string? TrackingNumber { get; set; }
        public bool IsExternalResponse { get; set; }
    }
}
