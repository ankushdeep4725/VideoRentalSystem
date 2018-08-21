namespace VideoRentalSystem
{
    partial class VideoRentalMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AddCustomerBtn = new System.Windows.Forms.Button();
            this.AddMovieBtn = new System.Windows.Forms.Button();
            this.ViewCustomersBtn = new System.Windows.Forms.Button();
            this.ViewMoviesBtn = new System.Windows.Forms.Button();
            this.IssueRentalBtn = new System.Windows.Forms.Button();
            this.ReturnRentalBtn = new System.Windows.Forms.Button();
            this.BestCustomersBtn = new System.Windows.Forms.Button();
            this.BestMoviesBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.ChangePasswordBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddCustomerBtn
            // 
            this.AddCustomerBtn.Location = new System.Drawing.Point(26, 22);
            this.AddCustomerBtn.Name = "AddCustomerBtn";
            this.AddCustomerBtn.Size = new System.Drawing.Size(111, 53);
            this.AddCustomerBtn.TabIndex = 0;
            this.AddCustomerBtn.Text = "Add Customer";
            this.AddCustomerBtn.UseVisualStyleBackColor = true;
            this.AddCustomerBtn.Click += new System.EventHandler(this.AddCustomer_Click);
            // 
            // AddMovieBtn
            // 
            this.AddMovieBtn.Location = new System.Drawing.Point(163, 22);
            this.AddMovieBtn.Name = "AddMovieBtn";
            this.AddMovieBtn.Size = new System.Drawing.Size(111, 53);
            this.AddMovieBtn.TabIndex = 1;
            this.AddMovieBtn.Text = "Add Movie";
            this.AddMovieBtn.UseVisualStyleBackColor = true;
            this.AddMovieBtn.Click += new System.EventHandler(this.AddMovie_Click);
            // 
            // ViewCustomersBtn
            // 
            this.ViewCustomersBtn.Location = new System.Drawing.Point(26, 106);
            this.ViewCustomersBtn.Name = "ViewCustomersBtn";
            this.ViewCustomersBtn.Size = new System.Drawing.Size(111, 53);
            this.ViewCustomersBtn.TabIndex = 2;
            this.ViewCustomersBtn.Text = "View Customers";
            this.ViewCustomersBtn.UseVisualStyleBackColor = true;
            this.ViewCustomersBtn.Click += new System.EventHandler(this.ViewCustomers_Click);
            // 
            // ViewMoviesBtn
            // 
            this.ViewMoviesBtn.Location = new System.Drawing.Point(163, 106);
            this.ViewMoviesBtn.Name = "ViewMoviesBtn";
            this.ViewMoviesBtn.Size = new System.Drawing.Size(111, 53);
            this.ViewMoviesBtn.TabIndex = 3;
            this.ViewMoviesBtn.Text = "View Movies";
            this.ViewMoviesBtn.UseVisualStyleBackColor = true;
            this.ViewMoviesBtn.Click += new System.EventHandler(this.ViewMovies_Click);
            // 
            // IssueRentalBtn
            // 
            this.IssueRentalBtn.Location = new System.Drawing.Point(26, 187);
            this.IssueRentalBtn.Name = "IssueRentalBtn";
            this.IssueRentalBtn.Size = new System.Drawing.Size(111, 53);
            this.IssueRentalBtn.TabIndex = 4;
            this.IssueRentalBtn.Text = "Issue Rental";
            this.IssueRentalBtn.UseVisualStyleBackColor = true;
            this.IssueRentalBtn.Click += new System.EventHandler(this.IssueRental_Click);
            // 
            // ReturnRentalBtn
            // 
            this.ReturnRentalBtn.Location = new System.Drawing.Point(163, 187);
            this.ReturnRentalBtn.Name = "ReturnRentalBtn";
            this.ReturnRentalBtn.Size = new System.Drawing.Size(111, 53);
            this.ReturnRentalBtn.TabIndex = 5;
            this.ReturnRentalBtn.Text = "Return Rental";
            this.ReturnRentalBtn.UseVisualStyleBackColor = true;
            this.ReturnRentalBtn.Click += new System.EventHandler(this.ReturnRental_Click);
            // 
            // BestCustomersBtn
            // 
            this.BestCustomersBtn.Location = new System.Drawing.Point(26, 270);
            this.BestCustomersBtn.Name = "BestCustomersBtn";
            this.BestCustomersBtn.Size = new System.Drawing.Size(111, 53);
            this.BestCustomersBtn.TabIndex = 6;
            this.BestCustomersBtn.Text = "Best Customers";
            this.BestCustomersBtn.UseVisualStyleBackColor = true;
            this.BestCustomersBtn.Click += new System.EventHandler(this.BestCustomers_Click);
            // 
            // BestMoviesBtn
            // 
            this.BestMoviesBtn.Location = new System.Drawing.Point(163, 270);
            this.BestMoviesBtn.Name = "BestMoviesBtn";
            this.BestMoviesBtn.Size = new System.Drawing.Size(111, 53);
            this.BestMoviesBtn.TabIndex = 7;
            this.BestMoviesBtn.Text = "Best Movies";
            this.BestMoviesBtn.UseVisualStyleBackColor = true;
            this.BestMoviesBtn.Click += new System.EventHandler(this.BestMovies_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Location = new System.Drawing.Point(163, 347);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(111, 53);
            this.ExitBtn.TabIndex = 8;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.Exit_Click);
            // 
            // ChangePasswordBtn
            // 
            this.ChangePasswordBtn.Location = new System.Drawing.Point(27, 347);
            this.ChangePasswordBtn.Name = "ChangePasswordBtn";
            this.ChangePasswordBtn.Size = new System.Drawing.Size(111, 53);
            this.ChangePasswordBtn.TabIndex = 9;
            this.ChangePasswordBtn.Text = "Change Password";
            this.ChangePasswordBtn.UseVisualStyleBackColor = true;
            this.ChangePasswordBtn.Click += new System.EventHandler(this.ChangePassword_Click);
            // 
            // VideoRentalMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 426);
            this.Controls.Add(this.ChangePasswordBtn);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.BestMoviesBtn);
            this.Controls.Add(this.BestCustomersBtn);
            this.Controls.Add(this.ReturnRentalBtn);
            this.Controls.Add(this.IssueRentalBtn);
            this.Controls.Add(this.ViewMoviesBtn);
            this.Controls.Add(this.ViewCustomersBtn);
            this.Controls.Add(this.AddMovieBtn);
            this.Controls.Add(this.AddCustomerBtn);
            this.Name = "VideoRentalMainForm";
            this.Text = "VideoRentalMainForm";
            this.Load += new System.EventHandler(this.VideoRentalMainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddCustomerBtn;
        private System.Windows.Forms.Button AddMovieBtn;
        private System.Windows.Forms.Button ViewCustomersBtn;
        private System.Windows.Forms.Button ViewMoviesBtn;
        private System.Windows.Forms.Button IssueRentalBtn;
        private System.Windows.Forms.Button ReturnRentalBtn;
        private System.Windows.Forms.Button BestCustomersBtn;
        private System.Windows.Forms.Button BestMoviesBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Button ChangePasswordBtn;
    }
}