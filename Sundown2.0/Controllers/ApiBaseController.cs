//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using System.Threading.Tasks;

//namespace Sundown2._0.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ApiBaseController : ControllerBase
//    {


//        public int GetUserIdFromRequest()
//        {
//            var x = HttpContext;
//            var jwt = x.Request.Headers["Authorization"];
//            var userIdString = x.User?.Claims.First(x => x.Type == ClaimTypes.UserData).Value;
//            var userId = int.Parse(userIdString);
//            return userId;
//        }

        
//        public string something = HttpContext.User?.Claims.First(x => x.Type == ClaimTypes.UserData).Value;
//    }
//}
