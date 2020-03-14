using System;
namespace Pedidos.Models
{
    public class Produto : BaseModel
    {
        public string Foto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal ValorUnitario { get; set; }
        public int Quantidade { get; set; }
        public decimal Total => Quantidade * ValorUnitario;
    }
}
