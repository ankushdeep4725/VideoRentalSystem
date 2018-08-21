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
    public partial class IssueRental : Form
    {
        private string MovieIDVal;

        public IssueRental()
        {
            InitializeComponent();
        }

        public IssueRental(string value)
        {
            MovieIDVal = value;
            InitializeComponent();
            MovieID.Text = MovieIDVal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(FirstName.Text == "")
            {
                MessageBox.Show("Enter valid Customer ID");
            }
            else
            {
                Dictionary<string, string> Data = new Dictionary<string, string>();
                Data.Add("MovieIDFK", MovieID.Text);
                Data.Add("CustIDFK", CustID.Text);
                Data.Add("DateRented", DateTime.Now.ToString());

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
