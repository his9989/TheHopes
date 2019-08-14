using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PEMServer.IRepository;
using PEMServer.Models;                       // models에 있는 ISubjectRepository.cs, Subject.cs, SubjectRepository.cs 즉, 입출력 관련 코드 구현한 파일 import
using Newtonsoft.Json;                      // C#의 JSON document를 다루기 위한 가장 기본적인 라이브러리
using System.IO;                            // C#의 파일 입출력을 다루는 라이브러리
using System.Runtime.Serialization.Json;    // 객체를 JSON으로 변환하는 라이브러리



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PEMServer.Controllers
{
    [Route("api/[controller]")]
    public class RawDataController : Controller
    {
        private IRawDataRepository _repo;   // ISubjectRepository class의 객체 _repo 생성.

        public RawDataController(IRawDataRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<controller>
        [HttpGet]
        public string Get()
        {
            return "wrong url";
        }

        // GET api/<controller>/bjh
        [HttpGet("{ObjName}")]
        public IEnumerable<RawData> Get(string ObjName)
        {
            return _repo.GetRawDatas(ObjName);
        }


        [HttpGet("{ObjName}/{Time}")]
        public IEnumerable<RawData> Get(string ObjName, string Time)
        {
            return _repo.GetRawDatas(ObjName, Time);
        }

        [HttpGet("{ObjName}/count")]
        public int GetCount(string ObjName)
        {
            return _repo.GetRawDatasCount(ObjName);
        }

        // POST api/<controller>
        [HttpPost("{ObjName}")]
        public string Post(string ObjName, [FromBody]RawData rawData)       //경수형의 Insert
        {
            return _repo.InsertRawDatas(ObjName, rawData);
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
