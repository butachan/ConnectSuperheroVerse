using System.ComponentModel.DataAnnotations;

namespace SuperheroUniverse.Models
{
    public class SaveWorld
    {
        public int Id { get; set; }
        public string? Author { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? maxim{ get; set; }
        public int HeroID { get; set; }
        
        public bool isSlogan { get; set; }
    }
}
