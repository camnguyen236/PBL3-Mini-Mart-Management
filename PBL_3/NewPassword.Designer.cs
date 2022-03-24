namespace PBL_3
{
    partial class NewPassword
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
            this.lbNewPass = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbConfirmNewPass = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.tbNewPass = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbConfirmNewPass = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnOK = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // lbNewPass
            // 
            this.lbNewPass.BackColor = System.Drawing.Color.Transparent;
            this.lbNewPass.Location = new System.Drawing.Point(42, 53);
            this.lbNewPass.Name = "lbNewPass";
            this.lbNewPass.Size = new System.Drawing.Size(106, 22);
            this.lbNewPass.TabIndex = 0;
            this.lbNewPass.Text = "New password ";
            // 
            // lbConfirmNewPass
            // 
            this.lbConfirmNewPass.BackColor = System.Drawing.Color.Transparent;
            this.lbConfirmNewPass.Location = new System.Drawing.Point(42, 123);
            this.lbConfirmNewPass.Name = "lbConfirmNewPass";
            this.lbConfirmNewPass.Size = new System.Drawing.Size(163, 22);
            this.lbConfirmNewPass.TabIndex = 1;
            this.lbConfirmNewPass.Text = "Confirm new password";
            // 
            // tbNewPass
            // 
            this.tbNewPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbNewPass.DefaultText = "";
            this.tbNewPass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbNewPass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbNewPass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbNewPass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbNewPass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbNewPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbNewPass.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbNewPass.Location = new System.Drawing.Point(252, 39);
            this.tbNewPass.Name = "tbNewPass";
            this.tbNewPass.PasswordChar = '\0';
            this.tbNewPass.PlaceholderText = "";
            this.tbNewPass.SelectedText = "";
            this.tbNewPass.Size = new System.Drawing.Size(263, 36);
            this.tbNewPass.TabIndex = 2;
            // 
            // tbConfirmNewPass
            // 
            this.tbConfirmNewPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbConfirmNewPass.DefaultText = "";
            this.tbConfirmNewPass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbConfirmNewPass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbConfirmNewPass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbConfirmNewPass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbConfirmNewPass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbConfirmNewPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbConfirmNewPass.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbConfirmNewPass.Location = new System.Drawing.Point(252, 109);
            this.tbConfirmNewPass.Name = "tbConfirmNewPass";
            this.tbConfirmNewPass.PasswordChar = '\0';
            this.tbConfirmNewPass.PlaceholderText = "";
            this.tbConfirmNewPass.SelectedText = "";
            this.tbConfirmNewPass.Size = new System.Drawing.Size(263, 36);
            this.tbConfirmNewPass.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnOK.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnOK.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnOK.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnOK.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(428, 182);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 45);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // NewPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 264);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbConfirmNewPass);
            this.Controls.Add(this.tbNewPass);
            this.Controls.Add(this.lbConfirmNewPass);
            this.Controls.Add(this.lbNewPass);
            this.Name = "NewPassword";
            this.Text = "NewPassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lbNewPass;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbConfirmNewPass;
        private Guna.UI2.WinForms.Guna2TextBox tbNewPass;
        private Guna.UI2.WinForms.Guna2TextBox tbConfirmNewPass;
        private Guna.UI2.WinForms.Guna2Button btnOK;
    }
}