using System.ComponentModel.DataAnnotations.Schema;

namespace CalculoSeguroVeiculo.Domain.Models
{
    [Table("Segurado")]
    public class Segurado : Entity
    {
        [Column("Nome")]
        public string Nome { get; set; }

        [Column("CPF")]
        public string CPF { get; set; }

        [Column("Idade")]
        public int? Idade { get; set; }
    }
}
