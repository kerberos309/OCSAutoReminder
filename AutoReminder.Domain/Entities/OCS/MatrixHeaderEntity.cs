using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OCS
{
    public class MatrixHeaderEntity
    {
        public int MatrixId { get; set; }
        public Guid PkId { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime? EffectivityFrom { get; set; }
        public DateTime? EffectivityTo { get; set; }
        public int? FormVersion { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastEdited { get; set; }
        public string? LastEditedBy { get; set; }
        public DateTime? ActivationDate { get; set; }
        public bool IsActive { get; set; }
        public bool Deleted { get; set; }
    }
}
