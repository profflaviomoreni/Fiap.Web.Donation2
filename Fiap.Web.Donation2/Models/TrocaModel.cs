using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.Donation2.Models
{

    public enum TrocaStatus
    {
        Iniciado = 1,
        Analisado = 2,
        Finalizado = 3,
        Revertido = 4
    }

    [Table("Troca")]
    public class TrocaModel
    {

        [Key]
        public Guid TrocaId { get; set; } = Guid.NewGuid();

        public TrocaStatus Status { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;


        public int ProdutoId1 { get; set; }

        [ForeignKey(nameof(ProdutoId1))]
        public ProdutoModel Produto1 { get; set; }


        public int ProdutoId2 { get; set; }

        [ForeignKey(nameof(ProdutoId2))]
        public ProdutoModel Produto2 { get; set; }



    }
}
