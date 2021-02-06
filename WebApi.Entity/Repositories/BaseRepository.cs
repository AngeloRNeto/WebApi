using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using WebApi.Domain;
using WebApi.Domain.Models;

namespace WebApi.Entity.Repositories
{
    public class BaseRepository<T> where T : BaseEntity
    {
        private readonly WebContext context;
        string errorMessage = string.Empty;

        public BaseRepository(WebContext context)
        {
            this.context = context;
        }

        //Nomeclatura "virtual" para sobrepor o metodo
        //Em suas suas classes "filhas"
        public virtual T GetById(int id, params string[] navigationProperties)
        {

            var query = context.Set<T>().AsQueryable();

            //Incluíndo as propriedades contidas na classes
            foreach (string navigationProperty in navigationProperties)
            {
                query = query.Include<T>(navigationProperty);
            }

            var res =  query.FirstOrDefault(e => e.situacao == ESituacao.Ativo && e.id == id);

            if (res == null) {
                throw new Exception("Entidade inválida");
            }

            return res;
        }


        public virtual List<T> GetAll<TEntity>(params string[] navigationProperties) // matriz de parametros
        {
            var query = context.Set<T>().AsQueryable();

            //Incluíndo as propriedades contidas na classes
            foreach (string navigationProperty in navigationProperties)
            {
                query = query.Include<T>(navigationProperty);
            }

            return query.Where(e => e.situacao == ESituacao.Ativo).ToList<T>();
        }

        public virtual int Insert(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                entity.data_alteracao = DateTime.Now;
                entity.data_criacao = DateTime.Now;
                entity.situacao = ESituacao.Ativo;

                context.Set<T>().Add(entity);
                return context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }
                throw new Exception(errorMessage, dbEx);
            }
        }

        public virtual int Update(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                var update = context.Set<T>().Find(entity.id);
                update.data_alteracao = DateTime.Now;

                return context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }

                throw new Exception(errorMessage, dbEx);
            }
        }

        public virtual void Delete(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new Exception("entidade invalida");
                }

                var update = context.Set<T>().Find(entity.id);
                update.situacao = ESituacao.Excluido;
                context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                throw new Exception(errorMessage, dbEx);
            }
        }

    }
}

