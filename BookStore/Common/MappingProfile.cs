using AutoMapper;
using BookStore.Application.BookOperations.Commands.UpdateBook;
using BookStore.Application.BookOperations.Queries.GetBookDetail;
using BookStore.Application.BookOperations.Queries.GetBooks;
using BookStore.Entities;
using static BookStore.Application.AuthorOperations.Commands.CreateAuthor.CreateAuthorCommand;
using static BookStore.Application.AuthorOperations.Queries.GetAuthors.GetAuthorsQuery;
using static BookStore.Application.BookOperations.Commands.CreateBook.CreateBookCommand;
using static BookStore.Application.GenreOperations.Queries.GetGenre.GetGenreQuery;
using static BookStore.Application.GenreOperations.Queries.GetGenreDetail.GetGenreDetailQuery;

namespace BookStore.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>().ReverseMap();
            CreateMap<UpdateBookModel, Book>().ReverseMap();
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name));
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name));

            CreateMap<Genre, GeneresViewModel>();
            CreateMap<Genre, GenereDetailViewModel>();

            CreateMap<Author, CreateAuthorModel>().ReverseMap();
            CreateMap<Author, AuthorViewModel>().ReverseMap();

        }
    }
}
