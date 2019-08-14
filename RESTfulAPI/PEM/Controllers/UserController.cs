using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PEMServer.Models;
using PEMServer.IRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PEMServer.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUserRepository _repo;   // ISubjectRepository class의 객체 _repo 생성.

        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _repo.GetUsers();
        }

        
        // GET api/<controller>/bjh
        [HttpGet("{ObjName}")]
        public User GetUsers(string ObjName)
        {
            return _repo.GetUsers(ObjName);
        }

        // POST api/<controller>
        [HttpPost]
        public string Post([FromBody]User user)
        {
            return _repo.UpdateEdit(user.ObjName, user.Edit);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
