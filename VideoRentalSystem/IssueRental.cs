using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace VideoRentalSystem
{
    public partial class IssueRental : Form
    {
        private string MovieIDVal;

        public IssueRental()
        {
            InitializeComponent();
        }

        //Constructer to call from View movies
        public IssueRental(string value)
        {
            MovieIDVal = value;
            InitializeComponent();
            MovieID.Text = MovieIDVal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Checks if the customer ID is entered correctly
            if(FirstName.Text == "")
            {
                MessageBox.Show("Enter valid Customer ID");
            }
            else
            {
                //Create dictionary to INSERT in Rented Movies
                Dictionary<string, string> Data = new Dictionary<string, string>();
                Data.Add("MovieIDFK", MovieID.Text);
                Data.Add("CustIDFK", CustID.Text);
                string Date = DateTime.Now.ToString("MM/dd/yyyy") + " " + DateTime.Now.ToShortTimeString();
                Data.Add("DateRented", Date);

                //Call insert method to insert in RentedMovies table
                new Database().Insert("RentedMovies", Data);

                MessageBox.Show("Movie Rented");
                Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void CustID_TextChanged(object sender, EventArgs e)
        {
            foreach (Control Control in Controls)
            {
                if ((Control is TextBox))
                {
                    if ((Control.Name == "MovieID" || Control.Name == (sender as Control).Name))
                    {
                        continue;
                    }
                    else
                    {
                        Control.Text = "";
                    }
                }
            }

            Dictionary<string, string> Where = new Dictionary<string, string>();
            Where.Add("CustID", CustID.Text);
            DataTable data = new Database().SelectAnd("Customer", Where);

            foreach (DataRow item in data.Rows)
            {
                foreach (DataColumn column in data.Columns)
                {
                    foreach (Control Control in Controls)
                    {
                        if (Control.Name == column.ColumnName)
                        {
                            Control.Text = item[column].ToString();
                        }
                    }
                }
            }
        }
    }
}
