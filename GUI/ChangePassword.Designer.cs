﻿namespace GUI
{
    partial class ChangePassword
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
            this.txtCurrentw = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNewPw = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtConfirmNewPw = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnUpdatePw = new Guna.UI2.WinForms.Guna2Button();
            this.lbUpper = new System.Windows.Forms.Label();
            this.lbSpecial = new System.Windows.Forms.Label();
            this.lbLength = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCurrentw
            // 
            this.txtCurrentw.BorderRadius = 6;
            this.txtCurrentw.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCurrentw.DefaultText = "";
            this.txtCurrentw.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCurrentw.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCurrentw.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCurrentw.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCurrentw.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCurrentw.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentw.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCurrentw.Location = new System.Drawing.Point(68, 88);
            this.txtCurrentw.Name = "txtCurrentw";
            this.txtCurrentw.PasswordChar = '●';
            this.txtCurrentw.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.txtCurrentw.PlaceholderText = "Current password";
            this.txtCurrentw.SelectedText = "";
            this.txtCurrentw.Size = new System.Drawing.Size(207, 34);
            this.txtCurrentw.TabIndex = 12;
            this.txtCurrentw.TextChanged += new System.EventHandler(this.txtCurrentw_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkCyan;
            this.label6.Location = new System.Drawing.Point(198, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(192, 33);
            this.label6.TabIndex = 11;
            this.label6.Text = "Reset password";
            // 
            // txtNewPw
            // 
            this.txtNewPw.BorderRadius = 6;
            this.txtNewPw.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNewPw.DefaultText = "";
            this.txtNewPw.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNewPw.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNewPw.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNewPw.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNewPw.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNewPw.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPw.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNewPw.Location = new System.Drawing.Point(68, 153);
            this.txtNewPw.Name = "txtNewPw";
            this.txtNewPw.PasswordChar = '●';
            this.txtNewPw.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.txtNewPw.PlaceholderText = "New password";
            this.txtNewPw.SelectedText = "";
            this.txtNewPw.Size = new System.Drawing.Size(207, 34);
            this.txtNewPw.TabIndex = 12;
            this.txtNewPw.TextChanged += new System.EventHandler(this.txtNewPw_TextChanged);
            // 
            // txtConfirmNewPw
            // 
            this.txtConfirmNewPw.BorderRadius = 6;
            this.txtConfirmNewPw.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConfirmNewPw.DefaultText = "";
            this.txtConfirmNewPw.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtConfirmNewPw.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtConfirmNewPw.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtConfirmNewPw.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtConfirmNewPw.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtConfirmNewPw.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmNewPw.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtConfirmNewPw.Location = new System.Drawing.Point(68, 223);
            this.txtConfirmNewPw.Name = "txtConfirmNewPw";
            this.txtConfirmNewPw.PasswordChar = '●';
            this.txtConfirmNewPw.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.txtConfirmNewPw.PlaceholderText = "Confirm new password";
            this.txtConfirmNewPw.SelectedText = "";
            this.txtConfirmNewPw.Size = new System.Drawing.Size(207, 34);
            this.txtConfirmNewPw.TabIndex = 12;
            // 
            // btnUpdatePw
            // 
            this.btnUpdatePw.AutoRoundedCorners = true;
            this.btnUpdatePw.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdatePw.BorderRadius = 16;
            this.btnUpdatePw.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUpdatePw.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUpdatePw.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUpdatePw.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUpdatePw.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(166)))), ((int)(((byte)(192)))));
            this.btnUpdatePw.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnUpdatePw.ForeColor = System.Drawing.Color.White;
            this.btnUpdatePw.Location = new System.Drawing.Point(226, 294);
            this.btnUpdatePw.Name = "btnUpdatePw";
            this.btnUpdatePw.Size = new System.Drawing.Size(102, 35);
            this.btnUpdatePw.TabIndex = 14;
            this.btnUpdatePw.Text = "Save";
            this.btnUpdatePw.UseTransparentBackground = true;
            this.btnUpdatePw.Click += new System.EventHandler(this.btnUpdatePw_Click);
            // 
            // lbUpper
            // 
            this.lbUpper.AutoSize = true;
            this.lbUpper.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUpper.ForeColor = System.Drawing.Color.White;
            this.lbUpper.Location = new System.Drawing.Point(323, 123);
            this.lbUpper.Name = "lbUpper";
            this.lbUpper.Size = new System.Drawing.Size(204, 18);
            this.lbUpper.TabIndex = 11;
            this.lbUpper.Text = "At least 1 uppercase letter (A-Z)";
            // 
            // lbSpecial
            // 
            this.lbSpecial.AutoSize = true;
            this.lbSpecial.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSpecial.ForeColor = System.Drawing.Color.White;
            this.lbSpecial.Location = new System.Drawing.Point(323, 156);
            this.lbSpecial.Name = "lbSpecial";
            this.lbSpecial.Size = new System.Drawing.Size(149, 18);
            this.lbSpecial.TabIndex = 11;
            this.lbSpecial.Text = "At least 1 number (0-9)";
            // 
            // lbLength
            // 
            this.lbLength.AutoSize = true;
            this.lbLength.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLength.ForeColor = System.Drawing.Color.White;
            this.lbLength.Location = new System.Drawing.Point(323, 187);
            this.lbLength.Name = "lbLength";
            this.lbLength.Size = new System.Drawing.Size(131, 18);
            this.lbLength.TabIndex = 11;
            this.lbLength.Text = "At least 8 characters";
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(198)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(582, 352);
            this.Controls.Add(this.btnUpdatePw);
            this.Controls.Add(this.txtConfirmNewPw);
            this.Controls.Add(this.txtNewPw);
            this.Controls.Add(this.txtCurrentw);
            this.Controls.Add(this.lbLength);
            this.Controls.Add(this.lbSpecial);
            this.Controls.Add(this.lbUpper);
            this.Controls.Add(this.label6);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ChangePassword";
            this.Text = "ChangePassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtCurrentw;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2TextBox txtNewPw;
        private Guna.UI2.WinForms.Guna2TextBox txtConfirmNewPw;
        private Guna.UI2.WinForms.Guna2Button btnUpdatePw;
        private System.Windows.Forms.Label lbUpper;
        private System.Windows.Forms.Label lbSpecial;
        private System.Windows.Forms.Label lbLength;
    }
}