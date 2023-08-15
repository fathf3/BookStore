using BookStore.DbOperations;
using BookStore.Entities;
using System;
using System.Linq;

namespace BookStore.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        public int AuthorId { get; set; }
        private readonly BookStoreDbContext _context;

        public DeleteAuthorCommand(BookStoreDbContext context)
        {
            
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if(author is null)
            {
                throw new InvalidOperationException("Boyle bir yazar bulunamadı");
            }
            if (_context.Books.Any(x => x.AuthorId == AuthorId)){
                throw new InvalidOperationException("Yazar a ait kitap oldugu icin islem yapılamadı.");
            }
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }

    }
}
