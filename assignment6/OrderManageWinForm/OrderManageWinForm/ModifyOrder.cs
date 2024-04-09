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
    public partial class ModifyOrder : Form
    {
        public Order modifiedOrder { get; set; }
        public ModifyOrder()
        {
            InitializeComponent();
        }
    }
}
