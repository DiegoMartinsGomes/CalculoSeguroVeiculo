using System.ComponentModel.DataAnnotations.Schema;

namespace CalculoSeguroVeiculo.Domain.Models
{
    public abstract class Entity
    {
        [Column("Id")]
        public int Id { get; set; }
    }
}
