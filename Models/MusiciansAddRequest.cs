using System.ComponentModel.DataAnnotations;

namespace Crazy_Musicians.Models
{
    public class MusiciansAddRequest
    {
        [Required(ErrorMessage = "zorunlı alan")]
        public string Name { get; set; }

        [Required(ErrorMessage = "zorunlu alan")]
        public string Expertise { get; set; }

        [Required(ErrorMessage = "zorunlu alan")]
        public string FunnyFeature { get; set; }
    }
}
