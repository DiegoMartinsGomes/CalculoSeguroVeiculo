using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalculoSeguroVeiculo.Domain.Models
{
    [Table("Seguro")]
    public class Seguro : Entity
    {
        [Column("IdSegurado")]
        public int IdSegurado { get; set; }

        [Column("IdVeiculo")]
        public int IdVeiculo { get; set; }

        [Column("Valor", TypeName = "decimal(16,2)")]
        public decimal Valor { get; set; }

        [Column("DataCalculo", TypeName = "datetime")]
        public DateTime DataCalculo { get; set; }

        public Segurado Segurado { get; set; }

        public Veiculo Veiculo { get; set; }
    }
}
