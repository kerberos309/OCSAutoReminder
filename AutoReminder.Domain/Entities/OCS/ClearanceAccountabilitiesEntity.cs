using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OCS
{
    public class ClearanceAccountabilitiesEntity
    {
        public int Id { get; set; }
        public int? AccNo { get; set; }
        public string? AccName { get; set; }
        public int? FormId { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        public string? Email { get; set; }
    }
}
