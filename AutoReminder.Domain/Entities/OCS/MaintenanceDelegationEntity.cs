using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OCS
{
    public class MaintenanceDelegationEntity
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string? DelegatedTo { get; set; }
        public string? DelegatedBy { get; set; }
        public DateTime? DateDelegated { get; set; }
        public DateTime? DelegatedUntil { get; set; }
        public bool Active { get; set; }
        public int? BuId { get; set; }
        public bool Deleted { get; set; }
    }
}
