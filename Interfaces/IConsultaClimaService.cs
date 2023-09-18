using prova_bruno_menezes.Model;

namespace prova_bruno_menezes.Interfaces
{
    public interface IConsultaClimaService
    {
        Task<ClimaCidadeResposta> GetClimaCidade(int cityCode);
        Task<ClimaAeroportoResposta> GetClimaAeroporto(string icaoCode);
    }
}
