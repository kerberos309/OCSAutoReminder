using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OCS
{
    public class ClearanceAttachmentEntity
    {
        public int Id { get; set; }
        public Guid? PkId { get; set; }
        public string? TrackingNumber { get; set; }
        public string? Comments { get; set; }
        public string? EmployeeNumber { get; set; }
        public string? EmployeeName { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
