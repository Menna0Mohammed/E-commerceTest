using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO_s
{
    public class CreatePrdDto
    {

        [Required]
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter product name")]
        [MaxLength(100)]
        [MinLength(3)]

        public required string Name { get; set; }

       
        
        [Required(ErrorMessage = "Please enter product Price")]
        [Range(0.01, 200000)]
        public decimal Price { get; set; }

    
    }
}
