using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Domain.Models;
using WebApi.Domain.Services;

namespace WebApi.Service.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;
        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }
        public void Delete(int id)
        {
            _repository.Delete(GetById(id));
        }

        public List<Produto> GetAll<TEntity>()
        {
            var products = _repository.GetAll<Produto>("categoria");
            products.ForEach(e => e.CategoryId = e.categoria.id);

            return products;
        }

        public Produto GetById(int id)
        {
            var product = _repository.GetById(id, "categoria");
            product.CategoryId = product.categoria?.id == null ? 0 : product.categoria.id;
            return product;
        }

        public int Insert(Produto entity)
        {
            return _repository.Insert(entity);
        }

        public int Update(Produto entity)
        {
            return _repository.Update(entity);
        }

    }
}
