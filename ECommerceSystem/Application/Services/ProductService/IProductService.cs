using Application.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Product
{
    public interface IProductService
    {
        Task<CreatePrdDto> CreateAsync(CreatePrdDto entity);
        Task<ResultView<UpdatePrdDto>> UpdateAsync(UpdatePrdDto entity);
        Task<List<ProductDto>> GetAllAsync();
        Task<ProductDto> GetOneAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}
