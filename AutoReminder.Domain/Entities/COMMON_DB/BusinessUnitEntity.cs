using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.COMMON_DB
{
    public class BusinessUnitEntity
    {
        public int Id { get; set; }

        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string ShortName { get; set; } = null!;

        public string JdaLibrary { get; set; } = null!;

        public string JdaIpAddress { get; set; } = null!;

        public string JdaLinkedServerCatalog { get; set; } = null!;

        public string CreatedBy { get; set; } = null!;

        public DateTime DateCreated { get; set; }

        public string? EditedBy { get; set; }

        public DateTime? DateEdited { get; set; }

        public bool Deleted { get; set; }

        public string? DeletedBy { get; set; }

        public DateTime? DateDeleted { get; set; }

        public string? SapProfitCenter { get; set; }

        public string? SapTitle { get; set; }

        public string? SapBucode { get; set; }

        public string? JdaCloneDb { get; set; }

        public string? JdaCloneDbDev { get; set; }

        public string? RbeeDb { get; set; }

        public string? JdaCloneDbName { get; set; }

        public string? RbeeDbName { get; set; }

        public int VoucherLimits { get; set; }

        public virtual ICollection<CompanyEntity> Companies { get; set; } = new List<CompanyEntity>();

        public virtual ICollection<DivisionEntity> Divisions { get; set; } = new List<DivisionEntity>();

        public virtual ICollection<UserProfileEntity> UserProfiles { get; set; } = new List<UserProfileEntity>();

    }
}
