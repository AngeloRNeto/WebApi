using System.Data.Entity;
using System.Linq;
using WebApi.Domain;
using WebApi.Domain.Models;
using WebApi.Domain.Services;

namespace WebApi.Entity.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        private readonly WebContext context;
        public CategoriaRepository(WebContext context) : base(context)
        {
            this.context = context;
        }

        public bool HasProduto(int id)
        {
            return !context.produtos
                   .Include(e => e.categoria).Any(e => e.categoria.id == id && e.categoria.situacao == ESituacao.Ativo);
        }

        public override int Update(Categoria entity)
        {
            var update = context.categorias.Find(entity.id);

            update.name = entity.name;
            update.description = entity.description;

            return base.Update(entity);
        }
    }
}
