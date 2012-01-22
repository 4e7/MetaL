using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetaLSyntaxAnalizator;
namespace GuiTest
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void pbGo_Click(object sender, EventArgs e)
        {
            tbErrors.Text = "";
            Analizator a = new Analizator();
            tbAsm.Text = a.parse(tbSource.Text);
            foreach (string s in a.errorMessages())
            {
                tbErrors.Text += s+"\n";
            }
        }
    }
}
