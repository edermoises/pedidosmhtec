using System;
namespace Pedidos.Models
{
    public class ItemPedido : BaseModel
    {
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public int ProdutoID { get; set; }
        public decimal TotalDoITem => Quantidade * ValorUnitario;
    }
}
