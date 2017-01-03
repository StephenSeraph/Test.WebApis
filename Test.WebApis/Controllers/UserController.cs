using System.Collections.Generic;
using System.Web.Http;
using Test.WebApis.Models;

namespace Test.WebApis.Controllers
{
    public class UserController : ApiController
    {
        private IUserRespository usersRespository;

        public UserController(IUserRespository user)
        {
            usersRespository = user;
        }

        public IEnumerable<UserInfo> GetUser()
        {
            return usersRespository.GetUser();
        }

        public IHttpActionResult PostUser([FromBody]UserInfo value)
        {
            if (usersRespository.CreateUser(value))
            {
                return Ok();
            }
            return BadRequest();
        }

        public IHttpActionResult PutUser([FromBody]UserInfo value)
        {
            if (usersRespository.UpdateUser(value))
            {
                return Ok();
            }
            return BadRequest();
        }

        public IHttpActionResult DeleteUser([FromBody]UserInfo value)
        {
            if (usersRespository.DeleteUser(value))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}