using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;

namespace BLL
{
    public class Supplier_BLL
    {
        private static Supplier_BLL _Instance;
        public static Supplier_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Supplier_BLL();
                }
                return _Instance;
            }
            private set { } //chỉ nội bộ lớp này mới đc set dữ liệu vào
        }
        private Supplier_BLL() { }
        public DataTable getSupplier()
        {
            return Supplier_DAL.Instance.GetTrueRecords();
        }
        public DataTable getTFSupplier()
        {
            return Supplier_DAL.Instance.GetRecords();
        }
        public void ExcuteDB(Supplier Supplier, string id_Supplier = null) //update, delete
        {
            if (id_Supplier == null)
            {
                Supplier_DAL.Instance.updateSupplier(Supplier);
                return;
            }
            if (id_Supplier != null && !id_Supplier.Equals("Add"))
            {
                Supplier_DAL.Instance.deleteSupplier(id_Supplier);
                return;
            }
            if (id_Supplier == "Add")
            {
                Supplier_DAL.Instance.addSupplier(Supplier);
                return;
            }
        }
        public DataTable getSuppliersByOption(string name, string option)
        {
            return Supplier_DAL.Instance.getSuppliersByOption(name, option);
        }
        public List<Supplier> getAllSupplier()
        {
            return Supplier_DAL.Instance.GetAllSupplier();
        }
        public Supplier getSupplierByID(string id)
        {
            foreach (Supplier i in getAllSupplier())
            {
                if (i.ID_Supplier.ToString().Equals(id))
                {
                    return i;
                }
            }
            return null;
        }
        public Supplier getSupplierByName(string name)
        {
            foreach (Supplier i in getAllSupplier())
            {
                if (i.Name_Supplier.ToString().Equals(name))
                {
                    return i;
                }
            }
            return null;
        }
        public List<CBBGroups> getAllNameSupplier()
        {
            List<CBBGroups> data = new List<CBBGroups>();
            foreach(Supplier i in getAllSupplier())
            {
                data.Add(new CBBGroups { Value = i.ID_Supplier, Text = i.Name_Supplier});
            }
            return data;
        }
    }
}
