﻿using QuickBuy.Dominio.ObjetoDeValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBuy.Dominio.Entidades
{
    public class Pedido : Entidade
    {
        public int Id { get; set; }
        public DateTime DataPedido{ get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataPrevisaoEntrega { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string EnderecoCompleto { get; set; }
        public int NumeroEndereco { get; set; }

        public int FormaPagamentoId { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
               
        /// <summary>
        /// O pedido deve ter pelo menos um item pedido ou muitos itens pedidos
        /// </summary>
        public ICollection<ItemPedido> ItensPedidos { get; set; }

        public override void Validate()
        {
            LimparMensagemValidacao();

            if (!ItensPedidos.Any())
                AdicionarCritica("E obrigatório ter almenos um item no pedido!");

            if (string.IsNullOrEmpty(CEP))
                AdicionarCritica("CEP deve estar preenchido!");
        }
    }
}
