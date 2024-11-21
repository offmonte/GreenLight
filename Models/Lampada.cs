using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GreenLight.Models
{
    public class Lampada
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Apelido { get; set; }

        [Required]
        [StringLength(100)]
        public string NomeDispositivo { get; set; }

        [Required]
        public bool Modo { get; set; } // MANUAL = false, AUTOMATICO = true

        // Relacionamento muitos-para-um: cada lâmpada pertence a um único usuário
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        [JsonIgnore]
        public Usuario? Usuario { get; set; }
    }
}
