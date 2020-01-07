using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IInstructionRepository
    {
        Task<Instruction> Add(Instruction instruction);
        Instruction Edit(Instruction instruction);
        void Remove(Instruction instruction);
        Task<Instruction> Get(int id);
        Task<IEnumerable<Instruction>> Get();
    }
}
