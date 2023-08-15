using BookStore.Application.BookOperations.Queries.GetBookDetail;
using FluentValidation;

namespace BookStore.Application.BookOperations.Queries.GetBooks
{
    public class GetBookDetailQueryValidator : AbstractValidator<GetBookDetailQuery>
    {

        public GetBookDetailQueryValidator()
        {
            RuleFor(q => q.BookId).NotEmpty();
            RuleFor(q => q.BookId).GreaterThan(0);
        }
    }
}
