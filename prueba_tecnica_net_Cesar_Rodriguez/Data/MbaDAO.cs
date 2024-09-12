namespace prueba_tecnica_net_Cesar_Rodriguez.Data
{
    public class MbaDAO
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public CountryDAO Country { get; set; }
        public Guid CountryFk { get; set; }
    }
}
