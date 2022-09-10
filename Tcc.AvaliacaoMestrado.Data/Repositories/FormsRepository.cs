using Microsoft.EntityFrameworkCore;
using Tcc.AvaliacaoMestrado.Data.Context;
using Tcc.AvaliacaoMestrado.Domain.Models;
using Tcc.AvaliacaoMestrado.Domain.Repositories;

namespace Tcc.AvaliacaoMestrado.Data.Repositories
{
    public class FormsRepository : BaseRepository<Form>, IFormsRepository
    {
        private readonly ApplicationDbContext _context;
        public FormsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IQueryable<Form>> GetAllAsync()
        {
            var result = await _context.Set<Form>().Where(x => x.isCreated == true).ToListAsync();
            return result.AsQueryable();
        }

        public async Task<Form?> GetByIdAllAsync(Guid id)
        {
            var entity = await _context.Set<Form>().Include(x => x.Questions).ThenInclude(x => x.Options).FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return null;
            }
            return entity;
        }

        public async Task<Form?> GetByIdCreatedAsync(Guid id)
        {
            var entity = await _context.Set<Form>().Include(x => x.Questions).ThenInclude(x => x.Options).FirstOrDefaultAsync(x => x.Id == id && x.isCreated == true);
            if (entity == null)
            {
                return null;
            }
            return entity;
        }

        public Form Update(Form entity)
        {
            entity.UpdatedAt = DateTime.Now;
            entity.isCreated = true;
            _context.Set<Form>().Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
