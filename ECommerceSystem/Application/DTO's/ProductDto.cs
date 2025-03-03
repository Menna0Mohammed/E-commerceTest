using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO_s
{
    public class ProductDto
    {

        public ProductDto() { }
        public ProductDto(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Price = product.Price;
        }

        public ProductDto(UpdatePrdDto product)
        {
            Id = product.Id;
            Name = product.Name;
            Price = product.Price ;
        }


        [Required]

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
