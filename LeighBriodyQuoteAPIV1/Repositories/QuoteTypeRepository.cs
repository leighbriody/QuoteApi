using LeighBriodyQuoteAPIV1.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeighBriodyQuoteAPIV1.Repositories
{
    public class QuoteTypeRepository : IQuoteTypeRepository
    {

        //We need to inject the context 
        private readonly QuoteContext _context;

        public QuoteTypeRepository(QuoteContext context)
        {
            _context = context;
        }



        //This class is our concrete implementaion of the interface 
        public async Task<QuoteType> Create(QuoteType quoteType)
        {
            _context.QuoteTypes.Add(quoteType);
            await _context.SaveChangesAsync();

            return quoteType;
        }

        public async Task Delete(int id)
        {
            var quoteTypeToDelete = await _context.QuoteTypes.FindAsync(id);
            _context.QuoteTypes.Remove(quoteTypeToDelete);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<QuoteType>> Get()
        {
            return await _context.QuoteTypes.ToListAsync();
        }

        public async Task<QuoteType> Get(int id)
        {
            return await _context.QuoteTypes.FindAsync(id);
        }

        public async Task Update(QuoteType quoteType)
        {
            _context.Entry(quoteType).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        
    }
}
