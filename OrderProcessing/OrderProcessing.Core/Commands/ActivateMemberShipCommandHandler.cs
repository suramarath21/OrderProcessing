using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace OrderProcessing.Core.Commands
{
    /// <summary>
    /// Activate membership command
    /// </summary>
    public class ActivateMemberShipCommand : IRequest<CommandResult>
    {
        public string BuyerId { get; set; }

        public ActivateMemberShipCommand(string buyerId)
        {
            BuyerId = buyerId;
        }
    }

    /// <summary>
    /// Handle Activate membership functionality
    /// </summary>
    public class ActivateMemberShipCommandHandler : IRequestHandler<ActivateMemberShipCommand, CommandResult>
    {
        public ActivateMemberShipCommandHandler()
        { 
        }

        public async  Task<CommandResult> Handle(ActivateMemberShipCommand request, CancellationToken cancellationToken)
        {
            //add membership
            //update expire date
            //after success send message to service bus to fire email

            return CommandResult.Success;
        }
    }
}
