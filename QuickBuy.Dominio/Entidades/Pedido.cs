using System;
using System.Collections.Generic;

namespace QuickBuy.Dominio.Entidades
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public int UsuarioId { get; set; }
        /// <summary>
        /// Pedidos deve ter um ou muitos pedidos
        /// </summary>
        public ICollection<ItemPedido> ItemPedido { get; set; }
    }
}
