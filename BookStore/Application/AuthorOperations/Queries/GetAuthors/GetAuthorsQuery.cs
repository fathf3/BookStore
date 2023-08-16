using AutoMapper;
using BookStore.DbOperations;
using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using static BookStore.Application.GenreOperations.Queries.GetGenre.GetGenreQuery;

namespace BookStore.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorsQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public List<AuthorViewModel> Handle()
        {
            var authors = _context.Authors.ToList();
            List<AuthorViewModel> returnObj = _mapper.Map<List<AuthorViewModel>>(authors);
            return returnObj;

        }

        public class AuthorViewModel
        {
            public string Name { get; set; }
            public DateTime BirthDate { get; set; }
        }
    }
}
