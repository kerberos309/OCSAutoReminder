namespace Domain.Entities.COMMON_DB
{
    public class AppVersionDetailEntity
    {
        public int Id { get; set; }

        public int HeaderId { get; set; }

        public string Description { get; set; } = null!;

        public virtual AppVersionHeaderEntity Header { get; set; } = null!;
    }
}