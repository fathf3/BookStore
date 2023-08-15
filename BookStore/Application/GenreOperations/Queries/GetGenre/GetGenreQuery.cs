using AutoMapper;
using BookStore.DbOperations;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Application.GenreOperations.Queries.GetGenre
{
    public class GetGenreQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetGenreQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GeneresViewModel> Handle()
        {
            var genres = _context.Genres.Where(x => x.isActive).OrderBy(x => x.Id);
            List<GeneresViewModel> returnObj = _mapper.Map<List<GeneresViewModel>>(genres);
            return returnObj;   

        }

        public class GeneresViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }





    }
}
