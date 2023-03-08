using FluentValidation;

namespace Management.API.Dtos
{
    public class ClientDto
    {
        public string Names { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
    }

    public class ClientValidator : AbstractValidator<ClientDto>
    {
        public ClientValidator()
        {
            RuleFor(x => x.Names).NotEmpty();
        }
    }
}
