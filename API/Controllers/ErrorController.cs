using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
	public class ErrorController : ControllerBase
	{
		[Route("error")]
		public IActionResult Error()
		{
			var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
			var exception = context?.Error;
			var code = 500;

			if (exception is HttpRequestException)
			{
				code = 400;
			}

			Response.StatusCode = code;

			return Problem(
				detail: exception?.Message,
				title: "An error occurred while processing your request.");
		}
	}
}