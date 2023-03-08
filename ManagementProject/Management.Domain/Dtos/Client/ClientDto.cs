using FluentValidation;

namespace Management.Domain.Dtos.Client
{
    public class ClientDto
    {
        public string Names { get; set; }
        public string Address { get; set; }
        public string? Genre { get; set; }
        public int? Age { get; set; }
        public string? Identification { get; set; }
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
