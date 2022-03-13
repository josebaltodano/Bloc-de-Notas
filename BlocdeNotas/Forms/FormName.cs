using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlocdeNotas.Forms;

namespace BlocdeNotas.Forms
{
    public partial class FormName : Form
    {
        public FormName()
        {
            InitializeComponent();
        }
        public string b = "";
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            FormBloc form = new FormBloc(txbName.Text);
            b = txbName.Text;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
