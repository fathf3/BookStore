using BookStore.DbOperations;
using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.UnitTests.TestSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDbContext context)
        {
            context.Books.AddRange(
                   new Book
                   {
                       //Id=1,
                       Title = "Lean Startup",
                       GenreId = 1,
                       PageCount = 200,
                       PublishDate = new DateTime(2001, 06, 12),
                       AuthorId = 1,
                   },
                   new Book
                   {
                       //Id=2,
                       Title = "Herland",
                       GenreId = 2,
                       PageCount = 250,
                       PublishDate = new DateTime(2010, 05, 23),
                       AuthorId = 2,
                   },
                   new Book
                   {
                       //Id=3,
                       Title = "Dune",
                       GenreId = 2,
                       PageCount = 540,
                       PublishDate = new DateTime(2002, 12, 21),
                       AuthorId = 2,
                   },
                   new Book
                   {
                       // Id=4,
                       Title = "The Murder Room: In which Three of the Greatest Detectives Use Forensic Science to Solve the World's Most Perplexing Cold Cases",
                       GenreId = 3,
                       PageCount = 464,
                       PublishDate = new DateTime(2009, 01, 01),
                       AuthorId = 3,
                   }
               );
        }
    }
}
