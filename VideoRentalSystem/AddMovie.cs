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
    public partial class AddMovie : Form
    {
        public AddMovie()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int YearVal, CopiesVal;

            if (Rating.Text == "" || Title.Text == "" || Year.Text == "" || Copies.Text == "" || Plot.Text == "" || Genre.Text == "")
            {
                MessageBox.Show("All fields are required");
            }
            else if(!int.TryParse(Year.Text, out YearVal) || !(int.TryParse(Copies.Text, out CopiesVal)))
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

                if((DateTime.Now.Year - YearVal) > 5)
                {
                    movie.Add("Rental_Cost", 2.ToString());
                }
                else
                {
                    movie.Add("Rental_Cost", 5.ToString());
                }

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
