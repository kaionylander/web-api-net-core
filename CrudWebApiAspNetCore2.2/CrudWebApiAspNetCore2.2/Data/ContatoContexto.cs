using CrudWebApiAspNetCore2._2.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudWebApiAspNetCore2._2.Data
{
    public class ContatoContexto : DbContext
    {
        public ContatoContexto(DbContextOptions<ContatoContexto> options) : base(options)
        {

        }

        public DbSet<Contato> Contatos { get; set; }

    }
}
