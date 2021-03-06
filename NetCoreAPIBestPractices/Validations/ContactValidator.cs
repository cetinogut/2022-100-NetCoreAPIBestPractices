using FluentValidation;
using NetCoreAPIBestPractices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAPIBestPractices.Validations
{
    public class ContactValidator : AbstractValidator<ContactDVO>
    {
        public ContactValidator()
        {
            RuleFor(i => i.FullName).NotEmpty().WithMessage("full name cannot be empty");
            RuleFor(x => x.Id).LessThan(100).WithMessage("Id cannot be greater than 100");
        }
    }
}
