using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace OrderManageWinForm
{
    public partial class AddOrder : Form
    {
        public Order newOrder { get; set; }
        public AddOrder()
        {
            InitializeComponent();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (textClientID.Text == "")
            {
                MessageBox.Show("客户ID不能为空！");
                return;
            }
            if (textClientName.Text == "")
            {
                MessageBox.Show("客户名不能为空！");
                return;
            }
            if (textAddress.Text == "")
            {
                MessageBox.Show("地址不能为空！");
                return;
            }

      //      Client client = new Client(textClientName.Text, textAddress.Text);
          //  Commodity item = new Commodity(int.Parse(colCommodityID), textClientName.Text, textAddress.Text)
         //   newOrder.AddOrderDetails();
            

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
