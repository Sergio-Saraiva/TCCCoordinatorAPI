namespace Tcc.AvaliacaoMestrado.Domain.Models
{
    public class Question : BaseModel
    {
        public int Type { get; set; }
        public string Statement { get; set; }
        public List<Option> Options { get; set; }
        public Guid FormId { get; set; }
        public Form Form { get; set; }
        public virtual List<Answer> Answers { get; set; }
    }
}
