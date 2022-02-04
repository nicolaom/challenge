using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace challenge.Models
{
    public class Categoria
    {
        [Key]
        [Required]
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "O tipo da categoria é obrigatório, sendo (R)eceita ou (D)espesa.")]
        [MaxLength(1)]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "O nome da categoria é obrigatório")]
        public string Nome { get; set; }

        [JsonIgnore]
        public virtual List<Despesa> Despesas { get; set; }

        [JsonIgnore]
        public virtual List<Receita> Receitas { get; set; }
    }
}
