using System.Windows.Forms;

namespace VideoRentalSystem
{
    public partial class ReportBestVideos : Form
    {
        public ReportBestVideos()
        {
            InitializeComponent();

            //Fill data grid with best movies
            dataGridView1.DataSource = new Database().GetBestMovies();
        }
    }
}
