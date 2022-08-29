using Tcc.AvaliacaoMestrado.Domain.Models.Interfaces;

namespace Tcc.AvaliacaoMestrado.Domain.Models
{
    public abstract class BaseModel : IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
