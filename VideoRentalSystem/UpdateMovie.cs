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
    public partial class UpdateMovie : Form
    {
        public string MovieID;
        private Dictionary<string, string> Where;

        public UpdateMovie()
        {
            InitializeComponent();
        }

        public UpdateMovie(string value)
        {
            InitializeComponent();
            MovieID = value;
            Where = new Dictionary<string, string>();
            Where.Add("MovieID", MovieID);
            DataTable data = new Database().SelectAnd("Movies", Where);

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

        private void button1_Click(object sender, EventArgs e)
        {
            int YearVal, CopiesVal;

            if (Rating.Text == "" || Title.Text == "" || Year.Text == "" || Copies.Text == "" || Plot.Text == "" || Genre.Text == "")
            {
                MessageBox.Show("All fields are required");
            }
            else if (!int.TryParse(Year.Text, out YearVal) || !(int.TryParse(Copies.Text, out CopiesVal)))
            {
                MessageBox.Show("Year and Copies must be a valid integer");
            }
            else
            {
                Dictionary<string, string> movie = new Dictionary<string, string>();

                foreach (var control in Controls)
                {
                    if (control is TextBox)
                    {
                        TextBox ctrl = control as TextBox;
                        movie.Add(ctrl.Name, ctrl.Text);
                    }
                }

                if ((DateTime.Now.Year - YearVal) > 5)
                {
                    movie.Add("Rental_Cost", 2.ToString());
                }
                else
                {
                    movie.Add("Rental_Cost", 5.ToString());
                }

                new Database().Update("Movies", movie, Where);

                MessageBox.Show("Movie Added Successfully");
            }
            Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
