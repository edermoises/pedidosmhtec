using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pedidos.Models;

namespace Pedidos.Services
{
    public static class ClienteDataStore 
    {
        public static List<Cliente> clientes;

        public static void CarregarClientes() 
        {
            clientes = new List<Cliente>
            {
                {  new Cliente(nome: "Arnaldo") },
                {  new Cliente(nome: "Cezar") },
                {  new Cliente(nome: "MHTec") },
                {  new Cliente(nome: "Blumenau") },
            };
        }
    }
}