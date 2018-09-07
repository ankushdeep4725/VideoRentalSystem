using System.Windows.Forms;

namespace VideoRentalSystem
{
    public partial class ReportBestCustomer : Form
    {
        public ReportBestCustomer()
        {
            InitializeComponent();

            //Fill data grid with best customers
            dataGridView1.DataSource = new Database().GetBestCustomers();
        }
    }
}
