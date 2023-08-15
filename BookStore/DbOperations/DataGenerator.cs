using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using Microsoft.Extensions.DependencyInjection;
using BookStore.Entities;

namespace BookStore.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "PersonalGrowth",
                    },
                    new Genre
                    {
                        Name = "ScienceFiction",
                    },
                    new Genre
                    {
                        Name = "TrueCrime",
                    },
                     new Genre
                     {
                         Name = "Noval",
                     }
                    );

                context.Authors.AddRange(
                    new Author
                    {
                        Name = "Fatih",
                        BirthDate = new DateTime(1989, 06, 15),
                    },
                    new Author
                      {
                          Name = "Stephan",
                          BirthDate = new DateTime(1966, 11, 20),
                      },
                    new Author
                        {
                            Name = "Ahmet",
                            BirthDate = new DateTime(1997, 08, 03),
                        }
                    );

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
                context.SaveChanges();
            }
        }
    }
}
