using AutoMapper;
using challenge.Data;
using challenge.Data.Dtos.ReceitaDtos;
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
    public class ReceitaController : Controller
    {
        private ChallengeContext _context;
        private IMapper _mapper;

        public ReceitaController(ChallengeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return Ok(_context.Receitas);
        }

        [HttpGet("{id}")]
        public ActionResult Read(int id)
        {
            Receita receita = _context.Receitas.FirstOrDefault(receita => receita.IdReceita == id);
            if(receita != null)
            {
                ReadReceitaDto receitaDto = _mapper.Map<ReadReceitaDto>(receita);
                return Ok(receitaDto);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreateReceitaDto receitaDto)
        {
            Receita receita = _mapper.Map<Receita>(receitaDto);
            _context.Receitas.Add(receita);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Read), new { Id = receita.IdReceita }, receita);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UpdateReceitaDto novaReceitaDto)
        {
            Receita receita = _context.Receitas.FirstOrDefault(receita => receita.IdReceita == id);
            if (receita == null)
            {
                return NotFound();
            }
            Receita novaReceita = _mapper.Map<Receita>(novaReceitaDto);
            receita.Data = novaReceita.Data;
            receita.Descricao = novaReceita.Descricao;
            receita.Categoria = novaReceita.Categoria;
            receita.IdCategoria = novaReceita.IdCategoria;
            receita.Valor = novaReceita.Valor;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Receita receita = _context.Receitas.FirstOrDefault(receita => receita.IdReceita == id);
            if (receita == null)
            {
                return NotFound();
            }
            _context.Remove(receita);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
