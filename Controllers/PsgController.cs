using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using devmedia.Dominio;
using devmedia.Dominio.interfaces;

namespace devmedia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PsgController : ControllerBase
    {
        private readonly IRepositoriesPessoaPsg _repository;
        public PsgController(IRepositoriesPessoaPsg repository)
        {
            _repository = repository;
        }


        // GET: api/Psg
        [HttpGet]
        public IEnumerable<Pessoa> Get()
        {
            return _repository.GetList();
        }

        // GET: api/Psg/5
        [HttpGet("{id}", Name = "Get")]
        public Pessoa Get(int id)
        {
            return _repository.GetPessoaById(id);
        }

        // POST: api/Psg
        [HttpPost]
        public void Post([FromBody] Pessoa value)
        {
            _repository.InsertPessoa(value);
        }

        // PUT: api/Psg/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Pessoa value)
        {
            _repository.UpdatePessoa(value );
        }

        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
