using MediatR;

namespace Application.Customers.Commands
{
    public class AddOpinionForDriverCommand : IRequest
    {
        public string DriverId { get; set; }
        public int Value { get; set; }
        public string? Description { get; set; }
    }
}