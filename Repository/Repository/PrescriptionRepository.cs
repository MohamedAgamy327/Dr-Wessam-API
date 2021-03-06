﻿using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly ApplicationContext context;
        public PrescriptionRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task<Prescription> Add(Prescription prescription)
        {
            await context.Prescriptions.AddAsync(prescription);
            return prescription;
        }
        public Prescription Edit(Prescription prescription)
        {
            context.Entry(prescription).State = EntityState.Modified;
            return prescription;
        }
        public async Task<Prescription> Get(int id)
        {
            return await context.Prescriptions.Include(d => d.PrescriptionInstructions).Include(k => k.PrescriptionMedicines).AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);
        }
        public async Task<IEnumerable<Prescription>> Get()
        {
            return await context.Prescriptions.ToListAsync();
        }

        public async Task<IEnumerable<Prescription>> GetForPatient(int patientId)
        {
            return await context.Prescriptions.Where(w => w.PatientId == patientId).ToListAsync();
        }

        public void Remove(Prescription prescription)
        {
            context.Remove(prescription);
        }
    }
}
