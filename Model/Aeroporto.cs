namespace prova_bruno_menezes.Model
{
    public class Aeroporto
    {
        public string Code { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Woeid { get; set; }
        public string Tz { get; set; }
        public string Phone { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public string RunwayLength { get; set; }
        public string Elev { get; set; }
        public string Icao { get; set; }
        public string DirectFlights { get; set; }
        public string Carriers { get; set; }
        public List<string> Tokens { get; set; }
    }
}
