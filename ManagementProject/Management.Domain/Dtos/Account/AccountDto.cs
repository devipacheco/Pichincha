using FluentValidation;
using Management.Domain.Dtos.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Dtos.Account
{
    public class AccountDto
    {
        public int Number { get; set; }
        public string Type { get; set; }
        public double Balance { get; set; }
        public bool Status { get; set; }
        public int ClientId { get; set; }

        public class AccountValidator : AbstractValidator<AccountDto>
        {
            public AccountValidator()
            {
                RuleFor(x => x.Number).NotEmpty();
                RuleFor(x => x.Type).NotEmpty();
                RuleFor(x => x.ClientId).NotEmpty().NotEqual(0);
            }
        }
    }
}
