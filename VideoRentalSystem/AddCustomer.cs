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
    public partial class AddCustomer : Form
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if(FirstName.Text == "" || LastName.Text == "" || Address.Text == "" || Phone.Text == "")
            {
                MessageBox.Show("All fields are required");
            }
            else
            {
                Dictionary<string, string> customer = new Dictionary<string, string>();

                foreach (var control in Controls)
                {
                    if(control is TextBox)
                    {
                        TextBox ctrl = control as TextBox;
                        customer.Add(ctrl.Name, ctrl.Text);
                    }
                }
                
                new Database().Insert("Customer", customer);

                MessageBox.Show("Customer Added Successfully");

            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
