using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OCS
{
    public class MaintenanceResignationStatusEntity
    {
        public int Id { get; set; }
        public string? StatusCode { get; set; }
        public string? StatusName { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool IsActive { get; set; }
    }
}
