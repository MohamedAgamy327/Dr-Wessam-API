using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class PrescriptionMedicineRepository : IPrescriptionMedicineRepository
    {
        private readonly ApplicationContext context;
        public PrescriptionMedicineRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<PrescriptionMedicine>> Get(int prescriptionId)
        {
            return await context.PrescriptionMedicines.Include(i => i.Medicine).Include(k => k.Frequency).ToListAsync();
        }
        public void Remove(int prescriptionId)
        {
            context.Remove(context.PrescriptionMedicines.Where(r => r.PrescriptionId == prescriptionId));
        }
    }
}
