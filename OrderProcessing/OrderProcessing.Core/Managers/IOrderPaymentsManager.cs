using OrderProcessing.Core.Models;
using System.Threading.Tasks;

namespace OrderProcessing.Core.Managers
{
    public interface IOrderPaymentsManager
    {
        Task ProcessPayment(Order order);
    }
}
