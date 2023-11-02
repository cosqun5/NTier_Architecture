using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Products
{
	public class ProductCreateDto
	{
		public string Name { get; set; }
		public double Price { get; set; }
		public string Description { get; set; }
	}
}
