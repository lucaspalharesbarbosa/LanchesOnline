using LanchesOnline.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LanchesOnline.Models {
    public class CarrinhoCompra {
        private readonly LanchesOnlineContext _db;

        public CarrinhoCompra(LanchesOnlineContext db) {
            _db = db;
        }

        public string Id { get; set; }
        public List<ItemCarrinhoCompra> Itens { get; set; }

        public static CarrinhoCompra ObterCarrinhoCompra(IServiceProvider services) {
            // Define uma sessão acessendo o contexto atual.
            var session = services
                .GetRequiredService<IHttpContextAccessor>()
                ?.HttpContext
                .Session;

            // Obtém um servico do tipo do nosso contexto.
            var db = services.GetService<LanchesOnlineContext>();

            // Obtém ou gera o id do carrinho.
            var idCarrinhoCompra = session.GetString("IdCarrinhoCompra") ?? Guid.NewGuid().ToString();

            // Atribui o id do carrinho na Sessão.
            session.SetString("IdCarrinhoCompra", idCarrinhoCompra);

            return new CarrinhoCompra(db) {
                Id = idCarrinhoCompra
            };
        }

        public void AdicionarItem(Lanche lanche, int quantidade) {
            var itemCarrinho = _db.ItensCarrinhosCompras
                .SingleOrDefault(item => item.IdLanche == lanche.Id && item.IdCarrinhoCompra == Id);

            var itemNaoExiste = itemCarrinho == null;
            if (itemNaoExiste) {
                incluir();
            } else {
                aumentarQuantidade();
            }

            _db.SaveChanges();

            void incluir() {
                _db.ItensCarrinhosCompras.Add(new ItemCarrinhoCompra {
                    IdCarrinhoCompra = Id,
                    Lanche = lanche,
                    Quantidade = 1
                });
            }

            void aumentarQuantidade() {
                itemCarrinho.Quantidade++;
            }
        }

        public int RemoverItem(Lanche lanche) {
            var itemCarrinho = _db.ItensCarrinhosCompras
                .SingleOrDefault(item => item.IdLanche == lanche.Id && item.IdCarrinhoCompra == Id);

            var quantidadeLocal = 0;

            var itemExiste = itemCarrinho != null;
            if (itemExiste) {
                var possuiQuantidade = itemCarrinho.Quantidade > 1;
                if (possuiQuantidade) {
                    reduzirQuantidade();
                    
                } else {
                    excluir();
                }
            }

            _db.SaveChanges();

            return quantidadeLocal;

            void reduzirQuantidade() {
                itemCarrinho.Quantidade--;
                quantidadeLocal = itemCarrinho.Quantidade;
            }

            void excluir() {
                _db.ItensCarrinhosCompras.Remove(itemCarrinho);
            }
        }

        public List<ItemCarrinhoCompra> ObterListaItens() {
            return Itens ??= _db.ItensCarrinhosCompras
                .Where(item => item.IdCarrinhoCompra == Id)
                .Include(item => item.Lanche)
                .ToList();
        }

        public void LimparItens() {
            var itensCarrinho = _db.ItensCarrinhosCompras
                .Where(item => item.IdCarrinhoCompra == Id)
                .ToArray();

            _db.ItensCarrinhosCompras.RemoveRange(itensCarrinho);

            _db.SaveChanges();
        }

        public decimal ObterValorTotal() {
            return _db.ItensCarrinhosCompras
                .Where(item => item.IdCarrinhoCompra == Id)
                .Sum(item => item.Lanche.Preco * item.Quantidade);
        }
    }
}