using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Dtos.Movement
{
    public class MovementUpdatedDto
    {

        public class MovementUpdatedValidator : AbstractValidator<MovementUpdatedDto>
        {
            public MovementUpdatedValidator()
            {

            }
        }
    }
}
