using System.ComponentModel.DataAnnotations;

namespace GameEncyclopedia.Dtos {
    public class CreateMonsterRequest {
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; } = default!;
    }
}
