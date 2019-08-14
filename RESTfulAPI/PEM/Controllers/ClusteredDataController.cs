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
    public class ClusteredDataController : Controller
    {
        private IClusteredDataRepository _repo;
        public ClusteredDataController(IClusteredDataRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<ClusteredData> GetClusteredDatas()
        {
            return _repo.GetClusteredDatas();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public string Post([FromBody]ClusteredData clusteredData)   //성용이의 Insert
        {
            return _repo.InsertClusteredData(clusteredData);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public string Delete(ClusteredData clusteredData)       //은석이의 Delete 
        {
            return _repo.DeleteClusteredData(clusteredData);
        }
    }
}
