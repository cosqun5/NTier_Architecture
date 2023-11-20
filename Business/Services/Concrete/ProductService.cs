
using AutoMapper;
using Business.Services.Abstract;
using Business.Utilities.Constants;
using Core.Utilities.Exceptions;
using Core.Utilities.Result;
using DateAccess.Repositories.Abstract;
using Entities;
using Entities.Dtos.Products;

namespace Business.Services.Concrete
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _repository;
		private readonly IMapper _mapper;

		public ProductService(IProductRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<IResult> AddAsync(ProductCreateDto dto)
		{
			if (await _repository.IsExistsAsync(p => p.Name == dto.Name))
			{
				throw new AlreadyIsExistsException(ExceptionMessages.ProductAlreadyExists);
			}
			//automapper ve automapper dependecinjection yuklemek lazimdi.
			await _repository.AddAsync(_mapper.Map<Product>(dto));
			int resul = await _repository.SaveAsync();
			if (resul == 0)
			{
				return new ErrorResult("Product does not Add");
			}
			return new SuccessResult("Product Add");
		}

		public async Task<IResult> DeleteAsync(int id)
		{
			Product product = await _repository.GetAsync(p => p.Id == id);
			if (product == null) throw new NotFoundException(ExceptionMessages.ProductNotFound);
			_repository.Delete(product);
			int resul = await _repository.SaveAsync();
			if (resul == 0)
			{
				return new ErrorResult("Product does not Deleted");

			}
			return new SuccessResult("Product Deleted");

		}

		public async Task<IDataResult<List<ProductGetDto>>> GetAll()
		{
			var result = await _repository.GetAllAsync();
			if (result.Count == 0)
			{
				return new ErrorDataResult<List<ProductGetDto>>("Product not found");
			}

			return new SuccesDataResult<List<ProductGetDto>>(_mapper.Map<List<ProductGetDto>>(result), "Product listed");

		}

		public async Task<IDataResult<ProductGetDto>> GetById(int id)
		{
			Product product = await _repository.GetAsync(p => p.Id == id);
			if (product == null) return new ErrorDataResult<ProductGetDto>(ExceptionMessages.ProductNotFound);
			return new SuccesDataResult<ProductGetDto>(_mapper.Map<ProductGetDto>(product));
		}

		public async Task<IDataResult<ProductGetDto>> GetByName(string name)
		{
			Product product = await _repository.GetAsync(p => p.Name == name);
			if (product == null) return new ErrorDataResult<ProductGetDto>(ExceptionMessages.ProductNotFound);
			return new SuccesDataResult<ProductGetDto>(_mapper.Map<ProductGetDto>(product));
		}

		public async Task<IResult> UpdateAsync(ProductUpdateDto dto)
		{
			if (await _repository.IsExistsAsync(p => p.Id == dto.Id)) throw new NotFoundException(ExceptionMessages.ProductNotFound);
			_repository.Update(_mapper.Map<Product>(dto));
			int result = await _repository.SaveAsync();
			if (result == 0)
			{
				return new ErrorResult("Product does not updated");
			};
			return new SuccessResult("Product Updated");

		}
	}
}
