using System;
using System.Threading.Tasks;
using Application.Services;
using Core.Domain;
using Core.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Application.Hubs
{
    public class RidesHub : Hub
    {
        private const string UpdateRide = "updateRide";
        private const string RefreshRidesList = "refreshRidesList";
        private readonly IIdentityProvider _identityProvider;
        private readonly IRidesRepository _ridesRepository;

        public RidesHub(IIdentityProvider identityProvider, IRidesRepository ridesRepository)
        {
            _identityProvider = identityProvider;
            _ridesRepository = ridesRepository;
        }

        /// <summary>
        ///     When customer creates or cancels ride, notify all drivers.
        /// </summary>
        [Authorize(Roles = UserRoles.Customer, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task OnRideRequestedOrCanceledByCustomer()
        {
            await Clients.Group(UserRoles.Driver).SendAsync(RefreshRidesList);
        }

        /// <summary>
        ///     When driver accepts requested Ride, notify all drivers and customer.
        /// </summary>
        /// <param name="rideId"></param>
        [Authorize(Roles = UserRoles.Driver, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task OnRideAcceptedByDriver(Guid rideId)
        {
            var ride = await _ridesRepository.GetByIdAsync(rideId);

            await Clients.Groups(UserRoles.Driver, ride.CustomerId).SendAsync(RefreshRidesList);
        }

        /// <summary>
        ///     When driver starts or finishes ride, notify customer.
        /// </summary>
        /// <param name="rideId"></param>
        /// <returns></returns>
        [Authorize(Roles = UserRoles.Driver, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task OnRideStartedOrFinishedByDriver(Guid rideId)
        {
            var ride = await _ridesRepository.GetByIdAsync(rideId);

            await Clients.Group(ride.CustomerId).SendAsync(UpdateRide, rideId);
        }


        public override Task OnConnectedAsync()
        {
            Groups.AddToGroupAsync(Context.ConnectionId, _identityProvider.GetRole());
            Groups.AddToGroupAsync(Context.ConnectionId, _identityProvider.GetUserId());

            return base.OnConnectedAsync();
        }
    }
}