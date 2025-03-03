using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.DTO_s
{
    public class UpdatePrdDto
    {
        public UpdatePrdDto()
        {

        }
        public UpdatePrdDto(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Price = product.Price;


        }
        public int Id { get; set; }


        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string? Name { get; set; }


        [Required(ErrorMessage = "Please enter product Price")]
        [Range(0.01, 200000)]
        public decimal Price { get; set; }
    }
}
