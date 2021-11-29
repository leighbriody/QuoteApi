using LeighBriodyQuoteAPIV1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeighBriodyQuoteAPIV1.Repositories
{


    /***
     *  Repository is a layer that sits between our application and the data access layer . (Which is the QuoteContext)
     *  
     * Adding a repository is a good practice it helps adding a layer of abstraction between your code and the data
     * access layer
     */

    //This interface will describe what we will do within the data
    public interface IQuoteTypeRepository
    {

        
        Task<IEnumerable<QuoteType>> Get();
        Task<QuoteType> Get(int id);
        Task<QuoteType> Create(QuoteType quoteType);
        Task Update(QuoteType quoteType);
        Task Delete(int id);

    }
}
