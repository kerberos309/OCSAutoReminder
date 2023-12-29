using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OCS
{
    public class ClearanceHoldEntity
    {
        public int Id { get; set; }
        public string? EmployeeNumber { get; set; }
        public string? TrackingNumber { get; set; }
        public string? ClearanceStatus { get; set; }
        public int? FormId { get; set; }
        public string? HoldBy { get; set; }
        public DateTime? HoldDate { get; set; }
        public string? UnholdBy { get; set; }
        public DateTime? UnholdDate { get; set; }
    }
}
