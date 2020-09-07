using System.ComponentModel.DataAnnotations.Schema;

namespace CalculoSeguroVeiculo.Domain.Models
{
    [Table("Segurado")]
    public class Veiculo : Entity
    {
        [Column("Marca")]
        public string Marca { get; set; }

        [Column("Modelo")]
        public string Modelo { get; set; }

        [Column("Valor", TypeName = "decimal(16,2)")]
        public decimal Valor { get; set; }
    }
}
