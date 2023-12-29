using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OCS
{
    public class MatrixEntityEntity
    {
        public int EntityId { get; set; }
        public string? EntityName { get; set; }
        public string? EntityCategory { get; set; }
        public int? EntityConfig { get; set; }
        public string? EntityDesc { get; set; }
    }
}
