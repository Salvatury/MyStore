using Microsoft.EntityFrameworkCore;
using MyStore.Contexto;

namespace MyStore.Repositorios
{
    public class RepositorioGenerico<TEntidad>(AppDbContext _dbContext) where TEntidad : class
    {
        public async Task<IEnumerable<TEntidad>> GetAllAsync()
        {
            return await _dbContext.Set<TEntidad>().ToListAsync();

        }


    }
}
