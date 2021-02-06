using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Domain.Models;
using WebApi.Domain.Services;

namespace WebApi.Service.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;
        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }
        public void Delete(int id)
        {
            _repository.Delete(GetById(id));
        }

        public List<Categoria> GetAll<TEntity>()
        {
            return _repository.GetAll<Categoria>();
        }

        public Categoria GetById(int id)
        {
            return _repository.GetById(id);
        }

        public int Insert(Categoria entity)
        {
            return _repository.Insert(entity);
        }

        public int Update(Categoria entity)
        {
            return _repository.Update(entity);
        }

        public bool HasProduto(int id)
        {
            return _repository.HasProduto(id);
        }
    }
}
