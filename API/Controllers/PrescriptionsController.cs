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
        private readonly IPrescriptionMedicineRepository prescriptionMedicineRepository;
        private readonly IPrescriptionInstructionRepository prescriptionInstructionRepository;

        public PrescriptionsController(IMapper mapper, IUnitOfWork unitOfWork, IPrescriptionRepository prescriptionRepository, IPrescriptionInstructionRepository prescriptionInstructionRepository, IPrescriptionMedicineRepository prescriptionMedicineRepository)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.prescriptionRepository = prescriptionRepository;
            this.prescriptionInstructionRepository = prescriptionInstructionRepository;
            this.prescriptionMedicineRepository = prescriptionMedicineRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(PrescriptionForAddDTO model)
        {
            Prescription prescription = mapper.Map<Prescription>(model);
            prescription.PrescriptionInstructions = mapper.Map<List<PrescriptionInstruction>>(model.PrescriptionInstructions);
            prescription.PrescriptionMedicines = mapper.Map<List<PrescriptionMedicine>>(model.PrescriptionMedicines);
            await prescriptionRepository.Add(prescription).ConfigureAwait(true);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<PrescriptionForGetDTO>(await prescriptionRepository.Get(prescription.Id).ConfigureAwait(true)));
        }

        [HttpPut]
        public async Task<IActionResult> Put(PrescriptionForEditDTO model)
        {
            prescriptionInstructionRepository.Remove(model.Id);
            prescriptionMedicineRepository.Remove(model.Id);

            Prescription prescription = mapper.Map<Prescription>(model);
            prescription.PrescriptionInstructions = mapper.Map<List<PrescriptionInstruction>>(model.PrescriptionInstructions);
            prescription.PrescriptionMedicines = mapper.Map<List<PrescriptionMedicine>>(model.PrescriptionMedicines);

            prescriptionInstructionRepository.Add(prescription.PrescriptionInstructions);
            prescriptionMedicineRepository.Add(prescription.PrescriptionMedicines);

            prescriptionRepository.Edit(prescription);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<PrescriptionForGetDTO>(await prescriptionRepository.Get(prescription.Id).ConfigureAwait(true)));
        }

        [Route("{id:int}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            Prescription prescription = await prescriptionRepository.Get(id).ConfigureAwait(true);
            prescriptionRepository.Remove(prescription);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<PrescriptionForGetDTO>(prescription));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(mapper.Map<PrescriptionForGetDTO>(await prescriptionRepository.Get(id).ConfigureAwait(true)));
        }

        [Route("patients/{patientId:int}")]
        [HttpGet]
        public async Task<IActionResult> GetForPatient(int patientId)
        {
            return Ok(mapper.Map<List<PrescriptionForGetDTO>>(await prescriptionRepository.GetForPatient(patientId).ConfigureAwait(true)));
        }

        [Route("{id:int}/medicines")]
        [HttpGet]
        public async Task<IActionResult> GetMedicines(int id)
        {
            return Ok(mapper.Map<List<PrescriptionMedicineForGetDTO>>(await prescriptionMedicineRepository.Get(id).ConfigureAwait(true)));
        }

        [Route("{id:int}/instructions")]
        [HttpGet]
        public async Task<IActionResult> GetInstructions(int id)
        {
            return Ok(mapper.Map<List<PrescriptionInstructionForGetDTO>>(await prescriptionInstructionRepository.Get(id).ConfigureAwait(true)));
        }

    }
}