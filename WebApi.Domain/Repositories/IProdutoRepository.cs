using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Models;
using WebApi.Domain.Repositories;

namespace WebApi.Domain.Services
{
    public interface IProdutoRepository : IBaseRepository<Produto>
    {
    }
}
