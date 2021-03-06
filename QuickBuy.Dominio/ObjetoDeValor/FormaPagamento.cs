using System;
using System.Collections.Generic;
using System.Text;
using QuickBuy.Dominio.Enum;

namespace QuickBuy.Dominio.ObjetoDeValor
{
    public class FormaPagamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Boleto { get { return Id == (int)TipoFormaPagamentoEnum.Boleto; }}
        public bool CartaoCredito { get { return Id == (int)TipoFormaPagamentoEnum.CartaoCredito; }}
        public bool Deposito { get { return Id == (int)TipoFormaPagamentoEnum.Deposito; }}
        public bool NaoDefinido { get { return Id == (int)TipoFormaPagamentoEnum.NaoDefinido; }}
    }
}
