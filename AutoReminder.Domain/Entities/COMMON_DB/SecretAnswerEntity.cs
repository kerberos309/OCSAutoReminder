namespace Domain.Entities.COMMON_DB
{
    public class SecretAnswerEntity
    {
        public int Id { get; set; }

        public int UserProfileId { get; set; }

        public int SecretQuestionId { get; set; }

        public string Answer { get; set; } = null!;

        public string CreatedBy { get; set; } = null!;

        public DateTime DateCreated { get; set; }

        public string? EditedBy { get; set; }

        public DateTime? DateEdited { get; set; }

        public virtual SecretQuestionEntity SecretQuestion { get; set; } = null!;

        public virtual UserProfileEntity UserProfile { get; set; } = null!;
    }
}