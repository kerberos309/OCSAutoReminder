using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OCS
{
    public class MaintenanceEmploymentStatusEntity
    {
        public int Id { get; set; }
        public string? EmploymentStatus { get; set; }
        public string? StatusCode { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
