using FluentValidation;

namespace BookStore.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {


        public UpdateBookCommandValidator()
        {
            RuleFor(c => c.BookId).NotEmpty();
            RuleFor(c => c.BookId).GreaterThan(0);
            RuleFor(c => c.Model.Title).NotEmpty();
            RuleFor(c => c.Model.Title).MinimumLength(2);
            RuleFor(c => c.Model.GenreId).GreaterThan(0);
            RuleFor(c => c.Model.GenreId).NotEmpty();

        }

    }
}
