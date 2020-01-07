using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class PrescriptionInstructionRepository : IPrescriptionInstructionRepository
    {
        private readonly ApplicationContext context;
        public PrescriptionInstructionRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public async void Add(ICollection<PrescriptionInstruction> prescriptionInstructions)
        {
            await context.PrescriptionInstructions.AddRangeAsync(prescriptionInstructions);
        }
        public async Task<IEnumerable<PrescriptionInstruction>> Get(int prescriptionId)
        {
            return await context.PrescriptionInstructions.Include(i => i.Instruction).ToListAsync();
        }
        public void Remove(int prescriptionId)
        {
            context.RemoveRange(context.PrescriptionInstructions.Where(r => r.PrescriptionId == prescriptionId));
        }
    }
}
