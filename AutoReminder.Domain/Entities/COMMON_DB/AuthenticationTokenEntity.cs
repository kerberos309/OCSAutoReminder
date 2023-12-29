namespace Domain.Entities.COMMON_DB
{
    public class AuthenticationTokenEntity
    {
        public long Id { get; set; }

        public int UserProfileId { get; set; }

        public Guid AuthToken { get; set; }

        public DateTime DateIssued { get; set; }

        public DateTime DateExpiry { get; set; }

        public DateTime? DateExtended { get; set; }

        public string? ExtendedApps { get; set; }

        public virtual UserProfileEntity UserProfile { get; set; } = null!;
    }
}