using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OCS
{
    public class NotificationEntity
    {
        public int Id { get; set; }
        public string? Requestor { get; set; }
        public string? Recipient { get; set; }
        public string? Remarks { get; set; }
        public int? IsNew { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? TrackingNumber { get; set; }
        public string? Module { get; set; }
        public string? EmployeeNumber { get; set; }
        public string? EmailRecipient { get; set; }
    }
}
