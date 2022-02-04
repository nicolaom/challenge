using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using challenge.Models;

namespace challenge.Data.Dtos.ReceitaDtos
{
    public class CreateReceitaDto
    {

        [Required(ErrorMessage = "O data da receita é obrigatório")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "A descrição da receita é obrigatória")]
        [MaxLength(255, ErrorMessage = "A descrição da receita deve ter no máximo 255 caracteres.")]
        public string Descricao { get; set; }
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "O valor da receita é obrigatório")]
        [Range(0, 1000000000, ErrorMessage = "O valor receita deve ser positivo")]
        public double Valor { get; set; }
    }
}
