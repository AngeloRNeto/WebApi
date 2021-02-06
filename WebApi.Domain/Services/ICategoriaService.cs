using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Domain.Models;

namespace WebApi.Domain.Services
{
    public interface ICategoriaService : IBaseService<Categoria>
    {
        bool HasProduto(int id);
    }
}
