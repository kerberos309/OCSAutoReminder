using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OCS
{
    public class MaintenancePositionEntity
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? EditedBy { get; set; }
        public DateTime? DateEdited { get; set; }
        public bool Deleted { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
}
