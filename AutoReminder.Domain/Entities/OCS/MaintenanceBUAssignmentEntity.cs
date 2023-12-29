using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OCS
{
    public class MaintenanceBUAssignmentEntity
    {
        public int Id { get; set; }
        public int? RoleId { get; set; }
        public bool Deleted { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
}
