using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pedidos.Models;

namespace Pedidos.Services
{
    public static class ProdutoDataStore
    {
        public static List<Produto> produtos;

        public static void CarregarProdutos() 
        {
            produtos = new List<Produto>
            {
                {  new Produto{ Id = 1, Nome = "CERVEJA", ValorUnitario = 50 } },
                {  new Produto{ Id = 2, Nome = "CHOCOLATE", ValorUnitario = 50 } },
                {  new Produto{ Id = 3, Nome = "CARNE", ValorUnitario = 50 } },
                {  new Produto{ Id = 4, Nome = "ARROZ", ValorUnitario = 50 } },
                {  new Produto{ Id = 5, Nome = "CARVÃO", ValorUnitario = 50 } },
                {  new Produto{ Id = 6, Nome = "LINGUICINHA", ValorUnitario = 50 } },
                {  new Produto{ Id = 7, Nome = "MAIONESE", ValorUnitario = 50 } },
                {  new Produto{ Id = 8, Nome = "PÃO", ValorUnitario = 50 } },
                {  new Produto{ Id = 9, Nome = "PÃO DE ALHO", ValorUnitario = 50 } },
                {  new Produto{ Id = 10, Nome = "PEPINO", ValorUnitario = 50.50m } },
            };
        }
    }
}