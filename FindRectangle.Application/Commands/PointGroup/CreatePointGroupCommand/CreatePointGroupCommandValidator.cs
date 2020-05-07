using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FindRectangle.Application.Commands
{
  public class CreatePointCommandValidator :  AbstractValidator<CreatePointGroupCommand>
  {
    public CreatePointCommandValidator()
    {
      RuleFor(s=>s.Title).NotNull().NotEmpty();
    }
  }
}
