using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Dapper.Contrib;
//using Dapper.Contrib.Extensions;

namespace devmedia.Dominio
{
   
    public class Pessoa
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string cpf { get; set; }
        public string email { get; set; }
        public string cidade { get; set; }
        public string bairro { get; set; }
        public DateTime nascimento { get; set; }

    }
}
