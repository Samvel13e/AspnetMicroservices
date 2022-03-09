using Ordering.Domain.Common.Entities;

namespace Ordering.Application.Contracts.Persistence
{
    internal interface IOrderRepository : IAsyncRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrderByUserName(string userName);

    }
}
