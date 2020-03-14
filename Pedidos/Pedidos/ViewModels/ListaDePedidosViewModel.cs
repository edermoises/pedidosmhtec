using Pedidos.Models;
using Pedidos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pedidos.ViewModels
{
    public class ListaDePedidosViewModel : BaseViewModel
    {
        public INavigation Navigation { get; }
        public IDataStore<Pedido> DataStore => DependencyService.Get<IDataStore<Pedido>>();
        public ICommand onNovoPedido { get; }

        public List<Pedido> Pedidos
        {
            get
            {
                return _pedidos;
            }
            set
            {
                _pedidos = value;
                OnPropertyChanged(nameof(Pedidos));
            }
        }
        private List<Pedido> _pedidos;
        
        public ListaDePedidosViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Pedidos = new List<Pedido>();
            onNovoPedido = new Command(NovoPedido);

            MessagingCenter.Subscribe<PedidoViewModel, Pedido>(this, "AddPedido", async (obj, item) =>
            {
                try
                {
                    var newItem = item as Pedido;
                    Pedidos.Add(newItem);
                    await DataStore.AddItemAsync(newItem);
                    Pedidos = Pedidos.ToList();
                }
                catch (Exception ex)
                {
                    
                }
                
            });
        }

        private async void NovoPedido()
        {
            await Navigation.PushAsync(new Views.Pedido());
        }
    }
}
