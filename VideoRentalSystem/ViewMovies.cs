using System;
using System.Windows.Forms;

namespace VideoRentalSystem
{
    public partial class ViewMovies : Form
    {
        public ViewMovies()
        {
            InitializeComponent();

            //Fill data grid with all movies
            dataGridView1.DataSource = new Database().SelectAnd("Movies");
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open Update Movie form with selected movie's ID
            UpdateMovie updateMovie = new UpdateMovie(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            updateMovie.StartPosition = FormStartPosition.CenterScreen;
            updateMovie.ShowDialog();

            //Refresh data grid
            dataGridView1.DataSource = new Database().SelectAnd("Movies");
        }

        private void issueRentalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Get available copies for select movie
            int AvailableCopies = new Database().CheckAvaliableCopies(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));

            //If copies are available
            if (AvailableCopies > 0)
            {
                //Open Issue Rental form with selected movie ID
                IssueRental issueRental = new IssueRental(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                issueRental.StartPosition = FormStartPosition.CenterScreen;
                issueRental.ShowDialog();

                //Refresh data grid
                dataGridView1.DataSource = new Database().SelectAnd("Movies");
            }
            else
            {
                MessageBox.Show("No copy available to rent");
            }
        }
    }
}
