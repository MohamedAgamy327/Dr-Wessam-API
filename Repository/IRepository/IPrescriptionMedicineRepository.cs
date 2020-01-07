using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IPrescriptionMedicineRepository
    {
        void Remove(int prescriptionId);
        Task<IEnumerable<PrescriptionMedicine>> Get(int prescriptionId);
        void Add(ICollection<PrescriptionMedicine> prescriptionMedicines);
    }
}
