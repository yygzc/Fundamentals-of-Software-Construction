/*
 * 为订单管理的程序添加一个WinForm的界面。通过这个界面，调用OrderService的各个方法
 * 实现创建订单、删除订单、修改订单、查询订单等功能
要求：
（1）WinForm的界面部分单独写一个项目，依赖于原来的项目。
（2）可以使用两个窗口。主窗口实现查询展示功能，以及放置各种功能按钮。新建/修改订单功能使用弹出窗口。
（3）注意窗口的布局，在窗口尺寸变化时，不出现错位挤压等情况。
（4）尽量通过数据绑定来实现功能。订单和订单明细各使用一个bindingsource，通过DataMember来实现主从对象绑定。
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.IO;
using Mysqlx.Crud;
using System.Runtime.Remoting.Contexts;
using Org.BouncyCastle.Asn1.X509;

namespace OrderManageWinForm
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new OrderManagement());
        }
    }
    //订单类：订单号、订单细节、总金额
    public class Order
    {
        [Key]
        public int OrderNumber { get; set; }
        public Client Client { get; set; }
        [Required]
        public string ClientName { get => (Client != null) ? Client.ClientName : ""; }
        public List<OrderDetails> OrderDetails { get; set; }
        public DateTime CreateTime { get; set; }
        public double TotalAmount => OrderDetails.Sum(detail => detail.Amount);

        public Order() 
        { 
            OrderDetails = new List<OrderDetails>(); CreateTime = DateTime.Now; 
        }
        public Order(int orderNumber, Client client)
        {
            OrderNumber = orderNumber;
            OrderDetails = new List<OrderDetails>();
            Client = client;
            CreateTime = DateTime.Now;
        }
        //添加订单细节
        public void AddOrderDetails(OrderDetails detail)
        {
            if (!OrderDetails.Contains(detail))
            {
                OrderDetails.Add(detail);
                using (var context = new OrderContext())
                {
                    context.OrderDetails.Add(detail);
                    context.SaveChanges();
                }
            }
        }
        //显示订单信息
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Order Number: {OrderNumber}");
            sb.AppendLine("Order Details:");
            foreach (var detail in OrderDetails)
            {
                sb.AppendLine(detail.ToString());
            }
            sb.AppendLine($"Total Amount: {TotalAmount:C}");
            return sb.ToString();
        }
        //重写Equals方法，确保添加的订单不重复
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Order other = (Order)obj;
            return OrderNumber == other.OrderNumber;
        }
    }
    //订单细节类：客户、商品
    public class OrderDetails
    {
        [Key]
        public int Index { get; set; } //序号
        public string ItemName { get; set; }
        [Required]
        public double ItemPrice { get; set; }
        public int Quantity { get; set; }

        public int OrderNumber { get; set; } //自动识别为外键
        public Order Order { get; set; } //多对一关联

        public OrderDetails() { }
        public OrderDetails(int index, string itemName, double itemPrice, int quantity)
        {
            Index = index;
            ItemName = itemName;
            ItemPrice = itemPrice;
            Quantity = quantity;
        }
        public double Amount { get => ItemPrice * Quantity; }
        //确保添加的每个订单的订单明细不重复
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            OrderDetails other = (OrderDetails)obj;
            return ItemName.Equals(other.ItemName);
        }
        public override string ToString()
        {
            return $"Commodity Name: {ItemName}" + $"Quantity: {Quantity}" + $"Amount: {Amount}C";
        }
    }
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        public string ClientName { get; set; }

        [Required]
        public string Address { get; set; }

        public Client() { }
        public Client(int clientId, string name, string address)
        {
            ClientId = clientId;
            ClientName = name;
            Address = address;
        }

        public override string ToString()
        {
            return $"Client ID: {ClientId}, Name: {ClientName}, Address: {Address}\n";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Client other = (Client)obj;
            return ClientId == other.ClientId;
        }
    }

    public class OrderService
    {
        public List<Order> orders { get; set; }

        public OrderService()
        {
            //orders = new List<Order>();
            ImportFromDB();
        }
        //添加订单
        public void AddOrder(Order newOrder)
        {
            if (!orders.Contains(newOrder))
            {
                orders.Add(newOrder);
                using (var context = new OrderContext())
                {
                    context.Orders.Add(newOrder);
                    context.SaveChanges();
                }
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
                using (var context = new OrderContext())
                {
                    var checkOrder = context.Orders.Include("OrderDetails").Include("Client").FirstOrDefault(p => p.OrderNumber == id);
                    context.Orders.Remove(checkOrder);
                    context.SaveChanges();
                }
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
                using (var context = new OrderContext())
                {
                    var checkOrder = context.Orders.Include("OrderDetails").Include("Client").FirstOrDefault(p => p.OrderNumber == id);
                    if(checkOrder != null)
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
                }
                Console.WriteLine($"Order {modifiedOrder.OrderNumber} has been modified.\n");
            }
        }
        //按照订单号、商品名称、客户、订单金额等进行查询
        public List<Order> QueryOrders(Func<Order, bool> condition)
        {
            using (var context = new OrderContext())
            {
                return context.Orders.Include("OrderDetails").Include("Client").Where(condition).OrderBy(o => o.TotalAmount).ToList();
            }
            
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
            using (var context = new OrderContext())
            {
                orders = context.Orders.Include("OrderDetails").Include("Client").ToList();
            }
        }
    }
}
