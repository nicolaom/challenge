using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Data.Dtos.CategoriaDtos
{
    public class UpdateCategoriaDto
    {
        [Required(ErrorMessage = "O tipo da categoria é obrigatório, sendo (R)eceita ou (D)espesa.")]
        [MaxLength(1)]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "O nome da categoria é obrigatório")]
        public string Nome { get; set; }
    }
}
