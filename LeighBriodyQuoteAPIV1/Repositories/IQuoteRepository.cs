using LeighBriodyQuoteAPIV1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeighBriodyQuoteAPIV1.Repositories
{
   public interface IQuoteRepository
    {

        Task<IEnumerable<Quote>> Get();
        Task<Quote> Get(int id);

       Task<IEnumerable<Quote>> GetQuotesOfType(int quoteTypeId);

        Task<Quote> Create(Quote quote);
        Task Update(Quote quote);
        Task Delete(int id);
    }
}
