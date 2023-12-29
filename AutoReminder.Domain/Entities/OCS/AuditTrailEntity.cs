using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OCS
{
    public class AuditTrailEntity
    {
        public int Id { get; set; }
        public string? LoginName { get; set; }
        public string? EmployeeNumber { get; set; }
        public int? UserProfileId { get; set; }
        public string? Module { get; set; }
        public string? Remarks { get; set; }
        public string? TransactionName { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? IpAddress { get; set; }
    }
}
