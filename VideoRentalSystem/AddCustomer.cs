using System;
using System.Collections.Generic;
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
            //Check if all fields are filled
            if(FirstName.Text == "" || LastName.Text == "" || Address.Text == "" || Phone.Text == "")
            {
                MessageBox.Show("All fields are required");
            }
            else
            {
                //Create a key value pair Dictionary for Customer insertion
                Dictionary<string, string> customer = new Dictionary<string, string>();

                foreach (var control in Controls)
                {
                    if(control is TextBox)
                    {
                        //Add value of each textbox in Dictionary
                        TextBox ctrl = control as TextBox;
                        customer.Add(ctrl.Name, ctrl.Text);
                    }
                }
                
                //Call the insert function
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
