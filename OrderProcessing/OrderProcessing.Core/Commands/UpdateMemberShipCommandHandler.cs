using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace OrderProcessing.Core.Commands
{
    public class UpdateMemberShipCommand : IRequest<CommandResult>
    {
        public string BuyerId { get; set; }

        public UpdateMemberShipCommand(string buyerId)
        {
            BuyerId = buyerId;
        }
    }

    /// <summary>
    /// Handle update membership functionality
    /// </summary>
    public class UpdateMemberShipCommandHandler : IRequestHandler<UpdateMemberShipCommand, CommandResult>
    {
        public UpdateMemberShipCommandHandler()
        {
        }

        public async Task<CommandResult> Handle(UpdateMemberShipCommand request, CancellationToken cancellationToken)
        {
            //update expiry date
            //after success send message to service bus to fire email

            return CommandResult.Success;
        }
    }
}
