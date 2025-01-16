using MockProject.Domain;
using MockProject.Persistence.DataAccess;

namespace MockProject.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MockProjectDbContext _context;

        public UnitOfWork(MockProjectDbContext context)
        {
            _context = context;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
