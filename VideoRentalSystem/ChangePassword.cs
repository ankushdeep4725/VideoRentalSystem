using System;
using System.Collections.Generic;
using System.Data;
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
            //Check if all fields are filled
            if (username.Text == "" || oldpassword.Text == "" || password.Text == "" || confirmpassword.Text == "")
            {
                MessageBox.Show("All fields are mandatory");
            }
            //Check if new password is confirmed
            else if(password.Text != confirmpassword.Text)
            {
                MessageBox.Show("New Password and Confirm Password must match");
            }
            else
            {
                //Create Dictionary to check old password
                Dictionary<string, string> Where = new Dictionary<string, string>();
                Where.Add("username", username.Text);
                Where.Add("password", oldpassword.Text);

                //Check if old password is valid
                DataTable data = new Database().SelectAnd("Admin", Where);

                if(data.Rows.Count > 0)
                {
                    //Create Dictionary to update password
                    Dictionary<string, string> Data = new Dictionary<string, string>();
                    Data.Add("password", password.Text);

                    Where = new Dictionary<string, string>();
                    Where.Add("username", username.Text);

                    //Call the update function
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
