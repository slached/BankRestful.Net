using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace hangi_kredi_restful.Entities
{
    [Table("Loans")]
    public class Loan
    {
        [Key] //pk
        public int Id { get; set; }

        [ForeignKey("Bank")]
        public int BankId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Precision(10, 4)]
        public decimal Rate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }
    }
}
