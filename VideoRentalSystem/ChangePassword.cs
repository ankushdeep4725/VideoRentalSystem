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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(username.Text == "" || oldpassword.Text == "" || password.Text == "" || confirmpassword.Text == "")
            {
                MessageBox.Show("All fields are mandatory");
            }
            else if(password.Text != confirmpassword.Text)
            {
                MessageBox.Show("New Password and Confirm Password must match");
            }
            else
            {
                Dictionary<string, string> Where = new Dictionary<string, string>();
                Where.Add("username", username.Text);
                Where.Add("password", oldpassword.Text);

                DataTable data = new Database().SelectAnd("Admin", Where);

                if(data.Rows.Count > 0)
                {
                    Dictionary<string, string> Data = new Dictionary<string, string>();
                    Data.Add("password", password.Text);

                    Where = new Dictionary<string, string>();
                    Where.Add("username", username.Text);

                    new Database().Update("Admin", Data, Where);

                    MessageBox.Show("Password Updated Successfully");
                    Dispose();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password");
                }
            }

            Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
