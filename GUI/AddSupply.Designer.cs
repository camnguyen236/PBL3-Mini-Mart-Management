namespace GUI
{
    partial class AddSupply
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbAccountNumber = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbPhoneNumber = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbName = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnOK_Customer = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::GUI.Properties.Resources.resetform;
            this.pictureBox2.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(736, 382);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(166)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(280, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 33);
            this.label1.TabIndex = 17;
            this.label1.Text = "Add Supply";
            // 
            // tbAccountNumber
            // 
            this.tbAccountNumber.BackColor = System.Drawing.Color.DodgerBlue;
            this.tbAccountNumber.BorderRadius = 15;
            this.tbAccountNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbAccountNumber.DefaultText = "";
            this.tbAccountNumber.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbAccountNumber.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbAccountNumber.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbAccountNumber.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbAccountNumber.FillColor = System.Drawing.Color.WhiteSmoke;
            this.tbAccountNumber.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbAccountNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbAccountNumber.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbAccountNumber.Location = new System.Drawing.Point(272, 109);
            this.tbAccountNumber.Name = "tbAccountNumber";
            this.tbAccountNumber.PasswordChar = '\0';
            this.tbAccountNumber.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.tbAccountNumber.PlaceholderText = "Account Number";
            this.tbAccountNumber.SelectedText = "";
            this.tbAccountNumber.Size = new System.Drawing.Size(200, 36);
            this.tbAccountNumber.TabIndex = 29;
            // 
            // tbPhoneNumber
            // 
            this.tbPhoneNumber.BackColor = System.Drawing.Color.DodgerBlue;
            this.tbPhoneNumber.BorderRadius = 15;
            this.tbPhoneNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbPhoneNumber.DefaultText = "";
            this.tbPhoneNumber.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbPhoneNumber.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbPhoneNumber.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPhoneNumber.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPhoneNumber.FillColor = System.Drawing.Color.WhiteSmoke;
            this.tbPhoneNumber.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbPhoneNumber.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbPhoneNumber.Location = new System.Drawing.Point(511, 109);
            this.tbPhoneNumber.Name = "tbPhoneNumber";
            this.tbPhoneNumber.PasswordChar = '\0';
            this.tbPhoneNumber.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.tbPhoneNumber.PlaceholderText = "Phone number";
            this.tbPhoneNumber.SelectedText = "";
            this.tbPhoneNumber.Size = new System.Drawing.Size(200, 36);
            this.tbPhoneNumber.TabIndex = 28;
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.Color.DodgerBlue;
            this.tbName.BorderRadius = 15;
            this.tbName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbName.DefaultText = "";
            this.tbName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbName.FillColor = System.Drawing.Color.WhiteSmoke;
            this.tbName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbName.Location = new System.Drawing.Point(24, 109);
            this.tbName.Name = "tbName";
            this.tbName.PasswordChar = '\0';
            this.tbName.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.tbName.PlaceholderText = "Your name";
            this.tbName.SelectedText = "";
            this.tbName.Size = new System.Drawing.Size(200, 36);
            this.tbName.TabIndex = 27;
            // 
            // tbAddress
            // 
            this.tbAddress.BackColor = System.Drawing.SystemColors.Window;
            this.tbAddress.BorderRadius = 15;
            this.tbAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbAddress.DefaultText = "";
            this.tbAddress.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbAddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbAddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbAddress.FillColor = System.Drawing.Color.WhiteSmoke;
            this.tbAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbAddress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbAddress.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbAddress.Location = new System.Drawing.Point(24, 247);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.PasswordChar = '\0';
            this.tbAddress.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.tbAddress.PlaceholderText = "Your address";
            this.tbAddress.SelectedText = "";
            this.tbAddress.Size = new System.Drawing.Size(200, 36);
            this.tbAddress.TabIndex = 30;
            // 
            // btnOK_Customer
            // 
            this.btnOK_Customer.BackColor = System.Drawing.SystemColors.Window;
            this.btnOK_Customer.BorderRadius = 20;
            this.btnOK_Customer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnOK_Customer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnOK_Customer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnOK_Customer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnOK_Customer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(166)))), ((int)(((byte)(192)))));
            this.btnOK_Customer.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK_Customer.ForeColor = System.Drawing.Color.White;
            this.btnOK_Customer.Location = new System.Drawing.Point(286, 247);
            this.btnOK_Customer.Name = "btnOK_Customer";
            this.btnOK_Customer.Size = new System.Drawing.Size(136, 37);
            this.btnOK_Customer.TabIndex = 32;
            this.btnOK_Customer.Text = "OK";
            this.btnOK_Customer.Click += new System.EventHandler(this.btnOK_Customer_Click);
            // 
            // AddSupply
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 335);
            this.Controls.Add(this.btnOK_Customer);
            this.Controls.Add(this.tbAddress);
            this.Controls.Add(this.tbAccountNumber);
            this.Controls.Add(this.tbPhoneNumber);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "AddSupply";
            this.Text = "AddSupply";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox tbAccountNumber;
        private Guna.UI2.WinForms.Guna2TextBox tbPhoneNumber;
        private Guna.UI2.WinForms.Guna2TextBox tbName;
        private Guna.UI2.WinForms.Guna2TextBox tbAddress;
        private Guna.UI2.WinForms.Guna2Button btnOK_Customer;
    }
}