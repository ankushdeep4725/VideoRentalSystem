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
    public partial class UpdateCustomer : Form
    {
        private string CustId;
        Dictionary<string, string> Where;

        public UpdateCustomer()
        {
            InitializeComponent();
        }

        public UpdateCustomer(string value)
        {
            InitializeComponent();
            CustId = value;
            Where = new Dictionary<string, string>();
            Where.Add("CustID", CustId);
            DataTable data = new Database().SelectAnd("Customer", Where);

            foreach (DataRow item in data.Rows)
            {
                foreach (DataColumn column in data.Columns)
                {
                    foreach (Control Control in Controls)
                    {
                        if(Control.Name == column.ColumnName)
                        {
                            Control.Text = item[column].ToString();
                        }
                    }
                }
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (FirstName.Text == "" || LastName.Text == "" || Address.Text == "" || Phone.Text == "")
            {
                MessageBox.Show("All fields are required");
            }
            else
            {
                Dictionary<string, string> customer = new Dictionary<string, string>();

                foreach (var control in Controls)
                {
                    if (control is TextBox)
                    {
                        TextBox ctrl = control as TextBox;
                        customer.Add(ctrl.Name, ctrl.Text);
                    }
                }

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
