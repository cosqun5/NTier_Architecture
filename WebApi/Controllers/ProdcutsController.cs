using Business.Services.Abstract;
using Entities.Dtos.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdcutsController : ControllerBase
{
	private readonly IProductService _productService;

	public ProdcutsController(IProductService productService)
	{
		_productService = productService;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var result = await _productService.GetAll();
		if(!result.Success)
		{
			return BadRequest(result);
		}
		return Ok(result);
		
	}
	[HttpGet("{id}")]
	public async Task<IActionResult> GetById([FromRoute] int id)
	{
		var result = await _productService.GetById(id);
		if (!result.Success)
		{
			return BadRequest(result);
		}
		return Ok(result);
	}
	[HttpGet("Name")]
	public async Task<IActionResult> GetByName( string name)
	{
		var result = await _productService.GetByName(name);
		if (!result.Success)
		{
			return BadRequest(result);
		}
		return Ok(result);
	}
	[HttpPost]
	public async Task<IActionResult> Add(ProductCreateDto dto)
	{
		var result = await _productService.AddAsync(dto);
		if (!result.Success)
		{
			return BadRequest(result);
		}
		return Ok(result);
	}

}
