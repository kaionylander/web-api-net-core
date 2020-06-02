using CrudWebApiAspNetCore2._2.Data;
using CrudWebApiAspNetCore2._2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudWebApiAspNetCore2._2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatosController : ControllerBase
    {
        private readonly ContatoContexto _context;

        public ContatosController(ContatoContexto contexto)
        {
            _context = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contato>>> GetContatos()
        {
            return await _context.Contatos.ToListAsync();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Contato>> GetContatos(int id)
        {
            var contatos = await _context.Contatos.FindAsync(id);

            if(contatos == null)
            {
                return null;
            }

            return contatos;
        }

        [HttpPost]
        public async Task<ActionResult<Contato>> PostContato(Contato contato)
        {
            _context.Contatos.Add(contato);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetContatos), new { id = contato.Id }, contato);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<Contato>> PutContato(int id, Contato contato)
        {

            if(id != contato.Id)
            {
                return BadRequest();
            }
            _context.Entry(contato).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return contato;
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<Contato>> DeleteContato(int id)
        {

            var contato = await _context.Contatos.FindAsync(id);

            if (contato == null)
            {
                return NotFound();
            }

            _context.Contatos.Remove(contato);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}