using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoRentalSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> Where = new Dictionary<string, string>();

            foreach (var control in Controls)
            {
                if (control is TextBox)
                {
                    TextBox ctrl = control as TextBox;
                    Where.Add(ctrl.Name.ToLower(), ctrl.Text);
                }
            }

            DataTable data = new Database().SelectAnd("Admin", Where);

            if(data.Rows.Count > 0)
            {
                Dispose();
            }
            else
            {
                MessageBox.Show("Invalid username/ password");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
