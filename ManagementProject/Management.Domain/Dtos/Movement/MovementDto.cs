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

        public class MovementValidator : AbstractValidator<MovementDto>
        {
            public MovementValidator()
            {

            }
        }
    }
}
