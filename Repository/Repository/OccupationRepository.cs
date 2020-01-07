using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class OccupationRepository : IOccupationRepository
    {
        private readonly ApplicationContext context;
        public OccupationRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task<Occupation> Add(Occupation occupation)
        {
            await context.Occupations.AddAsync(occupation);
            return occupation;
        }
        public Occupation Edit(Occupation occupation)
        {
            context.Entry(occupation).State = EntityState.Modified;
            return occupation;
        }
        public async Task<Occupation> Get(int id)
        {
            return await context.Occupations.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);
        }
        public async Task<IEnumerable<Occupation>> Get()
        {
            return await context.Occupations.ToListAsync();
        }

        public void Remove(Occupation occupation)
        {
            context.Remove(occupation);
        }
    }
}
