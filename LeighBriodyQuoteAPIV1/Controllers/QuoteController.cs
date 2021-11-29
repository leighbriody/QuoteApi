using LeighBriodyQuoteAPIV1.Model;
using LeighBriodyQuoteAPIV1.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;

namespace LeighBriodyQuoteAPIV1.Controllers
{
    
 

  
    [Route("api/[controller]")]
    [ApiController]

    public class QuoteController : ControllerBase
    {


        //controller needs an instance of the quote type repository to interact 
        private readonly IQuoteRepository _quoteRepository;

        public QuoteController(IQuoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }


        //now we must implement action methods that will  perform the HTTP Requests 

        [HttpGet]
        public async Task<IEnumerable<Quote>> GetQuotes()
        {
            return await _quoteRepository.Get();
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Quote>> GetQuotes(int id)
        {
            return await _quoteRepository.Get(id);
        }

        //Get quote by quote type id

        [HttpGet("type/{id}")]
        public async Task<IEnumerable<Quote>> GetQuotesOfType( int id)
        {
            return await _quoteRepository.GetQuotesOfType(id);
        }

        //POST

        [HttpPost]
        public async Task<ActionResult<Quote>> PostBooks([FromBody] Quote quote)
        {
            var newQuote = await _quoteRepository.Create(quote);
            return CreatedAtAction(nameof(GetQuotes), new { id = newQuote.id }, newQuote);
        }

        //PUT
        [HttpPut]
        public async Task<ActionResult> PutQuotes(int id, [FromBody] Quote quote)
        {

            if (id != quote.id)
            {
                return BadRequest();
            }


            await _quoteRepository.Update(quote);

            return NoContent();

        }

        //Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var quoteToDelete = await _quoteRepository.Get(id);

            if (quoteToDelete == null)
            {
                return NotFound();
            }

            await _quoteRepository.Delete(quoteToDelete.id);
            return NoContent();
        }







    }
}
