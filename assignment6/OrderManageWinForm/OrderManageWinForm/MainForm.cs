using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderManageWinForm
{
    public partial class OrderManagement : Form
    {
        public OrderService orderService;

        public OrderManagement()
        {
            InitializeComponent();
        }

        private void buttonAddOrder_Click(object sender, EventArgs e)
        {
            AddOrder addOrder = new AddOrder();
            if (addOrder.ShowDialog() == DialogResult.OK)
            {
                orderService.AddOrder(addOrder.newOrder);
                orderBindingSource.DataSource = orderService.orders;
                orderBindingSource.ResetBindings(false);
            }
        }

        private void buttonModifyOrder_Click(object sender, EventArgs e)
        {
            ModifyOrder modifyOrder = new ModifyOrder();
            if (modifyOrder.ShowDialog() == DialogResult.OK)
            {
                orderService.ModifyOrder(modifyOrder.modifiedOrder);
                orderBindingSource.DataSource = orderService.orders;
                orderBindingSource.ResetBindings(false);
            }
        }

        private void buttonDisplayOrder_Click(object sender, EventArgs e)
        {
            orderBindingSource.DataSource = orderService.orders;
            orderBindingSource.ResetBindings(false);
        }

        private void buttonDeleteOrder_Click(object sender, EventArgs e)
        {
            orderService.DeleteOrder(orderBindingSource.Current as Order);
            orderBindingSource.ResetBindings(false);
        }

        private void comboBoxQueryOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxQueryOrder.SelectedIndex)
            {
                case 0:
                    queryText.DataBindings.Clear();
                    queryText.DataBindings.Add("Text", this, "QueryByOrderNumber");
                    break;
                case 1:
                    queryText.DataBindings.Clear();
                    queryText.DataBindings.Add("Text", this, "QueryByClientName");
                    break;
                case 2:
                    queryText.DataBindings.Clear();
                    queryText.DataBindings.Add("Text", this, "QueryByCommodityName");
                    break;
                case 3:
                    queryText.DataBindings.Clear();
                    queryText.DataBindings.Add("Text", this, "QueryByTotalAmount");
                    break;
                default:
                    break;
            }
        }

        private void buttonQueryOrder_Click(object sender, EventArgs e)
        {
            List<Order> newList;
            switch (comboBoxQueryOrder.SelectedIndex)
            {
                case 0:
                    newList = orderService.QueryOrders(o => o.OrderNumber==int.Parse(queryText.Text));
                    orderBindingSource.DataSource = newList;
                    orderBindingSource.ResetBindings(false);
                    break;
                case 1:
                    newList = orderService.QueryOrders(o => o.ClientName == queryText.Text);
                    orderBindingSource.DataSource = newList;
                    orderBindingSource.ResetBindings(false);
                    break;
                case 2:
                    newList = orderService.QueryOrders(o => o.OrderDetails.Any(
                        detail => detail.Commodity.CommodityName == queryText.Text));
                    orderBindingSource.DataSource = newList;
                    orderBindingSource.ResetBindings(false);
                    break;
                case 3:
                    newList = orderService.QueryOrders(o => o.TotalAmount==double.Parse(queryText.Text));
                    orderBindingSource.DataSource = newList;
                    orderBindingSource.ResetBindings(false);
                    break;
                default:
                    break;
            }
        }
    }
}
