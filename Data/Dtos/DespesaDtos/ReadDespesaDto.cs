using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using challenge.Models;

namespace challenge.Data.Dtos.DespesaDtos
{
    public class ReadDespesaDto
    {

        [Key]
        [Required]
        public int IdDespesa { get; set; }

        [Required(ErrorMessage = "O data da receita é obrigatório")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "A descrição da receita é obrigatória")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A categoria da receita é obrigatória.")]
        public virtual Categoria Categoria { get; set; }

        [Required(ErrorMessage = "O valor da receita é obrigatório")]
        [Range(0, 1000000000, ErrorMessage = "O valor receita deve ser positivo")]
        public double Valor { get; set; }
    }
}
