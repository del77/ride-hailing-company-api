using MediatR;

namespace Application.Users.Commands
{
    public class RegisterAccountCommand : IRequest<string>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}