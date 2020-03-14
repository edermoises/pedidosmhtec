using Pedidos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pedidos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CatalogoProduto : ContentPage
    {
        public CatalogoProduto()
        {
            InitializeComponent();
            BindingContext = new CatalogoProdutosViewModel();
        }
    }
}