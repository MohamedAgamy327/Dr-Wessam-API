using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO.Prescription;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;
using Repository.UnitOfWork;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IPrescriptionRepository prescriptionRepository;

        public PrescriptionsController(IMapper mapper, IUnitOfWork unitOfWork, IPrescriptionRepository prescriptionRepository)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.prescriptionRepository = prescriptionRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(PrescriptionForAddDTO model)
        {
            Prescription prescription = mapper.Map<Prescription>(model);
            prescription.PrescriptionInstructions = mapper.Map<List<PrescriptionInstruction>>(model.PrescriptionInstructions);
            prescription.PrescriptionMedicines = mapper.Map<List<PrescriptionMedicine>>(model.PrescriptionMedicines);
            await prescriptionRepository.Add(prescription).ConfigureAwait(true);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            //return Ok(mapper.Map<PrescriptionForGetDTO>(await prescriptionRepository.Get(prescription.Id).ConfigureAwait(true)));
            return Ok();
        }

        //[HttpPut]
        //public async Task<IActionResult> Put(PrescriptionForEditDTO model)
        //{
        //    Prescription prescription = mapper.Map<Prescription>(model);
        //    prescriptionRepository.Edit(prescription);
        //    await unitOfWork.CompleteAsync().ConfigureAwait(true);
        //    return Ok(mapper.Map<PrescriptionForGetDTO>(await prescriptionRepository.Get(prescription.Id).ConfigureAwait(true)));
        //}

        //[Route("{id:int}")]
        //[HttpDelete]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    Prescription prescription = await prescriptionRepository.Get(id).ConfigureAwait(true);
        //    prescriptionRepository.Remove(prescription);
        //    await unitOfWork.CompleteAsync().ConfigureAwait(true);
        //    return Ok(mapper.Map<PrescriptionForGetDTO>(prescription));
        //}

        [Route("{id:int}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var x = await prescriptionRepository.GetPatient(id).ConfigureAwait(true);
            return Ok(x);
            //return Ok(mapper.Map<List<PrescriptionForGetDTO>>(await prescriptionRepository.Get().ConfigureAwait(true)));
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    return Ok(mapper.Map<PrescriptionForGetDTO>(await prescriptionRepository.Get(id).ConfigureAwait(true)));
        //}
    }
}