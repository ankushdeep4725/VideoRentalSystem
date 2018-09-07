using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VideoRentalSystem
{
    public partial class AddMovie : Form
    {
        public AddMovie()
        {
            InitializeComponent();
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
            else if(!int.TryParse(Year.Text, out YearVal) || !(int.TryParse(Copies.Text, out CopiesVal)))
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

                if((DateTime.Now.Year - YearVal) > 5)
                {
                    movie.Add("Rental_Cost", 2.ToString());
                }
                else
                {
                    movie.Add("Rental_Cost", 5.ToString());
                }

                //Call the insert function
                new Database().Insert("Movies", movie);

                MessageBox.Show("Movie Added Successfully");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
