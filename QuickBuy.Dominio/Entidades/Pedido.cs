using System;
using System.Collections.Generic;
using System.Linq;
using QuickBuy.Dominio.ObjetoDeValor;

namespace QuickBuy.Dominio.Entidades
{
    public class Pedido : Entidade
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public DateTime DataPrevisaoEntrega { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string EnderecoCompleto { get; set; }
        public string NumeroEndereco { get; set; }
        public int FormaPagamentoId { get; set; }
        public virtual FormaPagamento FormaPagamento { get; set; }
        /// <summary>
        /// Pedidos deve ter pelo menos um item de pedido ou muitos itens pedidos
        /// </summary>
        public virtual ICollection<ItemPedido> ItemPedido { get; set; }

        public override void Validate()
        {
            LimparMensagemValidacao();
            if (!ItemPedido.Any())
                AdicionarCritica("Crítica - Pedido não pode ficar sem item de pedido");
            if (string.IsNullOrEmpty(Cep))
                AdicionarCritica("Crítica - Cep deve estar preenchido");
            
        }
    }
}
