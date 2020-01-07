using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IPrescriptionRepository
    {
        Task<Prescription> Add(Prescription prescription);
        Prescription Edit(Prescription prescription);
        void Remove(Prescription prescription);
        Task<Prescription> Get(int id);
        Task<IEnumerable<Prescription>> GetPatient(int patientId);
        Task<IEnumerable<Prescription>> Get();
    }
}
