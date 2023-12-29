using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OCS
{
    public class SystemLogsEntity
    {
        public int Id { get; set; }
        public string? LoggedUsername { get; set; }
        public string? Type { get; set; }
        public string? Method { get; set; }
        public string? StackTrace { get; set; }
        public string? InnerException { get; set; }
        public string? Message { get; set; }
        public string? Data { get; set; }
        public string? Remarks { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
