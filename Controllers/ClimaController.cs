using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using prova_bruno_menezes.Interfaces;
using prova_bruno_menezes.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace prova_bruno_menezes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClimaController : ControllerBase
    {

        private readonly ILogger<ClimaController> _logger;
        private readonly IConsultaClimaService _consultaClimaService;


        public ClimaController(ILogger<ClimaController> logger, IConsultaClimaService consultaClimaService)
        {
            _logger = logger;
            _consultaClimaService = consultaClimaService;
        }



        /// <summary>
        /// GET Clima Cidade Utilizadndo codigo da cidade
        /// </summary>
        /// <param name="cityCode">
        /// <returns></returns>
        [HttpGet]
        [Route("climaCidade")]
        public async Task<ClimaCidadeResposta> GetClimaCidade(int cityCode)
        {
            var result = await _consultaClimaService.GetClimaCidade(cityCode);
            if (result.cidade != null) 
            {
                Console.WriteLine($"---- Pesquisa Codigo da cidade (City Code) {cityCode} -------------------------");
                Console.WriteLine($"Estado: {result.estado}");
                Console.WriteLine($"Cidade: {result.cidade}");
                Console.WriteLine($"Atualizado em: {result.atualizado_em}");

                foreach (var clima in result.clima)
                {
                    Console.WriteLine($"Descrição da Condição: {clima.condicao_desc}");
                    Console.WriteLine($"Min: {clima.min}Cº");
                    Console.WriteLine($"Max: {clima.max}Cº");
                    Console.WriteLine($"Índice UV: {clima.indice_uv}");
                    Console.WriteLine("------- Fim Pesquisa ----------------------");
                }

                return result;
            } else
            {
                Console.WriteLine($"----- Erro ao realizar Pesquisa com Codigo da Cidade (City Code) {cityCode} --- ");
                Console.WriteLine($"Mensagem de erro  {result.message}");
                Console.WriteLine("------- Fim Pesquisa ----------------------");
                return result;

            }
           


        }

        /// <summary>
        /// GET Clima Cidade Utilizadndo codigo da cidade
        /// </summary>
        /// <param name="cityCode">
        /// <returns></returns>
        [HttpGet]
        [Route("climaAeroporto")]
        public async Task<ClimaAeroportoResposta> GetClimaAeroporto(string icaoCode)
        {


            var result = await _consultaClimaService.GetClimaAeroporto(icaoCode);


            if (result.condicao_Desc != null)
            {

                var filePath = "ListaIcao/Icao.json"; // Arquivo Lista com aeroportos
                var jsonString = System.IO.File.ReadAllText(filePath); 
                var aeroportos = JsonConvert.DeserializeObject<List<Aeroporto>>(jsonString);
                var aeroportoBuscado = aeroportos.FirstOrDefault(a => a.Icao == icaoCode);

                Console.WriteLine($"---- Pesquisa Codigo do Aeroporto cidade (City Code) {icaoCode} -------------------------");
                Console.WriteLine($"Codigo Icao: {result.codigo_icao}");
                Console.WriteLine($"Nome do aeroporto: {aeroportoBuscado.Name}");
                Console.WriteLine($"Descrição da Condição: {result.condicao_Desc}");
                Console.WriteLine($"Vento: {result.vento}");
              
                return result;

            }
            else
            {

                Console.WriteLine($"----- Erro ao realizar Pesquisa com Codigo do Aeroporto (Icao Code) {icaoCode} --- ");
                Console.WriteLine($"Mensagem de erro  {result.message}");
                Console.WriteLine("------- Fim Pesquisa ----------------------");
                return result;

            }



        }
    }
}
