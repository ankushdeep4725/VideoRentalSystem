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
    public partial class ReportBestVideos : Form
    {
        public ReportBestVideos()
        {
            InitializeComponent();
            dataGridView1.DataSource = new Database().GetBestMovies();
        }
    }
}
