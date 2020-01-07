using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IPrescriptionInstructionRepository
    {
        void Remove(int prescriptionId);
        Task<IEnumerable<PrescriptionInstruction>> Get(int prescriptionId);
    }
}
