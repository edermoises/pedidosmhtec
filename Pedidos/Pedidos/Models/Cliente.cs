using System;
namespace Pedidos.Models
{
    public class Cliente : BaseModel
    {
        public Cliente(int? id = null, string nome = "")
        {
            Id = id ?? new Guid().GetHashCode();
            Nome = nome;
        }
        public string Nome { get; set; }
    }
}
