using AutoMapper;
using challenge.Data;
using challenge.Data.Dtos.CategoriaDtos;
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
    public class CategoriaController : Controller
    {
        private ChallengeContext _context;
        private IMapper _mapper;

        public CategoriaController(ChallengeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return Ok(_context.Categorias);
        }

        [HttpGet("{Id}")]
        public ActionResult Read(int id)
        {
            Categoria categoria = _context.Categorias.FirstOrDefault(categoria => categoria.IdCategoria == id);
            if (categoria != null)
            {
                ReadCategoriaDto categoriaDto = _mapper.Map<ReadCategoriaDto>(categoria);
                return Ok(categoriaDto);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreateCategoriaDto categoriaDto)
        {
            Categoria categoria = _mapper.Map<Categoria>(categoriaDto);
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Read), new { Id = categoria.IdCategoria }, categoria);
        }

        [HttpPut("{Id}")]
        public IActionResult Update(int id, [FromBody] UpdateCategoriaDto categoriaNovaDto)
        {
            Categoria categoria = _context.Categorias.FirstOrDefault(categoria => categoria.IdCategoria == id);
            if (categoria == null)
            {
                return NotFound();
            }
            Categoria categoriaNova = _mapper.Map<Categoria>(categoriaNovaDto);
            categoria.Nome = categoriaNova.Nome;
            categoria.Tipo = categoriaNova.Tipo;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            Categoria categoria = _context.Categorias.FirstOrDefault(categoria => categoria.IdCategoria == id);
            if(categoria == null)
            {
                return NotFound();
            }
            _context.Remove(categoria);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
