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

    [Route("api/product")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ILogger<ProdutoController> _logger;
        private readonly IProdutoService _service;

        public ProdutoController(ILogger<ProdutoController> logger, IProdutoService service)
        {
            this._logger = logger;
            this._service = service;
        }

        [HttpPost()]
        public ActionResult Create(Produto produto)
        {
            try
            {

                if (produto == null)
                    return BadRequest("Produto vazio");

                var produtoNew = _service.Insert(produto);

                if (produtoNew != null)
                {
                    return Ok("Sucess");
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

                var produto = _service.GetById(id);

                if (produto == null)
                {
                    return NotFound($"Produto não encontrado");
                }

                return Ok(produto);
            }
            catch (Exception ex)
            {
               return BadRequest("Ocorreu um erro \n" + ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var products = _service.GetAll<Produto>();

                if (products.Count != 0)
                    return Ok(products);

                return NotFound("Sem registros.");

            }
            catch (Exception ex)
            {
                BadRequest("Ocorreu um erro \n" + ex.Message);
                throw ex;
            }
        }

        [HttpPut]
        public IActionResult Update(Produto produto)
        {
            try
            {
                if (produto == null)
                    return BadRequest("Produto vazio.");

                var produtoNew = _service.Update(produto);

                if (produtoNew == null)
                    return BadRequest("Ocorreu um erro.");

                return Ok(produtoNew);

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
                _service.Delete(id);
                return Ok("Produto Excluido.");

            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro \n" + ex.Message);
            }
        }

    }
}
