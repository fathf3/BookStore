using AutoMapper;
using BookStore.DbOperations;
using System;
using System.Linq;

namespace BookStore.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public int AuthorId { get; set; }
        public UpdateAuthorModel Model { get; set; }
        private readonly IBookStoreDbContext _context;
        private readonly IMapper mapper;

        public UpdateAuthorCommand(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if(author is null)
            {
                throw new InvalidOperationException("Boy bir yazar bulunamadı.");
            }
            author.BirthDate = Model.BirthDate;
            author.Name = Model.Name;
            _context.SaveChanges();
        }




        public class UpdateAuthorModel
        {
            public string Name { get; set; }
            public DateTime BirthDate { get; set; }
        }


    }
}
