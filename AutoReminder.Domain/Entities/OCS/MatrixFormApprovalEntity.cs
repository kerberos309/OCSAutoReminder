using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OCS
{
    public class MatrixFormApprovalEntity
    {
        public int ApprovalId { get; set; }
        public int FormId { get; set; }
        public int ApprovalLevel { get; set; }
        public string? DepartmentValue { get; set; }
        public int? MatrixId { get; set; }
        public int? InOrder { get; set; }
    }
}
