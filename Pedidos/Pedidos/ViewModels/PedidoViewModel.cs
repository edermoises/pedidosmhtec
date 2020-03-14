using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Pedidos.Models;
using Pedidos.Services;
using Pedidos.Views;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;
using Pedido = Pedidos.Models.Pedido;

namespace Pedidos.ViewModels
{
    public class PedidoViewModel : BaseViewModel
    {
        private readonly INavigation _navigation;
        public ICommand OnBuscarClientes { get; }
        public ICommand onSalvarPedido { get; }
        
        public PedidoViewModel(INavigation navigation)
        {
            _navigation = navigation;
            Pedido = new Pedido();
            Cliente = new Cliente(0, "Selecione um cliente");

            GerarCondicaoDePagamento();
            
            CondicaoDePagamentoSelecionado = 1;
            
            OnBuscarClientes = new Command(BuscarClientes);
            onSalvarPedido = new Command(SalvarPedido);

            MessagingCenter.Subscribe<ListaDeClientesViewModel, Cliente>(this, "SelecionouCliente", async (obj, cliente) =>
            {
                var clienteSelecionado = cliente as Cliente;
                Cliente = clienteSelecionado;
            });
        }
        
        private Cliente _cliente;
        public Cliente Cliente
        {
            get => _cliente; set
            {
                _cliente = value;
                OnPropertyChanged(nameof(Cliente));
                Pedido.ClienteID = _cliente.Id;
            }
        }

        public Pedido Pedido { get; set; }
        private int _condicaoDePagamentoSelecionado { get; set; }
        public int CondicaoDePagamentoSelecionado { 
            get 
            {
                return _condicaoDePagamentoSelecionado;
            }
            set 
            { 
                _condicaoDePagamentoSelecionado = value;
                Pedido.CondicaoDePagamento = CondicoesDePagamento[_condicaoDePagamentoSelecionado];
            } 
        }
        
        private async void BuscarClientes(object obj)
        {
            await _navigation.PushPopupAsync(new ListaDeClientes());
        }

        private async void SalvarPedido()
        {
            MessagingCenter.Send(this, "AddPedido", Pedido);
            await _navigation.PopAsync();
        }
        
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
