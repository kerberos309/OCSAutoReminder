namespace Domain.Entities.COMMON_DB
{
    public class AppVersionEntity
    {
        public int Id { get; set; }

        public string Version { get; set; } = null!;

        public string Name { get; set; } = null!;

        public virtual ICollection<AppVersionHeaderEntity> AppVersionHeaders { get; set; } = new List<AppVersionHeaderEntity>();

    }
}