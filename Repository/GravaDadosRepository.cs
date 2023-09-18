using Microsoft.Extensions.Configuration;
using prova_bruno_menezes.Data;
using prova_bruno_menezes.Interfaces;
using prova_bruno_menezes.Model;

namespace prova_bruno_menezes.Repository
{

    public class GravaDadosRepository : IGravaDados
    {

        DataAccess conexao;
       
        public GravaDadosRepository(IConfiguration configuration)
        {
            conexao = new DataAccess(configuration.GetConnectionString("SqlConnection"));
           

        }
     
        public int gravaRetornoLog(string log)
        {
            int retorno;
            var dataehora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string command = $"INSERT INTO tabela_log values ('{dataehora}', '{log}')";
            retorno = conexao.ExecuteNonQuery(command);

            return retorno;
        }

        public int gravaDados(string icaoCode, int cityCode, string response)
        {
            int retorno;
            var dataehora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var tabela_log = "tabela_RetornoApiCidade";

            if (cityCode == 0)
            {
                tabela_log = "tabela_RetornoApiAeroporto";
            }
            string command = $"INSERT INTO {tabela_log} values ('{dataehora}', '{response}')";
            retorno = conexao.ExecuteNonQuery(command);

            return retorno;
        }

     
    }
}
