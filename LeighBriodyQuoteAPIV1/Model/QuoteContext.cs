using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeighBriodyQuoteAPIV1.Model
{
    public class QuoteContext : DbContext
    {
        //constructor takes a db context object as a paramater 
        //This object is a config of the context , it will be injected trough dependancy injections
        public QuoteContext(DbContextOptions<QuoteContext> options)
            :base(options)
        {
            //To make sure the database is created 
            Database.EnsureCreated();
        }

        //Now we must add the db set property that represents a collection of tables 

        //Create our quote types
        public DbSet<QuoteType> QuoteTypes { get; set; }

        //Create the quotes
        public DbSet<Quote> Quotes { get; set; }

    }
}
