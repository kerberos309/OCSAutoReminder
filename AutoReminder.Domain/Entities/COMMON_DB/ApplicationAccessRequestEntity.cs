using static System.Net.Mime.MediaTypeNames;

namespace Domain.Entities.COMMON_DB
{
    public class ApplicationAccessRequestEntity
    {
        public int Id { get; set; }

        public int ApplicationId { get; set; }

        public int UserId { get; set; }

        public string? ApplicationRequestStatus { get; set; }

        public int? BusinessUnitId { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime DateCreated { get; set; }

        public string? EditedBy { get; set; }

        public DateTime? DateEdited { get; set; }

        public string? DeletedBy { get; set; }

        public DateTime? DateDeleted { get; set; }

        public virtual ApplicationEntity Application { get; set; } = null!;

        public virtual UserProfileEntity User { get; set; } = null!;
    }
}