namespace Tcc.AvaliacaoMestrado.Shared.ViewModels
{
    public class AnswerViewModel : BaseViewModel
    {
        public Guid QuestionId { get; set; }
        public string QuestionStatement { get; set; }
        public Guid OptionId { get; set; }
        public string OptionValue { get; set; }
        public int UserId { get; set; }
    }
}
