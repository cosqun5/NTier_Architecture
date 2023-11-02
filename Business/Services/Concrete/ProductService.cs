
using AutoMapper;
using Business.Services.Abstract;
using Business.Utilities.Constants;
using Core.Utilities.Exceptions;
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

		public async Task AddAsync(ProductGetDto dto)
		{
			if(await _repository.IsExistsAsync(p =>p.Name == dto.Name))
			{
				throw new AlreadyIsExistsException(ExceptionMessages.ProductAlreadyExists);
			}
			//automapper ve automapper dependecinjection yuklemek lazimdi.
			await _repository.AddAsync(_mapper.Map<Product>(dto));
			await _repository.SaveAsync();
		}

		public Task DeleteAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<List<ProductGetDto>> GetAll()
		{
			throw new NotImplementedException();
		}

		public Task<ProductGetDto> GetById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ProductGetDto> GetByName(string name)
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(ProductUpdateDto dto)
		{
			throw new NotImplementedException();
		}
	}
}
