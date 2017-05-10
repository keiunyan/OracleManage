using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OracleManage
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void menuTest_Click(object sender, EventArgs e)
        {
            OnTest();
        }

        private void OnTest()
        {
            OPanel p = new OPanel("system", "oracle", "192.168.100.100/test");
            p.Open();
            //p.Dispose();
        }
    }
}
