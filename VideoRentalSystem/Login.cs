using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace VideoRentalSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create dictionary to select user
            Dictionary<string, string> Where = new Dictionary<string, string>();

            foreach (var control in Controls)
            {
                if (control is TextBox)
                {
                    TextBox ctrl = control as TextBox;
                    Where.Add(ctrl.Name.ToLower(), ctrl.Text);
                }
            }

            //Call Select method with AND clause
            DataTable data = new Database().SelectAnd("Admin", Where);

            //Check is sent credentials were correct
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

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
