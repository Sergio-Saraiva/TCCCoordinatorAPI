namespace Tcc.AvaliacaoMestrado.Domain.Models
{
    public class Answer : BaseModel
    {
        public int UserId { get; set; }
        public Question Question { get; set; }
        public Guid QuestionId { get; set; }
        public Option Option { get; set; }
        public Guid OptionId { get; set; }
    }
}
