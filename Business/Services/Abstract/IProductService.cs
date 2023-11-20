using Core.Utilities.Result;
using Entities.Dtos.Products;

namespace Business.Services.Abstract
{
	public interface IProductService
	{
		Task<IDataResult<List<ProductGetDto>>> GetAll();
		Task<IDataResult<ProductGetDto>> GetById(int id);
		Task<IDataResult<ProductGetDto>> GetByName(string name);
		Task<IResult> AddAsync(ProductCreateDto dto);
		Task<IResult> DeleteAsync(int id);
		Task<IResult> UpdateAsync(ProductUpdateDto dto);
	}
}
