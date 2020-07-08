using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Services;
using Application.Users.Commands;
using MediatR;

namespace Application.Users.Handlers
{
    public class LoginHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IIdentityService _identityService;

        public LoginHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        
        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var token = await _identityService.LoginAsync(request);
            
            if(token is null)
                throw new Exception("invalid username or password");

            return token;
        }
    }
}