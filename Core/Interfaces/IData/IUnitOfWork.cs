using System;
using System.Threading.Tasks;

namespace Core.Interfaces.IData
{
    public interface IUnitOfWork : IDisposable
    {
        IGameRepository GameRepository { get; }
        IEventRepository EventRepository { get; }
        
        /// <summary>
        /// Commit ACID
        /// </summary>
        /// <returns></returns>
        Task<int> CompleteAsync();
    }
}