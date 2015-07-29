using Maer.Infrastructure.Querying;
using System.Collections.Generic;

namespace Maer.Infrastructure.Domain
{
    public interface IReadOnlyRepository<T, TId> where T : IAggregateRoot
    {
        T FindBy(TId id);
        IEnumerable<T> FindAll();
        IEnumerable<T> FindAll(int index, int count);
        IEnumerable<T> FindBy(Query query);
        IEnumerable<T> FindBy(Query query, int index, int count);
        IEnumerable<T> FindBy(Query query, int pageIndex, int pageSize, out int totalCount);
    }
}
