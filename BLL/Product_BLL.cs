﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;
namespace BLL
{
    public class Product_BLL
    {
        private static Product_BLL _Instance;
        public static Product_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Product_BLL();
                }
                return _Instance;
            }
            private set { } //chỉ nội bộ lớp này mới đc set dữ liệu vào
        }
        private Product_BLL() { }
        public DataTable getProducts()
        {
            return Product_DAL.Instance.GetTrueRecords();
        }
        public DataTable getTFProducts()
        {
            return Product_DAL.Instance.GetRecords();
        }
        public List<Product> getAllProduct()
        {
            return Product_DAL.Instance.GetAllProduct();
        }
        public Product getProductByID(string id)
        {
            foreach (Product i in getAllProduct())
            {
                if (i.ID_P.ToString().Equals(id))
                {
                    return i;
                }
            }
            return null;
        }
        public List<Product> getProductByID_PG(string id)
        {
            List<Product> products = new List<Product>();
            foreach (Product i in getAllProduct())
            {
                if (i.ID_PG.ToString().Equals(id))
                {
                    products.Add(i);
                }
            }
            return products;
        }
        public DataTable GetProductByID(string id)
        {
            return Product_DAL.Instance.GetProductByID(id);
        }
        public DataTable getProductsByGroupName(string groupName)
        {
            return Product_DAL.Instance.getTrueProductsByGroupName(groupName);
        }
        public DataTable getTFProductsByGroupName(string groupName)
        {
            return Product_DAL.Instance.getProductsByGroupName(groupName);
        }

        public DataTable getProductsByOption(string groupName, string name, string option)
        {
            return Product_DAL.Instance.getProductsByOption(groupName, name, option);
        }

        public void ExcuteDB(Product product, string id_product = null) //update, delete, add
        {
            if (id_product == null)
            {

                Product_DAL.Instance.updateProduct(product);
                return;
            }
            if (id_product != null && !id_product.Equals("Add"))
            {
                Product_DAL.Instance.deleteProduct(id_product);
                return;
            }
            if (id_product == "Add")
            {
                Product_DAL.Instance.addProduct(product);
                return;
            }
        }
        
        public bool checkID_P(int id)
        {
            foreach(var i in getAllProduct())
            {
                if(i.ID_P == id) return true;
            }
            return false;
        }
        public List<CBBGroups> getAllNameProduct()
        {
            List<CBBGroups> data = new List<CBBGroups> ();
            foreach(var i in getAllProduct())
            {
                data.Add(new CBBGroups
                {
                    Value = i.ID_P,
                    Text = i.Name_P
                });
            }
            return data;
        }
        public int getNumberOfProduct(int id_p, string id_pg)
        {
            int count = 0;
            if(id_pg == "")
            {
                foreach(var i in getAllProduct())
                {
                    if (i.ID_P == id_p) break;
                    count++;
                }
            }
            else
            {
                foreach(var i in getProductByID_PG(id_pg))
                {
                    if (i.ID_P == id_p) break;
                    count++;
                }
            }
            return count;
        }
    }
}
