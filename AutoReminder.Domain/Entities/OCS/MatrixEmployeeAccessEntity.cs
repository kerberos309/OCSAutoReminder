﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OCS
{
    public class MatrixEmployeeAccessEntity
    {
        public int Id { get; set; }
        public string? EmployeeNumber { get; set; }
        public int? MatrixId { get; set; }
        public int? EntityId { get; set; }
        public int? FormId { get; set; }
    }
}
