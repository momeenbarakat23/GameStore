using System.ComponentModel.DataAnnotations;

namespace store.Models
{
    public class GameStore
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [MinLength(10)]
        public string Description { get; set; }
        public string? Title { get; set; }
        [Required(ErrorMessage ="Need Image")]
        public string Image {  get; set; }
        public string? BlurImage {  get; set; }
        [Required]
        public int Price { get; set; }
        public string? ImageBar1 {  get; set; }
        public string? ImageBar2 { get; set; }
        public string? ImageBar3 { get; set; }
        public string? ImageBar4 { get; set; }
        public string? ImageBar5 { get; set; }
        public string? ImageBar6 { get; set; }
        public int? ReselutionOfImage {  get; set; }
        public string? color { get; set; }
        public string? colorForWord { get; set; }
    }
}
