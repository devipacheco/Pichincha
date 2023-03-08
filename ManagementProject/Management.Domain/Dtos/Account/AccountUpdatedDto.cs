using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Dtos.Account
{
    public class AccountUpdatedDto
    {
        public string Number { get; set; }
        public string Type { get; set; }
        public double Balance { get; set; }
        public bool Status { get; set; }

        public class AccountUpdatedValidator : AbstractValidator<AccountUpdatedDto>
        {
            public AccountUpdatedValidator()
            {
                RuleFor(x => x.Number).NotEmpty();
                RuleFor(x => x.Type).NotEmpty();
                RuleFor(x => x.Balance).NotEmpty();
            }
        }
    }
}
