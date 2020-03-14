using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Pedidos.Models;
using Pedidos.Views;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace Pedidos.ViewModels
{
    public class PedidoViewModel : BaseViewModel
    {
        private readonly INavigation _navigation;

        public ICommand OnBuscarClientes { get; }

        public PedidoViewModel(INavigation navigation)
        {
            _navigation = navigation;
            Cliente = new Cliente(0, "Selecione um cliente");
            GerarCondicaoDePagamento();
            CondicaoDePagamentoSelecionado = 1;
            OnBuscarClientes = new Command(BuscarClientes);

            MessagingCenter.Subscribe<ListaDeClientesViewModel, Cliente>(this, "SelecionouCliente", async (obj, cliente) =>
            {
                var clienteSelecionado = cliente as Cliente;
                Cliente = clienteSelecionado;
            });
        }

        private async void BuscarClientes(object obj)
        {
            await _navigation.PushPopupAsync(new ListaDeClientes());
        }

        private Cliente _cliente;
        public Cliente Cliente
        {
            get => _cliente; set
            {
                _cliente = value;
                OnPropertyChanged(nameof(Cliente));
            }
        }

        public Models.Pedido Pedido { get; set; }
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
