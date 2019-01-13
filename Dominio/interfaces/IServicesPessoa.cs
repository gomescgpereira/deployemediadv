using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devmedia.Dominio.interfaces
{
    interface IServicesPessoa
    {

        IEnumerable<Pessoa> GetList();

        Pessoa GetPessoaById(int idPessoa);

        int InsertPessoa(Pessoa pessoa);

        bool UpdatePessoa(Pessoa pessoa);
    }
}
