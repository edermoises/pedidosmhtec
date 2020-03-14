using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Pedidos.Models;
using Pedidos.Services;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace Pedidos.ViewModels
{
    public class ListaDeClientesViewModel : BaseViewModel
    {
        public ICommand OnPesquisar { get; }
        public static ListaDeClientesViewModel Contexto;

        public ListaDeClientesViewModel(INavigation navigation)
        {
            _navigation = navigation;
            CarregarClientes();
            OnPesquisar = new Command(Pesquisar);
        }

        private string _pesquisa;
        public string Pesquisa
        {
            get => _pesquisa;
            set { _pesquisa = value; OnPesquisar.Execute(null); }
        }

        private Cliente _clienteSelecionado;
        public Cliente ClienteSelecionado
        {
            get => _clienteSelecionado; set
            {
                _clienteSelecionado = value;
                SelecionarCliente();
            }
        }

        public async void SelecionarCliente()
        {
            if (_clienteSelecionado is null)
                return;

            //MessagingCenter.Send(this, "SelecionouCliente", _clienteSelecionado);
            PedidoViewModel.AdicionarClienteAoPedido(_clienteSelecionado);
            await _navigation.PopPopupAsync();
            //MessagingCenter.Unsubscribe<ListaDeClientesViewModel>(this, "");
        }

        public static void AdicionarCliente(Cliente cliente) 
        {
            ListaDeClientesViewModel.Contexto.Clientes.Add(cliente);
            ListaDeClientesViewModel.Contexto.Clientes = ListaDeClientesViewModel.Contexto.Clientes.ToList();
        }

        private void Pesquisar()
        {
            OnPropertyChanged(nameof(Clientes));
        }

        private void CarregarClientes()
        {
            TodosOsClientes = ClienteDataStore.clientes.ToList();
            Clientes = TodosOsClientes.ToList();
        }

        private List<Cliente> _clientes;
        private readonly INavigation _navigation;

        public List<Cliente> Clientes
        {
            get
            {
                if (!string.IsNullOrEmpty(Pesquisa))
                {
                    return TodosOsClientes.Where(c => c.Nome.ToLower().Contains(Pesquisa.ToLower())).ToList();
                }

                return TodosOsClientes;
            }
            set { _clientes = value; }
        }

        private List<Cliente> TodosOsClientes { get; set; }
    }
}
