namespace GUI
{
    partial class Help
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
            this.btnSystem = new Guna.UI2.WinForms.Guna2Button();
            this.btnHow = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // btnSystem
            // 
            this.btnSystem.BackColor = System.Drawing.Color.Transparent;
            this.btnSystem.BorderRadius = 15;
            this.btnSystem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSystem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSystem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSystem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSystem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(166)))), ((int)(((byte)(192)))));
            this.btnSystem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnSystem.ForeColor = System.Drawing.Color.White;
            this.btnSystem.Location = new System.Drawing.Point(98, 154);
            this.btnSystem.Name = "btnSystem";
            this.btnSystem.Size = new System.Drawing.Size(190, 36);
            this.btnSystem.TabIndex = 23;
            this.btnSystem.Text = "Report  a problem";
            this.btnSystem.UseTransparentBackground = true;
            // 
            // btnHow
            // 
            this.btnHow.BackColor = System.Drawing.Color.Transparent;
            this.btnHow.BorderRadius = 15;
            this.btnHow.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHow.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHow.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHow.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHow.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(166)))), ((int)(((byte)(192)))));
            this.btnHow.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnHow.ForeColor = System.Drawing.Color.White;
            this.btnHow.Location = new System.Drawing.Point(317, 154);
            this.btnHow.Name = "btnHow";
            this.btnHow.Size = new System.Drawing.Size(190, 36);
            this.btnHow.TabIndex = 23;
            this.btnHow.Text = "How to use this app";
            this.btnHow.UseTransparentBackground = true;
            this.btnHow.Click += new System.EventHandler(this.btnHow_Click);
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(198)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btnHow);
            this.Controls.Add(this.btnSystem);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Help";
            this.Text = "Help";
            this.Load += new System.EventHandler(this.Help_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnSystem;
        private Guna.UI2.WinForms.Guna2Button btnHow;
    }
}