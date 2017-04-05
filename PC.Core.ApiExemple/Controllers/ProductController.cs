using Microsoft.AspNetCore.Mvc;

namespace PC.Core.Commerce.Controllers
{
	[ApiVersion("1.0", Deprecated = true)]
	[ApiVersion("2.0")]
	[Route("api/[controller]")]
	public class ProductController
	{
		[HttpGet]
		public IActionResult Get()
		{
			return new OkObjectResult(new[]
			{
				new { Id = 1, Name = "Product01" },
				new { Id = 2, Name = "Product02" },
				new { Id = 3, Name = "Product03" }
			});
		}

		[HttpGet, MapToApiVersion("2.0")]
		public IActionResult GetV2()
		{
			return new OkObjectResult(new[]
			{
				new { Id = 1, Name = "Product01", Code = "P01" },
				new { Id = 2, Name = "Product02", Code = "P02" },
				new { Id = 3, Name = "Product03", Code = "P03" }
			});
		}

		[HttpPost]
		public IActionResult AddProduct([FromBody] ProductRequest product)
		{
			return new OkObjectResult(new { Id = 4, Name = product.Name });
		}
	}

	public class ProductRequest
	{
		public string Name { get; set; }
	}
}
