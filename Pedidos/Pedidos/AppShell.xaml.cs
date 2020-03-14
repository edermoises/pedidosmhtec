using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Pedidos
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}
