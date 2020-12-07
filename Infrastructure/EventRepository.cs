using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.IData;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class EventRepository : GenericRepository<SoccerEvent>, IEventRepository
    {
        public EventRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<SoccerEvent> GetByIdAsync(int gameId, Guid eventId)
        {
            return await Context.SoccerEvents.Where(a => a.SoccerGameId == gameId && a.Id == eventId).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<SoccerEvent>> GetAllAsync(int gameId)
        {
            return await Context.SoccerEvents.Where(a => a.SoccerGameId == gameId).ToListAsync();
        }
    }
}