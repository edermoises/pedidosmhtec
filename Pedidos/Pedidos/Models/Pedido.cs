using Pedidos.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pedidos.Models
{
    public class Pedido : BaseModel
    {
        public Pedido()
        {
            Id = Guid.NewGuid().GetHashCode();
            DataEmissao = DateTime.Now.Date;
        }

        public int ClienteID { get; set; }
        public string CondicaoDePagamento { get; set; }
        public DateTime DataEmissao { get; set; }
        public List<ItemPedido> ItensDoPedido { get; set; } = new List<ItemPedido>();
        public decimal TotalDoPedido => ItensDoPedido.Sum(item => item.TotalDoITem);
        public string NomeDoCliente 
        { 
            get 
            {
                var nomeCliente = ClienteDataStore.clientes.Find(c => c.Id == ClienteID);
                if (nomeCliente is null)
                    return "";

                return nomeCliente.Nome;                
            }
        }

    }
}
