using AutoMapper;
using BookStore.DbOperations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace BookStore.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {

        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public int GenreId { get; set; }

        public GetGenreDetailQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GenereDetailViewModel Handle()
        {
            var genre = _context.Genres.SingleOrDefaultAsync(x => x.isActive && x.Id == GenreId);
            if (genre is null)
            {
                throw new InvalidOperationException("Kitap türü bulunamadı");
            }
            return _mapper.Map<GenereDetailViewModel>(genre);
        }

        public class GenereDetailViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }





    }
}
