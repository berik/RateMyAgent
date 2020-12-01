using Core.Entities;
using Core.Interfaces.IData;

namespace Infrastructure
{
    public class GameRepository : GenericRepository<SoccerGame>, IGameRepository
    {
        public GameRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}