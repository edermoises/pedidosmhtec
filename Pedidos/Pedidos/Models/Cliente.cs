using System;
namespace Pedidos.Models
{
    public class Cliente : BaseModel
    {
        public Cliente(string nome = "")
        {
            Id = new Guid().GetHashCode();
            Nome = nome;
        }
        public string Nome { get; set; }
    }
}
