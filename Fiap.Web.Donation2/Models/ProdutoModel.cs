﻿namespace Fiap.Web.Donation2.Models
{
    public class ProdutoModel
    {

        public int ProdutoId { get; set; }

        public string Nome { get; set; }

        public bool Disponivel { get; set; }

        public int TipoProdutoId { get; set; }

        public string Descricao { get; set; }

        public string SugestaoTroca { get; set; }

        public double Valor { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataExpiracao { get; set; }


        public UsuarioModel Usuario { get; set; }


    }
}
