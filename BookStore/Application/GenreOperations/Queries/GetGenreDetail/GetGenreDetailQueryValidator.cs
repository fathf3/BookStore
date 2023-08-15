using FluentValidation;

namespace BookStore.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQueryValidator : AbstractValidator<GetGenreDetailQuery>
    {
        public GetGenreDetailQueryValidator()
        {
            RuleFor(x => x.GenreId).NotEmpty();
            RuleFor(x => x.GenreId).GreaterThan(0);
        }
    }
}
