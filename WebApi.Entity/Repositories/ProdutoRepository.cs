using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain;
using WebApi.Domain.Models;
using WebApi.Domain.Services;

namespace WebApi.Entity.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        private readonly WebContext context;
        public ProdutoRepository(WebContext context) : base(context)
        {
            this.context = context;
        }

        public override int Insert(Produto entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entity.data_alteracao = DateTime.Now;
            entity.data_criacao = DateTime.Now;
            entity.situacao = ESituacao.Ativo;

            entity.categoria = context.categorias.FirstOrDefault(e => e.id == entity.CategoryId && e.situacao == ESituacao.Ativo);

            if (entity.categoria != null)
            {
                context.produtos.Add(entity);
            }
            else
            {
                throw new Exception("Categoria inválida");
            }

            return context.SaveChanges();
        }

        public override int Update(Produto entity)
        {
            var update = context.produtos.Find(entity.id);
            
            update.name = entity.name;
            update.description = entity.description;
            update.value = entity.value;
            update.categoria = context.categorias.Find(entity.CategoryId);

            return base.Update(entity);
        }
    }
}
