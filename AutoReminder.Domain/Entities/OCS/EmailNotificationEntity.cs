using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OCS
{
    public class EmailNotificationEntity
    {
        public int Id { get; set; }
        public string? EmailFrom { get; set; }
        public string? EmailTo { get; set; }
        public string? EmailSubject { get; set; }
        public string? EmailTemplate { get; set; }
        public string? EmailData { get; set; }
        public bool IsSent { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
