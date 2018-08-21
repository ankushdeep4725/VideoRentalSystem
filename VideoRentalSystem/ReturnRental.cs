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
    public partial class ReturnRental : Form
    {
        public ReturnRental()
        {
            InitializeComponent();

            dataGridView1.DataSource = new Database().GetPendingRentals();
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to reurn this rental?", "Return Confirmation", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                Dictionary<string, string> Data = new Dictionary<string, string>();
                Data.Add("DateReturned", DateTime.Now.ToString());

                Dictionary<string, string> Where = new Dictionary<string, string>();
                Where.Add("RMID", dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

                new Database().Update("RentedMovies", Data, Where);

                MessageBox.Show("Movie Returned");

                dataGridView1.DataSource = new Database().GetPendingRentals();
            }
        }
    }
}
