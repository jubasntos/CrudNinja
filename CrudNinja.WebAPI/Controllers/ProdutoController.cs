using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudNinja.Domain;
using CrudNinja.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudNinja.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        public NinjaContext _context { get; }

        public ProdutoController(NinjaContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetProdutos()
        {
            try
            {
                var results = await _context.Produtos.ToListAsync();
                return Ok(results);
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou !");
            }
            
        }
        

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProdutoId(int id)
        {
             try
            {
                var results = await _context.Produtos.FirstOrDefaultAsync(x => x.ProdutoId == id);
                return Ok(results);
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou !");
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> SalvarProdutoAsync(Produto produto){

            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
            return Ok();
        }
        
        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> AtualizarProdutoAsync (Produto produto){
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
            return Ok();
        }
        

        // DELETE api/values/5
        [HttpDelete("{produtoId}")]
        public async Task<IActionResult> DeletarProdutoAsync (int produtoId){
        
            try
            {
                Produto produto = await _context.Produtos.FindAsync(produtoId);
                _context.Remove(produto);
                var results = await _context.SaveChangesAsync();
                return Ok(results);
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou !");
            }

        }
    }
}
