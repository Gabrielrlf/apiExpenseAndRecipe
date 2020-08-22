using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Models
{
    [Table("Recipe")]
    public class Recipe
    {
    

        [Key]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]

        public string Description { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]

        public string Value { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]

        public DateTime Date { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]

        public bool PaidIn { get; set; }

        public Recipe() { }

    }
}
