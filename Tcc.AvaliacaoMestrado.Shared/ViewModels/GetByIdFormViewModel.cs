namespace Tcc.AvaliacaoMestrado.Shared.ViewModels
{
    public class GetByIdFormViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public List<QuestionViewModel> Questions { get; set; }
    }
}
