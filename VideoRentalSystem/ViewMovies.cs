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
    public partial class ViewMovies : Form
    {
        public ViewMovies()
        {
            InitializeComponent();
            dataGridView1.DataSource = new Database().SelectAnd("Movies");
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateMovie updateMovie = new UpdateMovie(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            updateMovie.ShowDialog();
            dataGridView1.DataSource = new Database().SelectAnd("Movies");
        }

        private void issueRentalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AvailableCopies = new Database().CheckAvaliableCopies(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            if(AvailableCopies > 0)
            {
                IssueRental issueRental = new IssueRental(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                issueRental.ShowDialog();
                dataGridView1.DataSource = new Database().SelectAnd("Movies");
            }
            else
            {
                MessageBox.Show("No copy available to rent");
            }
        }
    }
}
