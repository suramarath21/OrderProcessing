using OrderProcessing.Core.Commands;
using OrderProcessing.Core.Enums;
using OrderProcessing.Core.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OrderProcessing.Core.Managers
{
    public class OrderPaymentsManager : IOrderPaymentsManager
    {
        private readonly Executor _executor;
        public OrderPaymentsManager(Executor executor)
        {
            _executor = executor;
        }

        public async Task ProcessPayment(Order order)
        {
            foreach (Item item in order.Items)
            {
                if (item.Type == ItemType.PhysicalProduct)
                {
                    PackingSlip packingSlip = new PackingSlip() { Order = order };
                    //call shipping handler with packing slip
                    //generate a commission payment
                }
                else if (item.Type == ItemType.Book)
                {
                    //call shipping handler with packing slip
                    //call royalty handler with packing slip
                    //generate a commission payment
                }
                else if (item.Type == ItemType.MemberShip)
                {
                    await _executor.DispatchAsync(new ActivateMemberShipCommand(order.BuyerId));
                }
                else if (item.Type == ItemType.UpgradeMemberShip)
                {
                    await _executor.DispatchAsync(new UpdateMemberShipCommand(order.BuyerId));
                }
                else if (item.Type == ItemType.Video)
                {
                    var items = order.Items;
                    if (item.Name == Constants.Learning_To_Ski)
                        items.ToList().Add(new Item() { Name = Constants.Learning_To_Ski, Quantity = 1, Type = ItemType.Video });

                    order.Items = items;
                    PackingSlip packingSlip = new PackingSlip() { Order = order };
                    //call shipping handler with packing slip
                }
            }
        }
    }
}
