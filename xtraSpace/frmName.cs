using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xtraSpace
{
    public partial class frmName : Form
    {
        public string _name;
        
        public frmName()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _name = textBox1.Text;
        }

        private void frmName_Load(object sender, EventArgs e)
        {

        }

        private void frmName_Shown(object sender, EventArgs e)
        {
            textBox1.Text = _name;
            textBox1.SelectionStart = textBox1.Text.Length;
        }
    }
}
