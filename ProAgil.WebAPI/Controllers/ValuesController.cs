using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProAgil.WebAPI.Data;
using ProAgil.WebAPI.Model;

namespace ProAgil.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        public DataContext _context { get; }

        public ValuesController(DataContext context)
        {
            _context = context;
        }
        //GET api/values
        [HttpGet]
        public async Task<IActionResult> Get() //=> new Evento[] 
        { 
            try
            {
                var results = await _context.Eventos.ToListAsync(); 
                return Ok(results);  
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "DB Connection fail");
            }
            
        }

        //GET api/values/id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)  
        { 
            try
            {
                var result = await _context.Eventos.Where(x => x.EventoId == id).FirstOrDefaultAsync();
                return Ok(result);    
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status404NotFound, "Event not found");
            }
            
        }
    }

}
