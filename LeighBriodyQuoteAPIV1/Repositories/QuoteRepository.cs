using LeighBriodyQuoteAPIV1.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeighBriodyQuoteAPIV1.Repositories
{
    public class QuoteRepository : IQuoteRepository
    {

        //inject the quote context trough the constructor
        private readonly QuoteContext _context;

        public QuoteRepository(QuoteContext context)
        {
            _context = context;
        }




        public async Task<Quote> Create(Quote quote)
        {
            _context.Quotes.Add(quote);
            await _context.SaveChangesAsync();

            return quote;
        }

        public async Task Delete(int id)
        {
            var quoteToDelete = await _context.Quotes.FindAsync(id);
            _context.Quotes.Remove(quoteToDelete);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Quote>> Get()
        {
            return await _context.Quotes.ToListAsync();
        }

        //Get all quotes where quote type id = =-
        public async Task<IEnumerable<Quote>> GetQuotesOfType( int id)
        {

            return await _context.Quotes.Where(quote => quote.quoteTypeId == id).ToListAsync();
        }

        public async Task<Quote> Get(int id)
        {
            return await _context.Quotes.FindAsync(id);
        }

      

        public async Task Update(Quote quote)
        {
            _context.Entry(quote).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
