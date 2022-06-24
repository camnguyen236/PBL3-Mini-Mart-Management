using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Product_Library
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1(int id)
        {
            InitializeComponent();
            id_p = id;
        }

        #region Properties

        private Image _picture;
        private string _name;
        private string _price;
        private string _unit;
        private int _number;
        private int id_p;

        [Category("Product Props")]
        public Image Picture
        {
            get { return _picture; }
            set { _picture = value; picture.Image = value; }
        }

        [Category("Product Props")]
        public string name
        {
            get { return _name; }
            set { _name = value; lbName.Text = value; }
        }

        [Category("Product Props")]
        public string Price
        {
            get { return _price; }
            set { _price = value; lbPrice.Text = value; }
        }

        [Category("Product Props")]
        public string Unit
        {
            get { return _unit; }
            set { _unit = value; lbUnit.Text = value; }
        }

        [Category("Product Props")]
        public int Number
        {
            get { return _number; }
            set { _number = value; number.Value = value; }
        }

        public int Id_p
        {
            get { return id_p; }
            set { id_p = value; }
        }
        #endregion

        public delegate void AddToCard_ClickHandler(object sender, EventArgs e);
        public event AddToCard_ClickHandler AddToCard_Click;

        public void OnAddToCard_ClickClick(EventArgs e)
        {
            if (AddToCard_Click != null)
            {
                AddToCard_Click(this, e);
            }
        }
        public void add()
        {
            OnAddToCard_ClickClick(EventArgs.Empty);
        }

        private void btnAddToCard_Click(object sender, EventArgs e)
        {
            add();
        }

        private void number_ValueChanged(object sender, EventArgs e)
        {
            Number = Convert.ToInt32(number.Value);
        }
    }
}
