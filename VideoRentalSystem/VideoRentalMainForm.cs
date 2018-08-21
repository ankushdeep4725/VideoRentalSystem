using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoRentalSystem
{
    public partial class VideoRentalMainForm : Form
    {
        public VideoRentalMainForm()
        {
            InitializeComponent();
        }

        private void VideoRentalMainForm_Load(object sender, EventArgs e)
        {
            Database database = new Database();
            MessageBox.Show( database.CheckConnection().ToString());
        }
    }
}
