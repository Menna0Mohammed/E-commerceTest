using Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO_s;
using AutoMapper;
using Domain.Models;
namespace Application.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository , IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CreatePrdDto> CreateAsync(CreatePrdDto createdto)
        {

            try
            {
                CreatePrdDto product = new ()
                {
                    Id = createdto.Id,
                    Name = createdto.Name,
                    Price = createdto.Price
                };
                // default name and price
                if (string.IsNullOrWhiteSpace(product.Name))
                {
                    product.Name = "Product Name";
                }

                if (product.Price <= 0)
                {
                    product.Price = 100;  
                }

                var createdProduct= _mapper.Map<Domain.Models.Product>(createdto);
                var createdProductDto= await _productRepository.Create(createdProduct);
                var result = _mapper.Map<CreatePrdDto>(createdProductDto);


                return result;
            }
            catch (Exception ex)
            {
                //  log the error or just print it
                Console.WriteLine($"An error occurred: {ex.Message}");

                return null;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var product = await _productRepository.GetOne(id);
                if (product == null) 
                    return false;

                await _productRepository.Delete(product);
                await _productRepository.SaveChanges();
                return true;
            }
            catch (Exception ex)

            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            
            }

        }

        public async Task<List<ProductDto>> GetAllAsync()
        {

            try
            {
                var products = await _productRepository.GetAll();

                if (products == null)
                {
                    Console.WriteLine($"An error occurred: there are no products");

                }

                var productDtos = products.Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                }).ToList();

                return productDtos;

            }
            catch (Exception ex) 
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null ; 

            }

        }

        public async Task<ProductDto> GetOneAsync(int id)
        {
            try
            {
                var product = await _productRepository.GetOne(id);

                if (product != null)
                {

                  var returned_product = _mapper.Map<ProductDto>(product);
                
                    return returned_product;
                }
                

                return null;
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null ;

            }
        }

        public async Task<ResultView<UpdatePrdDto>> UpdateAsync(UpdatePrdDto updatedProduct)
        {
            ResultView<UpdatePrdDto> updatePrd = new();

            try
            {
                var product = await _productRepository.GetOne(updatedProduct.Id);
                if (product == null)
                {
                    updatePrd.Entity = null;
                    updatePrd.IsSuccess = false;
                    updatePrd.Message = "Invalid Data - Product not found";
                    return updatePrd;
                }

                product.Name = !string.IsNullOrWhiteSpace(updatedProduct.Name) ? updatedProduct.Name : product.Name;
                product.Price = updatedProduct.Price > 0 ? updatedProduct.Price : product.Price;

                await _productRepository.Update(product);

                // Map back to DTO
                var retun_updatedPrd = _mapper.Map<UpdatePrdDto>(product);

                updatePrd.Entity = retun_updatedPrd;
                updatePrd.IsSuccess = true;
                updatePrd.Message = "Product Updated Successfully";

                return updatePrd;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");

                updatePrd.Entity = null;
                updatePrd.IsSuccess = false;
                updatePrd.Message = $"An error occurred while updating product: {ex.Message}";

                return updatePrd;
            }
        }
    }
}
