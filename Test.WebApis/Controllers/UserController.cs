using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Test.WebApis.Models;

namespace Test.WebApis.Controllers
{
    public class UserController : ApiController
    {
        private User users;

        public UserController()
        {
            users = new Models.User();
        }

        public IEnumerable<UserInfo> GetUser()
        {
            return users.Users;
        }

        public IHttpActionResult PostUser([FromBody]UserInfo value)
        {
            var guid = Guid.Parse("00000000000000000000000000000000");
            if (value.Id != guid)
            {
                if (users.Users.FirstOrDefault(p => p.Id == value.Id) == null)
                {
                    users.Users.Add(value);
                    users.SaveChanges();
                    return Ok();
                }
            }
            return BadRequest();
        }

        public IHttpActionResult PutUser([FromBody]UserInfo value)
        {
            var guid = Guid.Parse("00000000000000000000000000000000");
            if (value.Id != guid)
            {
                var user = users.Users.FirstOrDefault(p => p.Id == value.Id);
                if (user == null)
                {
                    users.Users.Add(value);
                }
                else
                {
                    user.IDCard = value.IDCard;
                    user.Name = value.Name;
                    user.Phone = value.Phone;
                }
                users.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        public IHttpActionResult DeleteUser([FromBody]UserInfo value)
        {
            var user = users.Users.FirstOrDefault(p => p.Id == value.Id);
            if (user != null)
            {
                users.Users.Remove(user);
                users.SaveChanges();
            }
            return Ok();
        }

        /// <summary>
        /// //////////////////////////////////////////////////////
        /// </summary>
        /// <returns></returns>
        // GET: api/User
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        public string Get(int id)
        {
            var i = users.Users.Count();
            var user = users.Users.FirstOrDefault(p => p.IDCard == "3194181827");
            if (!(user == null))
                return user.Name;
            else
                return "asd";
        }

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}