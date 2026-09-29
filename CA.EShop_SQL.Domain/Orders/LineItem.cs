using CA.EShop_SQL.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.EShop_SQL.Domain.Orders
{
    public class LineItem
    {
        internal LineItem(RLItemID li_id, ROrderID orderId, RProd_Id prodId, RMoney price)
        {
            LI_Id = li_id;
            OrderId = orderId;
            ProdId = prodId;
            Price = price;
        }

        private LineItem()
        {
        }

        public RLItemID LI_Id { get; private set; }

        public ROrderID OrderId { get; private set; }

        public RProd_Id ProdId { get; private set; }

        public RMoney Price { get; private set; }
    }
}
