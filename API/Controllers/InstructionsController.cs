using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO.Instruction;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;
using Repository.UnitOfWork;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructionsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IInstructionRepository instructionRepository;

        public InstructionsController(IMapper mapper, IUnitOfWork unitOfWork, IInstructionRepository instructionRepository)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.instructionRepository = instructionRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(InstructionForAddDTO model)
        {

            Instruction instruction = mapper.Map<Instruction>(model);
            await instructionRepository.Add(instruction).ConfigureAwait(true);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<InstructionForGetDTO>(await instructionRepository.Get(instruction.Id).ConfigureAwait(true)));
        }

        [HttpPut]
        public async Task<IActionResult> Put(InstructionForEditDTO model)
        {
            Instruction instruction = mapper.Map<Instruction>(model);
            instructionRepository.Edit(instruction);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<InstructionForGetDTO>(await instructionRepository.Get(instruction.Id).ConfigureAwait(true)));
        }

        [Route("{id:int}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            Instruction instruction = await instructionRepository.Get(id).ConfigureAwait(true);
            instructionRepository.Remove(instruction);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<InstructionForGetDTO>(instruction));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(mapper.Map<List<InstructionForGetDTO>>(await instructionRepository.Get().ConfigureAwait(true)));
        }
    }
}