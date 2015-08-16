using System.Web.Http;
using System.Web.Security;
using CoreBase.Models;

namespace CoreBase.Controllers
{
	public class LogoutController : ApiController
	{
		[Authorize]
		public IHttpActionResult Post()
		{
			FormsAuthentication.SignOut();

			return Ok(new LoggedUserModel());
		}
	}
}