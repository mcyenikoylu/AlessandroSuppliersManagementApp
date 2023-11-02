using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AlessandroSuppliersManagementApp
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();

            string folder1 = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);// Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            string input = File.ReadAllText($@"{folder1}\\UBL_7462359.xml");
            string pattern = @"(</?)(\w+:)";
            string output = Regex.Replace(input, pattern, "$1");

            //System.Data.DataSet xmlDataSet = new System.Data.DataSet("XML DataSet");
            //// Load the XML document to the DataSet
            //xmlDataSet.ReadXml($@"{folder1}\\UBL_7462359.xml");

            //gridControl1.DataSource = xmlDataSet.Tables[0];

            StringReader reader = new StringReader(output);
            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            foreach (var item in ds.Tables["OrderLine"].DataSet.Tables[0].DataSet.Tables[0].DataSet.Tables)
            {
                
            }

            repositoryItemGridLookUpEdit1.DataSource= CreateList(5);
            gridControl1.DataSource= CreateList(15);
        }

        BindingList<Customer> CreateList(int count)
        {
            BindingList<Customer> list = new BindingList<Customer>();
            for (int i = 0; i < count; i++)
            {
                list.Add(new Customer("Name" + i, "Prezzo" + i, i));
            }
            return list;
        }

        public class Customer
        {
            public Customer()
            {
              
                this.Name = "";
                this.Prezzo = "";
                this.Qta = 0;
            }

            public Customer(string name, string info, int id)
            {
               
                this.Name = name;
                this.Prezzo = info;
                this.Qta = id;
            }

           
            public string Name { get; set; }
            public string Prezzo { get; set; }
            public int Qta { get; set; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

      
    }
}
