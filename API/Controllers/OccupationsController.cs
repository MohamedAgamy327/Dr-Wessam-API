using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO.Occupation;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;
using Repository.UnitOfWork;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccupationsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IOccupationRepository occupationRepository;

        public OccupationsController(IMapper mapper, IUnitOfWork unitOfWork, IOccupationRepository occupationRepository)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.occupationRepository = occupationRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(OccupationForAddDTO model)
        {

            Occupation occupation = mapper.Map<Occupation>(model);
            await occupationRepository.Add(occupation).ConfigureAwait(true);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<OccupationForGetDTO>(await occupationRepository.Get(occupation.Id).ConfigureAwait(true)));
        }

        [HttpPut]
        public async Task<IActionResult> Put(OccupationForEditDTO model)
        {
            Occupation occupation = mapper.Map<Occupation>(model);
            occupationRepository.Edit(occupation);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<OccupationForGetDTO>(await occupationRepository.Get(occupation.Id).ConfigureAwait(true)));
        }

        [Route("{id:int}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            Occupation occupation = await occupationRepository.Get(id).ConfigureAwait(true);
            occupationRepository.Remove(occupation);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<OccupationForGetDTO>(occupation));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(mapper.Map<List<OccupationForGetDTO>>(await occupationRepository.Get().ConfigureAwait(true)));
        }
    }
}