using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IOccupationRepository
    {
        Task<Occupation> Add(Occupation occupation);
        Occupation Edit(Occupation occupation);
        void Remove(Occupation occupation);
        Task<Occupation> Get(int id);
        Task<IEnumerable<Occupation>> Get();
    }
}
