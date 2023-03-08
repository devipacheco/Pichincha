using FluentValidation;

namespace Management.Domain.Dtos.Client
{
    public class ClientUpdatedDto
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Identification { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
    }

    public class ClientUpdatedValidator : AbstractValidator<ClientUpdatedDto>
    {
        public ClientUpdatedValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.Phone).NotEmpty();
        }
    }
}
