using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IKnowingRepository
    {
        Task<Knowing> Add(Knowing knowing);
        Knowing Edit(Knowing knowing);
        void Remove(Knowing knowing);
        Task<Knowing> Get(int id);
        Task<IEnumerable<Knowing>> Get();
    }
}
