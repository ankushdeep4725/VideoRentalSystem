using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace VideoRentalSystem
{
    public partial class UpdateCustomer : Form
    {
        private string CustId;
        Dictionary<string, string> Where;

        public UpdateCustomer()
        {
            InitializeComponent();
        }

        //Constructor to call from View Customers and fill with user values
        public UpdateCustomer(string value)
        {
            InitializeComponent();
            CustId = value;
            Where = new Dictionary<string, string>();
            Where.Add("CustID", CustId);

            //Get selected user's data
            DataTable data = new Database().SelectAnd("Customer", Where);

            foreach (DataRow item in data.Rows)
            {
                foreach (DataColumn column in data.Columns)
                {
                    foreach (Control Control in Controls)
                    {
                        if(Control.Name == column.ColumnName)
                        {
                            //Fill the textboxes with selected user's data
                            Control.Text = item[column].ToString();
                        }
                    }
                }
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            //Check if all fields are filled
            if (FirstName.Text == "" || LastName.Text == "" || Address.Text == "" || Phone.Text == "")
            {
                MessageBox.Show("All fields are required");
            }
            else
            {
                //Create dictionary to update
                Dictionary<string, string> customer = new Dictionary<string, string>();

                foreach (var control in Controls)
                {
                    if (control is TextBox)
                    {
                        TextBox ctrl = control as TextBox;
                        customer.Add(ctrl.Name, ctrl.Text);
                    }
                }

                //Call the updated method
                new Database().Update("Customer", customer, Where);

                MessageBox.Show("Customer Updated Successfully");
                Dispose();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
