using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VideoRentalSystem
{
    public partial class ReturnRental : Form
    {
        public ReturnRental()
        {
            InitializeComponent();

            //Fill data grid with Pending rentals
            dataGridView1.DataSource = new Database().GetPendingRentals();
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to reurn this rental?", "Return Confirmation", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                //Create Dictionary to mark rental as returned
                Dictionary<string, string> Data = new Dictionary<string, string>();
                string Date = DateTime.Now.ToString("MM/dd/yyyy") + " " + DateTime.Now.ToShortTimeString();
                Data.Add("DateReturned", Date);

                Dictionary<string, string> Where = new Dictionary<string, string>();
                Where.Add("RMID", dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

                //Call update method
                new Database().Update("RentedMovies", Data, Where);

                MessageBox.Show("Movie Returned");

                //Refresh data grid
                dataGridView1.DataSource = new Database().GetPendingRentals();
            }
        }
    }
}
