using System;
namespace Pedidos.Models
{
    public class Cliente : BaseModel
    {
        public Cliente(int? id = null, string nome = "")
        {
            Id = id ?? Guid.NewGuid().GetHashCode();
            Nome = nome;
        }
        public string Nome { get; set; }
    }
}
