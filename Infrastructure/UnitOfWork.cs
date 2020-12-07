using System.Threading.Tasks;
using Core.Interfaces.IData;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IGameRepository GameRepository { get; }
        public IEventRepository EventRepository { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            GameRepository = new GameRepository(_context);
            EventRepository = new EventRepository(_context);
        }
        
        public void Dispose()
        {
            _context.Dispose();
        }
        
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}