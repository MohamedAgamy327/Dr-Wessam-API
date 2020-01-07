using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class InstructionRepository : IInstructionRepository
    {
        private readonly ApplicationContext context;
        public InstructionRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task<Instruction> Add(Instruction instruction)
        {
            await context.Instructions.AddAsync(instruction);
            return instruction;
        }
        public Instruction Edit(Instruction instruction)
        {
            context.Entry(instruction).State = EntityState.Modified;
            return instruction;
        }
        public async Task<Instruction> Get(int id)
        {
            return await context.Instructions.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);
        }
        public async Task<IEnumerable<Instruction>> Get()
        {
            return await context.Instructions.ToListAsync();
        }

        public void Remove(Instruction instruction)
        {
            context.Remove(instruction);
        }
    }
}
