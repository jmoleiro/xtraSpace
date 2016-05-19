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
    public partial class frmEditor : Form
    {

        public string _name = "";
        public string _content = "";
        
        public frmEditor()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _name = textBox1.Text;
            _content = textBox2.Text;
        }

        private void frmEditor_Shown(object sender, EventArgs e)
        {
            textBox1.Text = _name;
            textBox2.Text = _content;
        }
    }
}
