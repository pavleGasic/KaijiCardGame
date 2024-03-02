using System.ComponentModel.DataAnnotations;

namespace KaijiCardGame.Domain
{
    public class Country
    {
        public int ZipCode { get; set; }
        public string Name { get; set; } = "";
    }
}