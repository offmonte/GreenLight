using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenLight.Models
{
    public class Registro
    {
        [Key]
        public int Id { get; set; }

        // Relacionamento com a lâmpada
        [ForeignKey("Lampada")]
        public int LampadaId { get; set; }
        public Lampada Lampada { get; set; }

        [Required]
        public float ConsumoWh { get; set; } // Consumo em watt-hora (mês atual)

        [Required]
        public DateTime DataConsumo { get; set; } // Dia do último registro

        public float DiferencaMes { get; set; } // Comparação com o mês anterior
    }
}
