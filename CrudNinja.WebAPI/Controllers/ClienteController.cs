using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudNinja.Repository;
using CrudNinja.Domain;

namespace CrudNinja.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public NinjaContext _context { get; }

        public ClienteController(NinjaContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _context.Clientes.ToListAsync();
                return Ok(results);
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou !");
            }
            
        }
        

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
             try
            {
                var results = await _context.Clientes.FirstOrDefaultAsync(x => x.ClienteId == id);
                return Ok(results);
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou !");
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> SalvarClienteAsync(Cliente cliente){

            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return Ok();
        }
        
        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> AtualizarClienteAsync (Cliente cliente){
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
            return Ok();
        }
        

        // DELETE api/values/5
        [HttpDelete("{clienteId}")]
        public async Task<IActionResult> DeletarClienteAsync (int clienteId){
        
            try
            {
                Cliente cliente = await _context.Clientes.FindAsync(clienteId);
                _context.Remove(cliente);
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
