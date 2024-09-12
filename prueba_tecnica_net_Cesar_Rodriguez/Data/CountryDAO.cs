using prueba_tecnica_net_Cesar_Rodriguez.Models;

namespace prueba_tecnica_net_Cesar_Rodriguez.Data
{
    public class CountryDAO
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public List<MbaDAO> Mbas { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
