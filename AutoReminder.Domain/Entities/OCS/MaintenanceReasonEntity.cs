using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OCS
{
    public class MaintenanceReasonEntity
    {
        public int Id { get; set; }
        public string? FldReason { get; set; }
        public DateTime? FldDateCreated { get; set; }
        public bool FldIsActive { get; set; }
        public bool FldIsOthers { get; set; }
        public bool FldIsDeleted { get; set; }
    }
}
