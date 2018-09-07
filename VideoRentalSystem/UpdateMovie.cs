using System;
using System.Collections.Generic;
using System.Data;
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

        //Constructor to call from View Movie and fill with user values
        public UpdateMovie(string value)
        {
            InitializeComponent();
            MovieID = value;
            Where = new Dictionary<string, string>();
            Where.Add("MovieID", MovieID);

            //Get selected movie's data
            DataTable data = new Database().SelectAnd("Movies", Where);

            foreach (DataRow item in data.Rows)
            {
                foreach (DataColumn column in data.Columns)
                {
                    foreach (Control Control in Controls)
                    {
                        if (Control.Name == column.ColumnName)
                        {
                            //Fill the textboxes with selected movie's data
                            Control.Text = item[column].ToString();
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int YearVal, CopiesVal;

            //Check if all fields are filled
            if (Rating.Text == "" || Title.Text == "" || Year.Text == "" || Copies.Text == "" || Plot.Text == "" || Genre.Text == "")
            {
                MessageBox.Show("All fields are required");
            }
            //Check if Year and Copies is a valid integer value
            else if (!int.TryParse(Year.Text, out YearVal) || !(int.TryParse(Copies.Text, out CopiesVal)))
            {
                MessageBox.Show("Year and Copies must be a valid integer");
            }
            else
            {
                //Create a key value pair Dictionary for movie insertion
                Dictionary<string, string> movie = new Dictionary<string, string>();

                foreach (var control in Controls)
                {
                    if (control is TextBox)
                    {
                        //Add value of each textbox in Dictionary
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

                //Call the update method
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
