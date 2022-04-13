using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PBL_3
{
    public partial class List : Form
    {
        public string rs;
        
        public List()
        {
            InitializeComponent();
        }

        SqlConnection conn;
        public SqlCommand cmd;
        SqlDataAdapter ad = new SqlDataAdapter(); //cầu nối trung gian giữa csdl và datatb
        DataTable dt = new DataTable();
 
        //load dữ liệu lên bảng
        void loadData()
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "select ID,US,Name,Birthday,Adress,PhoneNumber,Position,Email from Inf_user";
            ad.SelectCommand = cmd;
            dt.Clear();
            ad.Fill(dt); //đổ dữ liệu từ csdl ra datatable
            dgv1.DataSource = dt;
            dgv1.Columns[6].Visible = false;
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        Modify modify = new Modify();
        Login login = new Login();
        private void guna2Button1_Click(object sender, EventArgs e) //Button Back
        {
            MainForm mf2 = new MainForm();
            this.Hide();
            //string rs = login.roleLogin + " / " + modify.role;
            mf2.mName(rs);
            mf2.ShowDialog();

            this.Close();

        }

        private void guna2Button2_Click(object sender, EventArgs e) //Add
        {
            AddAccount ad = new AddAccount();
            ad.ShowDialog();
        }

        private void guna2Button5_Click(object sender, EventArgs e) //Show
        {
            conn = Connection.getSqlConnection();
            conn.Open();
            loadData();
        }

        private void lbRole_Click(object sender, EventArgs e)
        {

        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.ReadOnly = true;
            int i = dgv1.CurrentRow.Index;
            txtID.Text = dgv1.Rows[i].Cells[0].Value.ToString();
            txtUsername.Text = dgv1.Rows[i].Cells[1].Value.ToString();
            txtName.Text = dgv1.Rows[i].Cells[2].Value.ToString();
            txtBirthday.Text = dgv1.Rows[i].Cells[3].Value.ToString();
            txtAddress.Text = dgv1.Rows[i].Cells[4].Value.ToString();
            txtPhone.Text = dgv1.Rows[i].Cells[5].Value.ToString();
            txtRole.Text = dgv1.Rows[i].Cells[6].Value.ToString();
            txtEmail.Text = dgv1.Rows[i].Cells[7].Value.ToString();
        }
        private void Reset()
        {
            txtID.Text = "";
            txtUsername.Text = "";
            txtName.Text = "";
            txtBirthday.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtRole.Text = "";
            txtEmail.Text = "";
        }
        private void guna2Button3_Click(object sender, EventArgs e) //Update
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "update Inf_user set US = '" + txtUsername.Text + "', Name = N'"+txtName.Text+"', Birthday = '"+txtBirthday.Text+"', Adress = N'"+txtAddress.Text+"', PhoneNumber = '" + txtPhone.Text + "', Email = '" +txtEmail.Text+"' where ID = '"+txtID.Text+"'"; //vì mã nhân viên là khóa chính
            cmd.ExecuteNonQuery();
            loadData();
            MessageBox.Show("Update successful!");
            //"', PhoneNumber = '"+txtPhone.Text+
        }
        private void guna2Button4_Click(object sender, EventArgs e) //Delete
        {
            //conn = Connection.getSqlConnection();
            cmd = conn.CreateCommand();
            cmd.CommandText = "delete from Inf_user where ID = '"+txtID.Text +"'"; //vì mã nhân viên là khóa chính
                DialogResult dl = MessageBox.Show("Are you sure to delete this row?", "", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
                if (dl == DialogResult.OK)
                {
                    cmd.ExecuteNonQuery();
                    loadData();
                    Reset();
                }
                else if (dl == DialogResult.Cancel)
                {
                    //sthis.Close();
                }
            

        }

    }
}
