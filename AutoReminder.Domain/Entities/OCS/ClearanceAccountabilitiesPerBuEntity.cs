using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OCS
{
    public class ClearanceAccountabilitiesPerBuEntity
    {
        public int Id { get; set; }
        public int ClearanceAccountabilitiesId { get; set; }
        public int BusinessUnitId { get; set; }
        public bool Deleted { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? DateEdited { get; set; }
        public string? EditedBy { get; set; }
        public DateTime? DateDeleted { get; set; }
        public string? DeletedBy { get; set; }
        public int? FormId { get; set; }
        public int? AccNo { get; set; }
        public ICollection<ClearanceAccountabilitiesEntity>? ClearanceAccountabilities { get; set; }
    }
}
