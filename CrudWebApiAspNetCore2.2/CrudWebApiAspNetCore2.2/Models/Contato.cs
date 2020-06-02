using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudWebApiAspNetCore2._2.Models
{
    [Table("Contato")]
    public class Contato
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public bool Verificado { get; set; }
    }
}
