using FluentValidation;
using System;

namespace BookStore.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty()
                .MinimumLength(1)
                .NotNull()
                .MaximumLength(40);
            RuleFor(x => x.Model.BirthDate).NotEmpty()
                .NotNull();
        }

    }
}
