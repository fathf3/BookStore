
using BookStore.DbOperations;
using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.UnitTests.TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this BookStoreDbContext context)
        {
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
        }
    }
}
