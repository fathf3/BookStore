using AutoMapper;
using BookStore.Common;
using BookStore.DbOperations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.TestsSetup
{
    public class CommonTestFixture
    {
        public BookStoreDbContext DbContext { get; set; }
        public IMapper Mapper { get; set; }

        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<BookStoreDbContext>().UseInMemoryDatabase(databaseName: "BookStoreTestDB").Options;
            DbContext = new BookStoreDbContext(options);
            DbContext.Database.EnsureCreated();
            DbContext.AddBooks();
            DbContext.AddGenres();  
            DbContext.SaveChanges();

            Mapper = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); }).CreateMapper();

        }

    }
}
