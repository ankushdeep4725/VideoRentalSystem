﻿using System;
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
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void VideoRentalMainForm_Load(object sender, EventArgs e)
        {
            Login login = new Login();
            login.StartPosition = FormStartPosition.CenterScreen;
            login.ShowDialog();
        }

        private void AddCustomer_Click(object sender, EventArgs e)
        {
            AddCustomer form = new AddCustomer();
            ShowForm(form);
        }

        private void AddMovie_Click(object sender, EventArgs e)
        {
            AddMovie form = new AddMovie();
            ShowForm(form);
        }

        private void ViewCustomers_Click(object sender, EventArgs e)
        {
            ViewCustomers form = new ViewCustomers();
            ShowForm(form);
        }

        private void ViewMovies_Click(object sender, EventArgs e)
        {
            ViewMovies form = new ViewMovies();
            ShowForm(form);
        }

        private void IssueRental_Click(object sender, EventArgs e)
        {
            ViewMovies form = new ViewMovies();
            ShowForm(form);
        }

        private void ReturnRental_Click(object sender, EventArgs e)
        {
            ReturnRental form = new ReturnRental();
            ShowForm(form);
        }

        private void BestCustomers_Click(object sender, EventArgs e)
        {
            ReportBestCustomer form = new ReportBestCustomer();
            ShowForm(form);
        }

        private void BestMovies_Click(object sender, EventArgs e)
        {
            ReportBestVideos form = new ReportBestVideos();
            ShowForm(form);
        }

        private void ChangePassword_Click(object sender, EventArgs e)
        {
            ChangePassword form = new ChangePassword();
            ShowForm(form);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are your sure to exit the application?", "Exit Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void ShowForm(Form form)
        {
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }
    }
}
