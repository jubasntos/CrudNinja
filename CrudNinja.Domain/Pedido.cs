using System;
using System.Collections.Generic;

namespace CrudNinja.Domain
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public string NomeProduto { get; set; }
        public DateTime Data { get; set; } 
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public string NomeCliente { get; set; }
        public int Valor { get; set; }
        public int Desconto { get; set; }
        public int ValorTotal { get; set; }
    } 
}