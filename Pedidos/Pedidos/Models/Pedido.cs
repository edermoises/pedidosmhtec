using System;
using System.Collections.Generic;
using System.Linq;

namespace Pedidos.Models
{
    public class Pedido : BaseModel
    {
        public int ClienteID { get; set; }
        public string CondicaoDePagamento { get; set; }
        public DateTime DataEmissao { get; set; }
        public List<ItemPedido> ItensDoPedido { get; set; } = new List<ItemPedido>();
        public decimal TotalDoPedido => ItensDoPedido.Sum(item => item.TotalDoITem);
    }
}
