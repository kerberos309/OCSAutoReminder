namespace Domain.Entities.COMMON_DB
{
    public class PositionEntity
    {
        public int Id { get; set; }

        public string Code { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string CreatedBy { get; set; } = null!;

        public DateTime DateCreated { get; set; }

        public string? EditedBy { get; set; }

        public DateTime? DateEdited { get; set; }

        public bool? Deleted { get; set; }

        public string? DeletedBy { get; set; }

        public DateTime? DateDeleted { get; set; }

        public virtual required ICollection<UserProfileEntity> UserProfiles { get; set; }
    }
}