using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace JornadaMilhasAPI.Models
{
    public class TestimonyModel
    {
        [Required]
        public int Id { get; set; }
        [AllowNull]
        public string PictureURL { get; set; }
        [AllowNull]
        public string Testimony { get; set; }
        [AllowNull]
        public string PersonsName { get; set; }
    }
}
