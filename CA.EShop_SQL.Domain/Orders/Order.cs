using CA.EShop_SQL.Domain.Customers;
using CA.EShop_SQL.Domain.IRepositories;
using CA.EShop_SQL.Domain.Orders.DomainEvents;
using CA.EShop_SQL.Domain.Primitives;
using CA.EShop_SQL.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CA.EShop_SQL.Domain.Orders
{
    public class Order : Entity
    {
        private readonly List<LineItem> _l_lineItems = new();

        private Order()
        {
        }

        public ROrderID O_Id { get; private set; }

        public RCstID C_Id { get; private set; }

        public IReadOnlyList<LineItem> ROL_I_LineItems => _l_lineItems.ToList();

        public static Order Create(RCstID c_Id)
        {
            var orderToCreate = new Order
            {
                O_Id = new ROrderID(Guid.NewGuid()),
                C_Id = c_Id
            };
            orderToCreate.Raise(new R_DE_OrderCreated(Guid.NewGuid(), orderToCreate.O_Id));
            return orderToCreate;
        }

        public void Add(RProd_Id prod_Id, RMoney price)
        {
            var lineItemToAdd = new LineItem(
                new RLItemID(Guid.NewGuid()),
                O_Id,
                prod_Id,
                price);
            _l_lineItems.Add(lineItemToAdd);
        }

        public void RemoveLineItem(RLItemID lineItemId, IRep_Order Rep_OrderI)
        {
            if (Rep_OrderI.HasOneLineItem(this))
            {
                return;
            }
            var lineItemToRemove = _l_lineItems.FirstOrDefault(li => li.LI_Id == lineItemId);
            if (lineItemToRemove is null)
            {
                return;
            }
            _l_lineItems.Remove(lineItemToRemove);
            Raise(new R_DE_LItemRemoved(Guid.NewGuid(), O_Id, lineItemToRemove.LI_Id));
        }
    }
}
