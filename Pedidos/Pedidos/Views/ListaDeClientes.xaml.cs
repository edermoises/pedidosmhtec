using System;
using System.Collections.Generic;
using Pedidos.ViewModels;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace Pedidos.Views
{
    public partial class ListaDeClientes : PopupPage
    {
        public ListaDeClientes()
        {
            InitializeComponent();
            BindingContext = new ListaDeClientesViewModel(Navigation);
        }
    }
}
