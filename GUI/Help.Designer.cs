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
            this.label2 = new System.Windows.Forms.Label();
            this.btnProblem = new Guna.UI2.WinForms.Guna2Button();
            this.btnHow = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(110, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 30);
            this.label2.TabIndex = 35;
            this.label2.Text = "May I help you?";
            // 
            // btnProblem
            // 
            this.btnProblem.BackColor = System.Drawing.Color.Transparent;
            this.btnProblem.BorderRadius = 3;
            this.btnProblem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnProblem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnProblem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnProblem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnProblem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(166)))), ((int)(((byte)(192)))));
            this.btnProblem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnProblem.ForeColor = System.Drawing.Color.White;
            this.btnProblem.Location = new System.Drawing.Point(67, 165);
            this.btnProblem.Margin = new System.Windows.Forms.Padding(4);
            this.btnProblem.Name = "btnProblem";
            this.btnProblem.Size = new System.Drawing.Size(254, 44);
            this.btnProblem.TabIndex = 34;
            this.btnProblem.Text = "Report a bug !";
            this.btnProblem.UseTransparentBackground = true;
            this.btnProblem.Click += new System.EventHandler(this.btnProblem_Click);
            // 
            // btnHow
            // 
            this.btnHow.BackColor = System.Drawing.Color.Transparent;
            this.btnHow.BorderRadius = 3;
            this.btnHow.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHow.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHow.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHow.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHow.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(166)))), ((int)(((byte)(192)))));
            this.btnHow.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnHow.ForeColor = System.Drawing.Color.White;
            this.btnHow.Location = new System.Drawing.Point(67, 239);
            this.btnHow.Margin = new System.Windows.Forms.Padding(4);
            this.btnHow.Name = "btnHow";
            this.btnHow.Size = new System.Drawing.Size(254, 44);
            this.btnHow.TabIndex = 33;
            this.btnHow.Text = "How to use this app ?";
            this.btnHow.UseTransparentBackground = true;
            this.btnHow.Click += new System.EventHandler(this.btnHow_Click);
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(398, 356);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnProblem);
            this.Controls.Add(this.btnHow);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Help";
            this.Text = "Help";
            this.Load += new System.EventHandler(this.Help_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnProblem;
        private Guna.UI2.WinForms.Guna2Button btnHow;
    }
}