namespace Tcc.AvaliacaoMestrado.Domain.Models
{
    public class Form : BaseModel
    {
        public string Name { get; set; }
        public bool isCreated { get; set; }
        public List<Question> Questions { get; set; }
    }
}
