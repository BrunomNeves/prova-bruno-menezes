using prova_bruno_menezes.Model;

namespace prova_bruno_menezes.Interfaces
{
    public interface IGravaDados
    {
        int gravaDados(string icaoCode, int cityCode, string response);
        int gravaRetornoLog(string Log);
    }
    
}
