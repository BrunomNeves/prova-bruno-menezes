namespace prova_bruno_menezes.Model
{
    public class ClimaCidadeResposta
    {
        public string cidade { get; set; }
        public string estado { get; set; }
        public string atualizado_em { get; set; }
        public List<Clima> clima { get; set; }

        public class Clima
        {

            public string data { get; set; }
            public string condicao { get; set; }
            public int min { get; set; }
            public int max { get; set; }
            public int indice_uv { get; set; }
            public string condicao_desc { get; set; }
        }

        public string message { get; set; }
        public string type { get; set; }
        public string name { get; set; }
    }
}
