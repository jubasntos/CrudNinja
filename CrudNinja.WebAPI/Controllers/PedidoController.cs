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
    public class PedidoController : ControllerBase
    {
        public NinjaContext _context { get; }

        public PedidoController(NinjaContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetPedidos()
        {
            try
            {
                var results = await _context.Pedidos.ToListAsync();
                return Ok(results);
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou !");
            }
            
        }
        

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPedidoId(int id)
        {
             try
            {
                var results = await _context.Pedidos.FirstOrDefaultAsync(x => x.PedidoId == id);
                return Ok(results);
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou !");
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> SalvarPedidoAsync(Pedido pedido){

            await _context.Pedidos.AddAsync(pedido);
            await _context.SaveChangesAsync();
            return Ok();
        }
        
        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> AtualizarPedidoAsync (Pedido pedido){
            _context.Pedidos.Update(pedido);
            await _context.SaveChangesAsync();
            return Ok();
        }
        

        // DELETE api/values/5
        [HttpDelete("{pedidoId}")]
        public async Task<IActionResult> DeletarPedidoAsync (int pedidoId){
        
            try
            {
                Pedido pedido = await _context.Pedidos.FindAsync(pedidoId);
                _context.Remove(pedido);
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
