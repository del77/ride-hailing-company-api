using System;
using MediatR;

namespace Application.Users.Commands
{
    public class RegisterAccount : IRequest<string>
    {
        public string Username { get; }
        public string Password { get; }
        public string Email { get; }
    }
    
    
}