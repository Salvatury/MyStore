using Microsoft.EntityFrameworkCore;
using MyStore.Contexto;
using System.Linq.Expressions;

namespace MyStore.Repositorios
{
    public class RepositorioGenerico<TEntidad>(AppDbContext _dbContext) where TEntidad : class
    {
        public async Task<IEnumerable<TEntidad>> TraerTodosAsync()
        {
            return await _dbContext.Set<TEntidad>().ToListAsync();

        }
        public async Task<IEnumerable<TEntidad>> TraerTodosAsync(Expression<Func<TEntidad, object>>[] incluidos)
        {
            IQueryable<TEntidad> query = _dbContext.Set<TEntidad>();
            foreach (var incluye in incluidos) query = query.Include(incluye);

            return await query.ToListAsync();

        }

        public async Task AgregarAsync(TEntidad entidad)
        {
            await _dbContext.Set<TEntidad>().AddAsync(entidad);
            await _dbContext.SaveChangesAsync();

        }
        public async Task<TEntidad?> TraerPorIdAsync(int entidadId)
        {
            return await _dbContext.Set<TEntidad>().FindAsync(entidadId);

        }

        public async Task EditarAsync(TEntidad entidad)
        {
            _dbContext.Set<TEntidad>().Update(entidad);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EliminarAsync(TEntidad entidad)
        {
            _dbContext.Set<TEntidad>().Remove(entidad);
            await _dbContext.SaveChangesAsync();
        }
    }
}