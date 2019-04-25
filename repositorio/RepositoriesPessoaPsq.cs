using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using Dapper.Contrib.Extensions;
using Dapper;
using devmedia.Dominio;
using devmedia.Dominio.interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Text;

namespace devmedia.repositorio
{
    public class RepositoriesPessoaPsq : IRepositoriesPessoaPsg
    {
        //private IConfiguration _config;
        private string connectionString;

        //private readonly string teste;

        public RepositoriesPessoaPsq(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DapperPostgres");
        }

        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(connectionString);
            }
        }

        public IEnumerable<Pessoa> GetList()
        {
            using (IDbConnection db = Connection)
            {
                db.Open();
                return db.Query<Pessoa>("Select * FROM Pessoas");
            }
        }

        public Pessoa GetPessoaById(int id)
        {
            using (IDbConnection db = Connection)
            {
                db.Open();
                return db.QueryFirstOrDefault<Pessoa>("Select * FROM Pessoas WHERE id = @Id", new { Id = id });
            }
            
        }

        public int InsertPessoa(Pessoa pessoa)
        {
            using (IDbConnection db = Connection)
            {
                db.Open();
                return  db.Execute("INSERT INTO Pessoas (nome,sobrenome,cpf,email,cidade,bairro,nascimento)                     VALUES (@Nome,@Sobrenome,@Cpf,@Email,@Cidade,@Bairro,@Nascimento)", pessoa);

                
            }

        }

        public bool UpdatePessoa(Pessoa pessoa)
        {
            using (IDbConnection db = Connection)
            {
                StringBuilder strUpdate = new StringBuilder();

                strUpdate.Append("UPDATE pessoas SET ");
                strUpdate.Append(" nome = '" + pessoa.nome + "',");
                strUpdate.Append(" sobrenome = '" + pessoa.sobrenome + "',");
                strUpdate.Append(" cpf = '" + pessoa.cpf + "',");
                strUpdate.Append(" email = '" + pessoa.email + "',");
                strUpdate.Append(" cidade = '" + pessoa.cidade + "',");
                strUpdate.Append(" bairro= '" + pessoa.bairro + "'");
                // strUpdate.Append(" nascimento= '" + pessoa.nascimento + "'");
                strUpdate.Append(" WHERE id = " + pessoa.id.ToString());
                string sql = strUpdate.ToString();
                db.Open();
                return db.Query<bool>(sql).FirstOrDefault();
            }

        }

        public int Delete(int id)
        {
                using (IDbConnection db = Connection)
                {
                    db.Open();
                    return db.Execute("DELETE FROM Pessoas WHERE id = @Id", new { Id = id }); 


                }

        }




       
    }
}
