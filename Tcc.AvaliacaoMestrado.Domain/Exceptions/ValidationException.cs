namespace Tcc.AvaliacaoMestrado.Domain.Exceptions
{
    public sealed class ValidationException : Exception
    {
        public ValidationException(Dictionary<string, IEnumerable<string>> errors) : base("Invalid data")
            => Errors = errors;

        public Dictionary<string, IEnumerable<string>> Errors { get; }  
    }
}
