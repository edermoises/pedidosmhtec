using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Pedidos.Models;

namespace Pedidos.ViewModels
{
    public class PedidoViewModel : BaseViewModel
    {
        public PedidoViewModel()
        {
            GerarCondicaoDePagamento();
            CondicaoDePagamentoSelecionado = 1;
        }

        public Cliente Cliente { get; set; } 
        public Pedido Pedido { get; set; }
        public int CondicaoDePagamentoSelecionado { get; set; }

        private void GerarCondicaoDePagamento()
        {
            var condicoesDePagamento = new List<string>
            {
                "A vista",
                "Crediário das Casas Bahia",
                "Parcelado",
                "Quer pagar quanto?"
            };
            CondicoesDePagamento = condicoesDePagamento.ToList();
        }

        public List<string> CondicoesDePagamento { get; set; }
    }
}
