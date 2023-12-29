using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Domain.Entities.COMMON_DB
{
    public class UserCoverageEntity
    {
        public int Id { get; set; }

        public int UserProfileId { get; set; }

        public int ApplicationId { get; set; }

        public int BusinessUnitId { get; set; }

        public int? DivisionId { get; set; }

        public int RoleId { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime DateCreated { get; set; }

        public string? EditedBy { get; set; }

        public DateTime? DateEdited { get; set; }

        public bool Deleted { get; set; }

        public string? DeletedBy { get; set; }

        public DateTime? DateDeleted { get; set; }

        public virtual ApplicationEntity Application { get; set; } = null!;

        public virtual BusinessUnitEntity BusinessUnit { get; set; } = null!;

        public virtual DivisionEntity? Division { get; set; }

        public virtual RoleEntity Role { get; set; } = null!;

        public virtual UserProfileEntity UserProfile { get; set; } = null!;
    }
}
