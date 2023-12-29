using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OCS
{
    public class MatrixFormEntity
    {
        public int FormId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? FormVersion { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
    }
}
