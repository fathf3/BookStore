using AutoMapper;
using BookStore.DbOperations;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookStore.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public int AuthorId { get; set; }
        public GetAuthorDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public AuthorDetailViewModel Handle()
        {
            var author = _context.Authors.SingleOrDefaultAsync(x => x.Id == AuthorId);
            if (author is null)
            {
                throw new InvalidOperationException("Yazar bulunamadı");
            }
            return _mapper.Map<AuthorDetailViewModel>(author);
        }

        public class AuthorDetailViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime BirthDate { get; set; }
        }

    }
}
