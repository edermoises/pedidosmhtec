using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Pedidos.Models;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace Pedidos.ViewModels
{
    public class ListaDeClientesViewModel : BaseViewModel
    {
        public ICommand OnPesquisar { get; }
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

        private async void SelecionarCliente()
        {
            if (_clienteSelecionado is null)
                return;

            MessagingCenter.Send(this, "SelecionouCliente", _clienteSelecionado);
            await _navigation.PopPopupAsync();
        }

        private void Pesquisar()
        {
            OnPropertyChanged(nameof(Clientes));
        }

        private void CarregarClientes()
        {
            var clientes = new List<Cliente>
            {
                {  new Cliente(nome: "Arnaldo") },
                {  new Cliente(nome: "Cezar") },
                {  new Cliente(nome: "MHTec") },
                {  new Cliente(nome: "Blumenau") },
            };
            Clientes = clientes.ToList();
            TodosOsClientes = clientes.ToList();
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
