using Microsoft.EntityFrameworkCore;
using OrderApi.Models;
using OrderApi.Repository;

namespace OrderApi.Service
{
    public class OrderService
    {
        OrderContext context;
        public List<Order> orders { get; set; }
        public OrderService(OrderContext context)
        {
            this.context = context;
            ImportFromDB();
        }
        public List<Order> GetAllOrders()
        {
            return context.Orders
                .Include(o => o.OrderDetails)
                .Include(o => o.Client)
                .ToList<Order>();
        }

        public Order GetOrder(int id)
        {
            return context.Orders
                .Include(o => o.OrderDetails)
                .Include(o => o.Client)
                .SingleOrDefault(o => o.OrderNumber == id);
        }
        //添加订单
        public void AddOrder(Order newOrder)
        {
            if (!orders.Contains(newOrder))
            {
                orders.Add(newOrder);
                context.Orders.Add(newOrder);
                context.SaveChanges();
                Console.WriteLine($"Order {newOrder.OrderNumber} has been added.\n");
            }
            else
            {
                throw new ApplicationException($"Order {newOrder.OrderNumber} already exists.\n");
            }
        }
        //删除订单
        public void DeleteOrder(Order order)
        {
            if (order != null)
            {
                orders.Remove(order);
                int id = order.OrderNumber;
                var checkOrder = context.Orders
                    .Include("OrderDetails")
                    .Include("Client")
                    .FirstOrDefault(p => p.OrderNumber == id);
                context.Orders.Remove(checkOrder);
                context.SaveChanges();
                Console.WriteLine($"Order {order.OrderNumber} has been deleted.\n");
            }
            else
            {
                throw new ApplicationException($"Order {order.OrderNumber} not found.\n");
            }
        }
        //修改订单
        public void ModifyOrder(Order modifiedOrder)
        {
            var index = orders.FindIndex(order => order.OrderNumber == modifiedOrder.OrderNumber);
            if (index == -1)
            {
                throw new ApplicationException($"Order {modifiedOrder.OrderNumber} does not exist.\n");
            }
            else
            {
                orders[index] = modifiedOrder;
                int id = modifiedOrder.OrderNumber;
                var checkOrder = context.Orders
                    .Include("OrderDetails")
                    .Include("Client")
                    .FirstOrDefault(p => p.OrderNumber == id);
                if (checkOrder != null)
                {
                    checkOrder.Client = modifiedOrder.Client;
                    checkOrder.CreateTime = modifiedOrder.CreateTime;

                    List<int> IdsToBeDelete = new List<int>();
                    foreach (OrderDetails detail in checkOrder.OrderDetails)
                    {
                        IdsToBeDelete.Add(detail.Index);
                    }
                    foreach (int i in IdsToBeDelete)
                    {
                        var detail = context.OrderDetails.FirstOrDefault(p => p.Index == i);
                        context.OrderDetails.Remove(detail);
                    }
                    foreach (OrderDetails detail in modifiedOrder.OrderDetails)
                    {
                        OrderDetails newDetail = new OrderDetails();
                        newDetail.Index = detail.Index;
                        newDetail.ItemName = detail.ItemName;
                        newDetail.ItemPrice = detail.ItemPrice;
                        newDetail.Quantity = detail.Quantity;
                        checkOrder.OrderDetails.Add(newDetail);
                    }
                }
                context.SaveChanges();
                Console.WriteLine($"Order {modifiedOrder.OrderNumber} has been modified.\n");
            }
        }
        //按照订单号、商品名称、客户、订单金额等进行查询
        public List<Order> QueryOrders(Func<Order, bool> condition)
        {
            return context.Orders
                .Include("OrderDetails")
                .Include("Client")
                .Where(condition)
                .OrderBy(o => o.TotalAmount)
                .ToList();
        }

        public void DisplayOrders()
        {
            Console.WriteLine("Order list:");
            if (orders.Count != 0)
            {
                foreach (var order in orders)
                {
                    Console.WriteLine(order);
                }
            }
            else
            {
                Console.WriteLine("There is no order in the list!\n");
            }
        }
        //从数据库中载入订单
        public void ImportFromDB()
        {
            orders = context.Orders.Include("OrderDetails").Include("Client").ToList();
        }
    }
}
