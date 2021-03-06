﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pedidos.Services;
using Pedidos.Views;
using Pedidos.ViewModels;

namespace Pedidos
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<PedidoDataStore>();
            ClienteDataStore.CarregarClientes();
            ProdutoDataStore.CarregarProdutos();
            MainPage = new NavigationPage(new CatalogoProduto());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
