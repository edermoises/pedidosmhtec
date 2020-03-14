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

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new Pedido());
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