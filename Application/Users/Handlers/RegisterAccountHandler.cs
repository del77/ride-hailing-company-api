using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Services;
using Application.Users.Commands;
using AutoMapper;
using Core.Domain;
using Core.Domain.Customers;
using Core.Repositories;
using MediatR;

namespace Application.Users.Handlers
{
    public class RegisterAccountHandler : IRequestHandler<RegisterAccountCommand, string>
    {
        private readonly IMapper _mapper;
        private readonly IIdentityService _identityService;
        private readonly ICustomersRepository _customersRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterAccountHandler(IMapper mapper, IIdentityService identityService, ICustomersRepository customersRepository,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _identityService = identityService;
            _customersRepository = customersRepository;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<string> Handle(RegisterAccountCommand command, CancellationToken cancellationToken)
        {
            var userId = await _identityService.AddUserAsync(command.Username, command.Email, command.Password,
                new[] {UserRoles.Customer});

            var customer = new Customer(userId);
            await _customersRepository.AddAsync(customer);

            await _unitOfWork.SaveAsync();

            return userId;
        }
    }
}