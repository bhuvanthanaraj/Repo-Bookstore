using bookapi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bookapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class dashboardController : ControllerBase
    {


        private readonly bookdetailsContext _context;

        public dashboardController(bookdetailsContext context)
        {
            _context = context;
        }





        //  Get() Start 


        [EnableCors()]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booklist>>> Get()
        {
            var book = await _context.Booklists.ToListAsync();
            return Ok(book);
        }


        //  End 




        //  Get() by ID   Start  


        [EnableCors()]
        [HttpGet("{Bookid}")]
        public async Task<ActionResult> GetById(int Bookid)
        {
            var bookid = await _context.Booklists.FindAsync(Bookid);
            if (bookid == null)
            {
                return NotFound();
            }
            return Ok(bookid);
        }


        //  End  





        //  Post() start


        [EnableCors()]
        [HttpPost]
        public async Task<ActionResult<Booklist>> Postbook(Booklist addbook)
        {
            _context.Booklists.Add(addbook);
            await _context.SaveChangesAsync();

            return Ok(addbook);

        }

        //  End



        //  Delete() start

        [EnableCors()]
        [HttpDelete("{Bookid}")]
        public async Task<ActionResult<Booklist>> DeleteProduct(int Bookid)
        {
            var deletebook = await _context.Booklists.FindAsync(Bookid);
            if (deletebook == null)
            {
                return NotFound();
            }

            _context.Booklists.Remove(deletebook);
            await _context.SaveChangesAsync();

            return deletebook;
        }


        // End



        // Put() start


        [EnableCors()]
        [HttpPut("{Bookid}")]
        public async Task<ActionResult> PutProduct(int Bookid, Booklist book)
        {
            if (Bookid != book.Bookid)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Booklists.Any(f => f.Bookid == Bookid))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }



        // End





    }
}
