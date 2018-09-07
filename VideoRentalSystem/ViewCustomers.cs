using System;
using System.Windows.Forms;

namespace VideoRentalSystem
{
    public partial class ViewCustomers : Form
    {
        public ViewCustomers()
        {
            InitializeComponent();
            //Fill data grid with all customers
            dataGridView1.DataSource = new Database().SelectAnd("Customer");
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open Update Customer form with selected customer's ID
            UpdateCustomer updateCustomer = new UpdateCustomer(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            updateCustomer.StartPosition = FormStartPosition.CenterScreen;
            updateCustomer.ShowDialog();

            //Refresh data grid
            dataGridView1.DataSource = new Database().SelectAnd("Customer");
        }
    }
}
