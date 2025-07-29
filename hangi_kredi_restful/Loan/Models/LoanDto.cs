using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace hangi_kredi_restful.Models
{
    public class LoanDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int BankId { get; set; }

        public decimal Rate { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
