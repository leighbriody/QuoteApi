using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeighBriodyQuoteAPIV1.Model
{
    public class Quote
    {

        public int id { get; set; }

        public string Author { get; set; }

        public string QuoteText { get; set; }

        public string ImageUrl { get; set; }


        //public QuoteType quoteType { get; set; }

        public int quoteTypeId { get; set; }

        internal Task<IEnumerable<Quote>> ToListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
