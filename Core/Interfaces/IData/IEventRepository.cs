using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.IData
{
    public interface IEventRepository : IGenericRepository<SoccerEvent>
    {
        Task<SoccerEvent> GetByIdAsync(int gameId, Guid eventId);
        Task<IReadOnlyList<SoccerEvent>> GetAllAsync(int gameId);
    }
}