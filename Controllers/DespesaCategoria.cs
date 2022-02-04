using AutoMapper;
using challenge.Data;
using challenge.Data.Dtos.DespesaDtos;
using challenge.Data.Dtos.DespesaDtos;
using challenge.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DespesaController : Controller
    {
        private ChallengeContext _context;
        private IMapper _mapper;

        public DespesaController(ChallengeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return Ok(_context.Despesas);
        }

        [HttpGet("{id}")]
        public ActionResult Read(int id)
        {
            Despesa despesa = _context.Despesas.FirstOrDefault(despesa => despesa.IdDespesa == id);
            if (despesa != null)
            {
                ReadDespesaDto despesaDto = _mapper.Map<ReadDespesaDto>(despesa);
                return Ok(despesaDto);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreateDespesaDto despesaDto)
        {
            Despesa despesa = _mapper.Map<Despesa>(despesaDto);
            _context.Despesas.Add(despesa);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Read), new { Id = despesa.IdDespesa }, despesa);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateDespesaDto novaDespesaDto)
        {
            Despesa despesa = _context.Despesas.FirstOrDefault(despesa => despesa.IdDespesa == id);
            if (despesa == null)
            {
                return NotFound();
            }
            Despesa novaDespesa = _mapper.Map<Despesa>(novaDespesaDto);
            despesa.Data = novaDespesa.Data;
            despesa.Descricao = novaDespesa.Descricao;
            despesa.Categoria = novaDespesa.Categoria;
            despesa.IdCategoria = novaDespesa.IdCategoria;
            despesa.Valor = novaDespesa.Valor;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Despesa despesa = _context.Despesas.FirstOrDefault(despesa => despesa.IdDespesa == id);
            if (despesa == null)
            {
                return NotFound();
            }
            _context.Remove(despesa);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
