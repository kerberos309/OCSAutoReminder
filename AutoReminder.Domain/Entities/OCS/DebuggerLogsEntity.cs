using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OCS
{
    public class DebuggerLogsEntity
    {
        public int Id { get; set; }
        public string? Message { get; set; }
        public string? FromClass { get; set; }
        public string? FromAction { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool Deleted { get; set; }
    }
}
