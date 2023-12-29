using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OCS
{
    public class ClearanceAccountabilitiesEmails
    {
        public int Id { get; set; }
        public int? AccId { get; set; }
        public int? BuId { get; set; }
        public string? Email { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
    }
}
