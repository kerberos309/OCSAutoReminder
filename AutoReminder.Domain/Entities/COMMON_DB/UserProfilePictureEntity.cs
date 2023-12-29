namespace Domain.Entities.COMMON_DB
{
    public class UserProfilePictureEntity
    {
        public int Id { get; set; }

        public int UserProfileId { get; set; }

        public byte[] ProfilePicture { get; set; } = null!;

        public bool? Active { get; set; }

        public string Type { get; set; } = null!;

        public virtual UserProfileEntity UserProfile { get; set; } = null!;
    }
}