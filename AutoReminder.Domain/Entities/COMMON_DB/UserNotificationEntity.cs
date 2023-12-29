using static System.Net.Mime.MediaTypeNames;

namespace Domain.Entities.COMMON_DB
{
    public class UserNotificationEntity
    {
        public int Id { get; set; }

        public int UserProfileId { get; set; }

        public string? Title { get; set; }

        public string Message { get; set; } = null!;

        public int ApplicationId { get; set; }

        public string? RedirectUrl { get; set; }

        public bool ReadStatus { get; set; }

        public string? Remarks { get; set; }

        public int? Priority { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime DateCreated { get; set; }

        public string? EditedBy { get; set; }

        public DateTime? DateEdited { get; set; }

        public int? ReferenceId { get; set; }

        public virtual ApplicationEntity Application { get; set; } = null!;

        public virtual UserProfileEntity UserProfile { get; set; } = null!;
    }
}