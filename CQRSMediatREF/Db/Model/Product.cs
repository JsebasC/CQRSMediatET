using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CQRSMediatREF.Db.Model
{
    [Table("Product",Schema ="dbo")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Value { get; set; }

    }
}
