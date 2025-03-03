using Application.DTO_s;
using Application.Services.Product;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController( IProductService productService , IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
            
        }

        

        [HttpPost("CreateProduct")]

        public async Task<ActionResult<CreatePrdDto>> Create([FromBody] CreatePrdDto prdDto)
        {
            var products = await _productService.GetAllAsync();
            var selectedPrd = products.FirstOrDefault(p=>p.Name==prdDto.Name);
            try
            {
                if (selectedPrd == null)
                {
                    if (prdDto.Name != null)
                    {

                        var newPrd = await _productService.CreateAsync(prdDto);
                        return Ok(newPrd);
                    }



                }
                return BadRequest(new { Message = "A product with the name '" + selectedPrd.Name + "' already exists." });

            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the product: " + ex.Message);
            }
            

        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await _productService.GetAllAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpGet("{id}" )]

        public async Task<IActionResult> GetOneById(int id)
        {

            try
            {
                 var selectedPrd  = await _productService.GetOneAsync(id);
                if ( selectedPrd != null )
                {
                     return Ok(selectedPrd);
                }
                return BadRequest(new { Message = "this product not found " });


            }
            catch (Exception ex)
            {
                return StatusCode(404, "An error occurred while getting this product: " + ex.Message);

            }
        }

        [HttpPut("UpdateProduct")]

        public async Task<IActionResult> Update (UpdatePrdDto updatePrd)
        {

            try
            {
                var updatedPrd = await _productService.UpdateAsync(updatePrd);
                if ( updatedPrd != null)
                {
                    return Ok (updatedPrd);

                }
                return NotFound("not found");
            }
            catch  (Exception ex)
            {
                return StatusCode(404, "An error occurred while updating this product: " + ex.Message);


            }

        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete (int id)
        {
            try
            {
                var DeletedPrd = await _productService.DeleteAsync(id);
                if (DeletedPrd != null)
                    return Ok(DeletedPrd);

                return NotFound("Book not found");


            }
            catch (Exception ex)
            {
                return StatusCode(00, "An error occurred while deletting this product: " + ex.Message);


            }




        }





    }
}