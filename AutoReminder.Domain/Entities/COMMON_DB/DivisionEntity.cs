namespace Domain.Entities.COMMON_DB
{
    public class DivisionEntity
    {
        public int Id { get; set; }

        public int BusinessUnitId { get; set; }

        public string Name { get; set; } = null!;

        public string CreatedBy { get; set; } = null!;

        public DateTime DateCreated { get; set; }

        public string? EditedBy { get; set; }

        public DateTime? DateEdited { get; set; }

        public bool Deleted { get; set; }

        public string? DeletedBy { get; set; }

        public DateTime? DateDeleted { get; set; }

        public virtual BusinessUnitEntity BusinessUnit { get; set; } = null!;

        public virtual required ICollection<UserProfileEntity> UserProfiles { get; set; }
    }
}