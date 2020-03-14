using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pedidos.Models;

namespace Pedidos.Services
{
    public class PedidoDataStore : IDataStore<Pedido>
    {
        readonly List<Pedido> pedidos;

        public PedidoDataStore()
        {
            pedidos = new List<Pedido>();
        }

        public async Task<bool> AddItemAsync(Pedido item)
        {
            pedidos.Add(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Pedido item)
        {
            var oldItem = pedidos.Where((Pedido arg) => arg.Id == item.Id).FirstOrDefault();
            pedidos.Remove(oldItem);
            pedidos.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = pedidos.Where((Pedido arg) => arg.Id == id).FirstOrDefault();
            pedidos.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Pedido> GetItemAsync(int id)
        {
            return await Task.FromResult(pedidos.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Pedido>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(pedidos);
        }
    }
}