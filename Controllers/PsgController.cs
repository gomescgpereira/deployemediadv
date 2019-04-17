using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using devmedia.Dominio;
using devmedia.Dominio.interfaces;
using Swashbuckle.AspNetCore.Swagger;



namespace devmedia.Controllers
{
    [Produces("application/json")]
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
        [ProducesResponseType(201)]
        [ProducesResponseType(400)] 
        public IEnumerable<Pessoa> Get()
        {
            return _repository.GetList();
        }

        // GET: api/Psg/5

        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)] 
        public Pessoa Get(int id)
        {
            return _repository.GetPessoaById(id);
        }

        // POST: api/Psg
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)] 
        public void Post([FromBody] Pessoa value)
        {
            _repository.InsertPessoa(value);
        }

        // PUT: api/Psg/5
        [HttpPut("{id}")]
        [ProducesResponseType(202)]
        [ProducesResponseType(404)] 
        [ProducesResponseType(400)] 
        public void Put(int id, [FromBody] Pessoa value)
        {
            _repository.UpdatePessoa(value );
        }

        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)] 
        [ProducesResponseType(404)] 
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
