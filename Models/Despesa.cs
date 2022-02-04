using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Models
{
    public class Despesa
    {
        [Key]
        [Required]
        public int IdDespesa { get; set; }

        [Required(ErrorMessage = "O data da despesa é obrigatório")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "A descrição da despesa é obrigatória")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A categoria da despesa é obrigatória.")]
        public virtual Categoria Categoria { get; set; }

        [Required]
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "O valor da despesa é obrigatório")]
        [Range(0, 1000000000, ErrorMessage = "O valor despesa deve ser positivo")]
        public double Valor { get; set; }

    }
}
