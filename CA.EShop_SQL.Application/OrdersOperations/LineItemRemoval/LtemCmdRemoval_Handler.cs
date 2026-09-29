using CA.EShop_SQL.Application.IDatabase;
using CA.EShop_SQL.Domain.IRepositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CA.EShop_SQL.Application.OrdersOperations.LineItemRemoval
{
    internal sealed class LtemCmdRemoval_Handler : IRequestHandler<RLineItemCmdRemoval>
    {
        private readonly IRep_Order _repOrderI;
        private readonly IUnitOfWork _unitOfWorkI;

        public LtemCmdRemoval_Handler(
            IRep_Order RepOrderI,
            IUnitOfWork UnitOfWorkI)
        {
            _repOrderI = RepOrderI;
            _unitOfWorkI = UnitOfWorkI;
        }

        public async Task Handle(RLineItemCmdRemoval LICRemoval_Request, CancellationToken CToken)
        {
            var orderToGet = await _repOrderI.GetByIdWithLineItemAsync(
                LICRemoval_Request.O_Id,
                LICRemoval_Request.LI_Id);
            if (orderToGet is null)
            {
                return;
            }
            orderToGet.RemoveLineItem(LICRemoval_Request.LI_Id, _repOrderI);
            await _unitOfWorkI.SaveChangesAsync(CToken);
        }
    }
}
