using BookStore.DbOperations;
using System;
using System.Linq;

namespace BookStore.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {

        public int GenreId { get; set; }
        public UpdateGenreModel Model { get; set; }
        private IBookStoreDbContext _context;

        public UpdateGenreCommand(IBookStoreDbContext context)
        {

            _context = context;
        }
        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);
            if (genre is null)
            {
                throw new InvalidOperationException("Kitap türü bulunamadı");
            }
            if (_context.Genres.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Id != GenreId))
            {
                throw new InvalidOperationException("Aynı isimde Kitap türü mevcut");
            }

            genre.Name = Model.Name.Trim() == default ? genre.Name : Model.Name;
            genre.isActive = Model.isActive;
            _context.SaveChanges();
        }


        public class UpdateGenreModel
        {
            public string Name { get; set; }
            public bool isActive { get; set; }

        }
    }
}
