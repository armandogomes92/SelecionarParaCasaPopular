using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SelecionarParaCasaPopular.Data.DataContext;
using SelecionarParaCasaPopular.Data.Models;
using SelecionarParaCasaPopular.Data.Models.Dtos;
using SelecionarParaCasaPopular.Services.Interfaces;

namespace SelecionarParaCasaPopular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class FamiliaController : ControllerBase
    {
        private readonly IFamiliaService _familiaService;
        private readonly IMapper _mapper;

        public FamiliaController(FamiliasContext context, IFamiliaService familiaService, IMapper mapper)
        {
            _familiaService = familiaService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaFamilia([FromBody] CreateFamiliaDto familiaDto)
        {
            Familia familia = _mapper.Map<Familia>(familiaDto);
            if (familia == null) return NoContent();
            var result = _familiaService.AdicionaFamilia(familia);
            if (result) return Ok();
            return BadRequest();
        }

        [HttpGet]
        public IActionResult GetFamilias() 
        {
            return Ok(_familiaService.BuscarFamiliaOrdenadoPorPonto());
        }
    }
}
