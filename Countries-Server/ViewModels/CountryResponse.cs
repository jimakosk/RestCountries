using System.Xml.Linq;

namespace Countries_Server.ViewModels
{
    public class CountryResponse
    {
        public Name Name { get; set; }
        public List<string> Capital { get; set; }
        public List<string> Borders { get; set; }
    }
    public class Name
    {
        public string Common { get; set; }
    }
}
