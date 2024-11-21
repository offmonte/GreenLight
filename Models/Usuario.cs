using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GreenLight.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Senha { get; set; }

        // Relacionamento um-para-muitos: um usuário pode ter várias lâmpadas
        public ICollection<Lampada>? Lampadas { get; set; }
    }
}
