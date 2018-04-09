using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}