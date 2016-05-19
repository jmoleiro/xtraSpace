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
    public partial class frmCopy : Form
    {
        public bool _canclose = false;
        
        public frmCopy()
        {
            InitializeComponent();
        }

        private void frmCopy_FormClosing(object sender, FormClosingEventArgs e)
        {
            //
            e.Cancel = !_canclose;
        }
    }
}
