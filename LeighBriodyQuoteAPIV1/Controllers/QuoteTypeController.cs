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

    public class QuoteTypeController : ControllerBase
    {

        //controller needs an instance of the quote type repository to interact 
        private readonly IQuoteTypeRepository _quoteTypeRepository;

        public QuoteTypeController(IQuoteTypeRepository quoteTypeRepository)
        {
            _quoteTypeRepository = quoteTypeRepository;
        }

        /*
         * 
         *    Task<IEnumerable<QuoteType>> Get();
        Task<QuoteType> Get(int id);
        Task<QuoteType> Create(QuoteType quoteType);
        Task Update(QuoteType quoteType);
        Task Delete(int id);
         * 
         * 
         */

        //Here we have all the http methods
        //Task<IEnumerable<QuoteType>> Get();
        [HttpGet]
        public async Task<IEnumerable<QuoteType>> GetQuoteTypes()
        {
            return await _quoteTypeRepository.Get();
        }

        // Task<QuoteType> Get(int id);
        [HttpGet("{id}")]
        public async Task<ActionResult<QuoteType>> GetQuoteType(int id)
        {
            return await _quoteTypeRepository.Get(id);
        }

        // Task<QuoteType> Create(QuoteType quoteType);
        [HttpPost]
        public async Task<ActionResult<QuoteType>> PostQuoteType([FromBody] QuoteType quoteType)
        {
            var newQuoteType = await _quoteTypeRepository.Create(quoteType);
            return CreatedAtAction(nameof(GetQuoteTypes), new { id = newQuoteType.Id }, newQuoteType);
        }


        // Task Update(QuoteType quoteType);
        [HttpPut]
        public async Task<ActionResult> PutQuoteTypes(int id, [FromBody] QuoteType quoteType)
        {

            if (id != quoteType.Id)
            {
                return BadRequest();
            }


            await _quoteTypeRepository.Update(quoteType);

            return NoContent();

        }

        //  Task Delete(int id);
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var quoteTypeToDelete = await _quoteTypeRepository.Get(id);

            if (quoteTypeToDelete == null)
            {
                return NotFound();
            }

            await _quoteTypeRepository.Delete(quoteTypeToDelete.Id);
            return NoContent();
        }


    }
}
