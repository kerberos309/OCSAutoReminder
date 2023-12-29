using static System.Net.Mime.MediaTypeNames;

namespace Domain.Entities.COMMON_DB
{
    public class AppVersionHeaderEntity
    {
        public int Id { get; set; }

        public int ApplicationId { get; set; }

        public string AppVersion { get; set; } = null!;

        public int AppVersionId { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime DateCreated { get; set; }

        public string? EditedBy { get; set; }

        public DateTime? DateEdited { get; set; }

        public bool Deleted { get; set; }

        public string? DeletedBy { get; set; }

        public DateTime? DateDeleted { get; set; }

        public virtual ICollection<AppVersionDetailEntity> AppVersionDetails { get; set; } = new List<AppVersionDetailEntity>();

        public virtual AppVersionEntity AppVersionNavigation { get; set; } = null!;

        public virtual ApplicationEntity Application { get; set; } = null!;
    }
}