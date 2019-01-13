using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devmedia.Dominio;

namespace devmedia.Dominio.interfaces
{
    
    public interface IRepositoriesPessoaPsg
{
    IEnumerable<Pessoa>GetList();

    Pessoa GetPessoaById(int idPessoa);

    int InsertPessoa(Pessoa pessoa);

    bool UpdatePessoa(Pessoa pessoa);

    int Delete(int idPessoa);

    }
}
  

