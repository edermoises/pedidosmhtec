using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Pedidos.Models;
using Xamarin.Forms;

namespace Pedidos.ViewModels
{
    public class ListaDeClientesViewModel : BaseViewModel
    {
        public ICommand OnPesquisar { get; }
        public ListaDeClientesViewModel()
        {
            CarregarClientes();
            OnPesquisar = new Command(Pesquisar);
        }

        private string _pesquisa;
        public string Pesquisa
        {
            get => _pesquisa;
            set { _pesquisa = value; OnPesquisar.Execute(null); }
        }

        private void Pesquisar()
        {
            OnPropertyChanged(nameof(Clientes));
        }

        private void CarregarClientes()
        {
            var clientes = new List<Cliente>
            {
                {  new Cliente("Arnaldo") },
                {  new Cliente("Cezar") },
                {  new Cliente("MHTec") },
                {  new Cliente("Blumenau") },
            };
            Clientes = clientes.ToList();
            TodosOsClientes = clientes.ToList();
        }

        private List<Cliente> _clientes;
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
