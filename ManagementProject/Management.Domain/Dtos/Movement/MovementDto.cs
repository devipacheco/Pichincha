using FluentValidation;
using Management.Domain.Dtos.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Dtos.Movement
{
    public class MovementDto
    {
        public int AccountId { get; set; }
        public int MovementType { get; set; }
        public double Import { get; set; }
        public bool Status { get; set; }

        public class MovementValidator : AbstractValidator<MovementDto>
        {
            public MovementValidator()
            {
                RuleFor(x => x.MovementType).NotEmpty();
                RuleFor(x => x.Import).NotEmpty().NotEqual(0);
                RuleFor(x => x.AccountId).NotEmpty().NotEqual(0);
            }
        }
    }
}
