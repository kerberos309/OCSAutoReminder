using static System.Net.Mime.MediaTypeNames;

namespace Domain.Entities.COMMON_DB
{
    public class AppUserEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ApplicationId { get; set; }

        public int NumberVisit { get; set; }

        public DateTime DateCreated { get; set; }

        public string CreatedBy { get; set; } = null!;

        public virtual ApplicationEntity Application { get; set; } = null!;

        public virtual UserProfileEntity User { get; set; } = null!;
    }
}