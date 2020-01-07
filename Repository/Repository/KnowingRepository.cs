using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class KnowingRepository : IKnowingRepository
    {
        private readonly ApplicationContext context;
        public KnowingRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task<Knowing> Add(Knowing knowing)
        {
            await context.Knowings.AddAsync(knowing);
            return knowing;
        }
        public Knowing Edit(Knowing knowing)
        {
            context.Entry(knowing).State = EntityState.Modified;
            return knowing;
        }
        public async Task<Knowing> Get(int id)
        {
            return await context.Knowings.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);
        }
        public async Task<IEnumerable<Knowing>> Get()
        {
            return await context.Knowings.ToListAsync();
        }

        public void Remove(Knowing knowing)
        {
            context.Remove(knowing);
        }
    }
}
