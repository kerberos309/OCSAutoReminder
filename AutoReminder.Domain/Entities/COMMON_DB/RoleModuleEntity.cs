using System.Data;
using System.Reflection;

namespace Domain.Entities.COMMON_DB
{
    public class RoleModuleEntity
    {
        public int Id { get; set; }

        public int RoleId { get; set; }

        public int ApplicationId { get; set; }

        public int ModuleId { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime DateCreated { get; set; }

        public string? EditedBy { get; set; }

        public DateTime? DateEdited { get; set; }

        public bool Deleted { get; set; }

        public string? DeletedBy { get; set; }

        public DateTime? DateDeleted { get; set; }

        public virtual Module Module { get; set; } = null!;

        public virtual RoleEntity Role { get; set; } = null!;
    }
}