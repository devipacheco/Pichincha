using FluentValidation;

namespace Management.API.Dtos
{
    public class PersonDto
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Age { get; set; }
        public string Identification { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }

    public class PersonValidator : AbstractValidator<PersonDto>
    {
        public PersonValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
