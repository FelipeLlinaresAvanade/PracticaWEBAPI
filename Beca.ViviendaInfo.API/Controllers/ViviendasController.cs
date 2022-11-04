using AutoMapper;
using Beca.ViviendaInfo.API.Entities;
using Beca.ViviendaInfo.API.Models;
using Beca.ViviendaInfo.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Beca.ViviendaInfo.API.Controllers
{
    [ApiController]
    [Route("api/viviendas")]
    public class ViviendasController : ControllerBase
    {
        private readonly IViviendaInfoRepository _viviendaInfoRepository;
        private readonly IMapper _mapper;
        const int maxViviendasPageSize = 10;

        public ViviendasController(IViviendaInfoRepository viviendaInfoRepository,
            IMapper mapper)
        {
            _viviendaInfoRepository = viviendaInfoRepository ??
                throw new ArgumentNullException(nameof(viviendaInfoRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViviendaSinReservasDto>>> GetTodasViviendas()
        {
            var collection = await _viviendaInfoRepository
                .GetViviendasAsync();

            return Ok(_mapper.Map<IEnumerable<ViviendaSinReservasDto>>(collection));
        }

        [HttpGet("paginadas")]
        public async Task<ActionResult<IEnumerable<ViviendaSinReservasDto>>> GetViviendas(
            int pageNumber = 1, int pageSize = 10)
        {
            if (pageSize > maxViviendasPageSize)
            {
                pageSize = maxViviendasPageSize;
            }

            var (viviendaEntities, paginationMetadata) = await _viviendaInfoRepository
                .GetViviendasAsync(pageNumber, pageSize);

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));

            return Ok(_mapper.Map<IEnumerable<ViviendaSinReservasDto>>(viviendaEntities));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVivienda(
            int id, bool includeReservas = false)
        {
            var vivienda = await _viviendaInfoRepository.GetViviendaAsync(id, includeReservas);
            if (vivienda == null)
            {
                return NotFound();
            }

            if (includeReservas)
            {
                return Ok(_mapper.Map<ViviendaDto>(vivienda));
            }

            return Ok(_mapper.Map<ViviendaSinReservasDto>(vivienda));
        }

        [HttpGet("nombre")]
        public async Task<ActionResult<IEnumerable<ViviendaSinReservasDto>>> GetViviendas(
            string name)
        {
            var(viviendaEntities,numViviendas) = await _viviendaInfoRepository.GetViviendasAsync(name);
            if(numViviendas == 0)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<ViviendaSinReservasDto>>(viviendaEntities));
        }
    }
}
