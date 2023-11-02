using Entities.Dtos.Products;

namespace Business.Services.Abstract
{
	public interface IProductService
	{
		Task<List<ProductGetDto>> GetAll();
		Task<ProductGetDto> GetById(int id);
		Task<ProductGetDto> GetByName(string name);
		Task AddAsync(ProductGetDto dto);
		Task DeleteAsync(int id);
		Task UpdateAsync(ProductUpdateDto dto);
	}
}
