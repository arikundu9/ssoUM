
using Microsoft.AspNetCore.Mvc;

namespace ssoUM.Utils;
public class RestController : ControllerBase
{
	[NonAction]
	public RestResponse<T> Success<T>()
	{
		RestResponse<T> Resp = new();
		return Resp;
	}
}
