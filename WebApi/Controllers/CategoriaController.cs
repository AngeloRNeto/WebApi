using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Models;
using WebApi.Domain.Services;

namespace WebApi.Controllers
{

    [Route("api/category")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ILogger<CategoriaController> _logger;
        private readonly ICategoriaService _services;

        public CategoriaController(ILogger<CategoriaController> logger, ICategoriaService service)
        {
            this._logger = logger;
            this._services = service;
        }

        [HttpPost()]
        public ActionResult Create(Categoria categoria)
        {
            try
            {

                if (categoria == null)
                    return BadRequest("Categoria vazio");

                var categoriaNew = _services.Insert(categoria);

                if (categoriaNew != null)
                {
                    return Ok("Categoria Criada");
                }
                else
                {
                    return BadRequest("Ocorreu um erro.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro. \n" + ex.Message);
                throw ex;
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                if (id == null)
                    return BadRequest("Id vazio");

                var categoria = _services.GetById(id);

                if (categoria == null)
                {
                    return NotFound($"Nenhuma categoria para esse Id");
                }

                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro \n" + ex.Message);
                //throw ex;
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var categorias = _services.GetAll<Categoria>();

                if (categorias.Count != 0)
                    return Ok(categorias);

                return NotFound("Sem registros.");

            }
            catch (Exception ex)
            {
                BadRequest("Ocorreu um erro \n" + ex.Message);
                throw ex;
            }
        }

        [HttpPut]
        public IActionResult Update(Categoria categoria)
        {
            try
            {
                if (categoria == null)
                    return BadRequest("Categoria vazio.");

                var cat = _services.Update(categoria);

                if (cat == null)
                    return BadRequest("Ocorreu um erro.");

                return Ok(cat);

            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro. \n" + ex.Message);
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_services.HasProduto(id))
                {
                    _services.Delete(id);
                    return Ok("Categoria Excluida.");
                }
                else
                {

                    return BadRequest("Não é possivel fazer a exclusão, categoria anexada a um produto.");
                }


            }
            catch (Exception ex)
            {
               return BadRequest("Ocorreu um erro \n" + ex.Message);
                //throw ex;
            }
        }

    }
}
