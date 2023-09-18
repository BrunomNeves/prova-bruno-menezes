using prova_bruno_menezes.Interfaces;
using prova_bruno_menezes.Model;
using Newtonsoft.Json;
using RestSharp;
using prova_bruno_menezes.Repository;
using Microsoft.Extensions.Options;

namespace prova_bruno_menezes.Services
{
    public class ConsultaClima : IConsultaClimaService
    {
        private readonly IGravaDados _gravaDados;
        private readonly string _urlApi;
      



        public ConsultaClima(IGravaDados gravaDados, IOptions<ApiSettings> apiSettings)
        {
            _gravaDados = gravaDados;
            _urlApi = apiSettings.Value.Api_Url;
            
        }

        public async Task<ClimaCidadeResposta> GetClimaCidade(int cityCode)
        {

            ClimaCidadeResposta? retorno = new();
            try
            {
                var options = new RestClientOptions(_urlApi)
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = new RestRequest($"/api/cptec/v1/clima/previsao/{cityCode}", Method.Get);
                RestResponse response = await client.ExecuteAsync(request);

                if (response.IsSuccessful || response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    retorno = JsonConvert.DeserializeObject<ClimaCidadeResposta>(response.Content);
                    GravaRetornoLog(response.StatusCode.ToString());
                    GravarDados("0", cityCode, response.Content);
                }
                else
                {
                    retorno = JsonConvert.DeserializeObject<ClimaCidadeResposta>(response.Content);
                    GravaRetornoLog(response.StatusCode.ToString() + " " + response.Content);
                }

                return retorno;
            }
            catch (Exception ex)
            {
                GravaRetornoLog(ex.ToString());
                return retorno;
            }
        }

        public async Task<ClimaAeroportoResposta> GetClimaAeroporto(string icaoCode)
        {
            ClimaAeroportoResposta? retorno = new();
            try
            {
                var options = new RestClientOptions(_urlApi)
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = new RestRequest($"api/cptec/v1/clima/aeroporto/{icaoCode}", Method.Get);
                RestResponse response = await client.ExecuteAsync(request);

                if (response.IsSuccessful || response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    retorno = JsonConvert.DeserializeObject<ClimaAeroportoResposta>(response.Content);
                    GravaRetornoLog(response.StatusCode.ToString());
                    GravarDados(icaoCode, 0 , response.Content);
                  
                }
                else
                {
                    retorno = JsonConvert.DeserializeObject<ClimaAeroportoResposta>(response.Content);
                    GravaRetornoLog(response.StatusCode.ToString() + " " + response.Content);
                }

                return retorno;
            }
            catch (Exception ex)
            {
                GravaRetornoLog(ex.ToString());
                return retorno;
            }
        }



        public void GravaRetornoLog(string log)
        {
           _gravaDados.gravaRetornoLog(log);
        }

        public void GravarDados(string icaoCode, int cityCode, string response)
        {
            _gravaDados.gravaDados(icaoCode, cityCode, response);
        }


    }
}
