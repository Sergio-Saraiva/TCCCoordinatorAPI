namespace Tcc.AvaliacaoMestrado.Domain.Models
{
    public class Option : BaseModel
    {
        public string Value { get; set; }
        public int Order { get; set; }
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
