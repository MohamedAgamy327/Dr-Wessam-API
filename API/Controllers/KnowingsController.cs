using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO.Knowing;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;
using Repository.UnitOfWork;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KnowingsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IKnowingRepository knowingRepository;

        public KnowingsController(IMapper mapper, IUnitOfWork unitOfWork, IKnowingRepository knowingRepository)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.knowingRepository = knowingRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(KnowingForAddDTO model)
        {

            Knowing knowing = mapper.Map<Knowing>(model);
            await knowingRepository.Add(knowing).ConfigureAwait(true);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<KnowingForGetDTO>(await knowingRepository.Get(knowing.Id).ConfigureAwait(true)));
        }

        [HttpPut]
        public async Task<IActionResult> Put(KnowingForEditDTO model)
        {
            Knowing knowing = mapper.Map<Knowing>(model);
            knowingRepository.Edit(knowing);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<KnowingForGetDTO>(await knowingRepository.Get(knowing.Id).ConfigureAwait(true)));
        }

        [Route("{id:int}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            Knowing knowing = await knowingRepository.Get(id).ConfigureAwait(true);
            knowingRepository.Remove(knowing);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<KnowingForGetDTO>(knowing));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(mapper.Map<List<KnowingForGetDTO>>(await knowingRepository.Get().ConfigureAwait(true)));
        }
    }
}