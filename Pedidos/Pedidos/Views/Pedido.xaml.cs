using System;
using System.Collections.Generic;
using Pedidos.ViewModels;
using Xamarin.Forms;

namespace Pedidos.Views
{
    public partial class Pedido : ContentPage
    {

        public Pedido(Models.Pedido pedido = null)
        {
            InitializeComponent();
            BindingContext = new PedidoViewModel(Navigation, pedido);
        }
    }
}
