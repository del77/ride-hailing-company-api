using MediatR;

namespace Application.Users.Commands
{
    public class LoginCommand : IRequest<string>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}