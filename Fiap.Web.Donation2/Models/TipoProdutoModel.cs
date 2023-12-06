using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.Donation2.Models
{
    [Table("TipoProduto")]
    public class TipoProdutoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TipoProdutoId { get; set; }

        [Required]
        [StringLength(55)]
        //[Column("NM_TP_PRODUTO")]
        public string Nome { get; set; }

        [StringLength(256)]
        public string? Descricao { get; set; }

        [NotMapped]
        public string? Token { get; set; }

    }
}
