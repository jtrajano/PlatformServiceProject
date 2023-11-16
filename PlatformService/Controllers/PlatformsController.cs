using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Core.Interfaces;
using PlatformService.Core.Models;
using PlatformService.Dtos;
using PlatformService.SyncDataService.Http;
using System;
namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformService _service;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _command;
        public PlatformsController(IPlatformService service, IMapper mapper, ICommandDataClient command)
        {
            _command = command;
            _service = service;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlatformReadDto>>> GetPlatForm()
        {

            var result = await _service.GetAllPlatForms();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(result));
        }
        [HttpGet("{id}",Name = "GetPlatformById")]
        public async Task<ActionResult<PlatformReadDto>> GetPlatformById(int id)
        { 
            var result = await _service.GetPlatformById(id);

            if (result == null) return NotFound();

            return Ok(_mapper.Map<PlatformReadDto>(result));
        }

        [HttpPost]

        public async Task<ActionResult<PlatformCreateDto>> CreatePlatform(PlatformCreateDto createDto)
        {
            Platform platform =  _mapper.Map<Platform>(createDto);

            _service.CreatePlatform(platform);

            await _service.SaveChangesAsync();

            var platformReadDto = _mapper.Map<PlatformReadDto>(platform);

          
            try
            {
                await _command.SendPlatformToCommand(platformReadDto);
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("--> Could not send synchronously:" + ex.Message);
            }
       
            return CreatedAtRoute(nameof(GetPlatformById), 
                new { Id = platformReadDto.Id },platformReadDto);
         
        
        }
             
    }
}
