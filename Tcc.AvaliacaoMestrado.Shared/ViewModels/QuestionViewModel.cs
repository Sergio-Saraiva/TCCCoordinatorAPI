namespace Tcc.AvaliacaoMestrado.Shared.ViewModels
{
    public class QuestionViewModel : BaseViewModel
    {
        public Guid FormId { get; set; }
        public string Statement { get; set; }
        public int Type { get; set; }
        public List<OptionViewModel> Options { get; set; }
    }
}
