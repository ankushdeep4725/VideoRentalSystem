namespace VideoRentalSystem
{
    partial class UpdateCustomer
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FirstName = new System.Windows.Forms.TextBox();
            this.LastName = new System.Windows.Forms.TextBox();
            this.Address = new System.Windows.Forms.TextBox();
            this.Phone = new System.Windows.Forms.TextBox();
            this.Update = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Address";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Phone No";
            // 
            // FirstName
            // 
            this.FirstName.Location = new System.Drawing.Point(152, 30);
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(165, 20);
            this.FirstName.TabIndex = 4;
            // 
            // LastName
            // 
            this.LastName.Location = new System.Drawing.Point(152, 56);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(165, 20);
            this.LastName.TabIndex = 5;
            // 
            // Address
            // 
            this.Address.Location = new System.Drawing.Point(152, 82);
            this.Address.Multiline = true;
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(165, 61);
            this.Address.TabIndex = 6;
            // 
            // Phone
            // 
            this.Phone.Location = new System.Drawing.Point(152, 149);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(165, 20);
            this.Phone.TabIndex = 7;
            // 
            // Update
            // 
            this.Update.Location = new System.Drawing.Point(152, 202);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(75, 41);
            this.Update.TabIndex = 8;
            this.Update.Text = "Update Customer";
            this.Update.UseVisualStyleBackColor = true;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(242, 202);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 41);
            this.Cancel.TabIndex = 9;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // UpdateCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 289);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.Phone);
            this.Controls.Add(this.Address);
            this.Controls.Add(this.LastName);
            this.Controls.Add(this.FirstName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UpdateCustomer";
            this.Text = "Update Customer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox FirstName;
        private System.Windows.Forms.TextBox LastName;
        private System.Windows.Forms.TextBox Address;
        private System.Windows.Forms.TextBox Phone;
        private System.Windows.Forms.Button Update;
        private System.Windows.Forms.Button Cancel;
    }
}