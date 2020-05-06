using Gamadev.Report;
using System;
using System.Collections.Generic;
using System.Windows;

namespace WpfApplication
{
    public class DsSaleReport
    {
        public Company Company { get; set; }
        public Customer Customer { get; set; }
        public string Reference { get; set; }
        public DateTime Date { get; set; }
        public IList<SaleLine> Lines { get; set; }
        public double Total { get; set; }
    }

    public class Company
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public class Customer
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }

    public class SaleLine
    {
        public int ID { get; set; }
        public string Desination { get; set; }
        public double SalePrice { get; set; }
        public double Quantity { get; set; }
        public double Discount { get; set; }
        public double Total { get { return (SalePrice * Quantity) - Discount; } }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var report = StiReport.CreateNewReport();
            report.Load("Reports\\Report.mrt");

            report.Dictionary.Databases.Clear();

            var dsProduct = Gamadev.Base.StiJsonToDataSetConverter.GetDataSet(Newtonsoft.Json.JsonConvert.SerializeObject(data));
            report.RegData("sale", dsProduct);

            //report.DesignV2WithWpf();
            report.RenderWithWpf();
            report.ShowWithWpf();
        }
        public object data
        => new DsSaleReport()
        {
            Company = new Company() { Name = "Gamadev", Address = "City 300 Eloued" },
            Customer = new Customer() { FullName = "Iskandar Benz", Address = "City None Ben Ali 25, Algeria", Phone = "0660656565" },
            Reference = "SO215454/2020",
            Date = DateTime.Now,
            Lines = new List<SaleLine>()
                {
                    new SaleLine(){ID = 1,Desination = "Test Product", Discount = 0.5,SalePrice = 15.0,Quantity = 20} ,
                    new SaleLine(){ID = 1,Desination = "Test Product1",Discount = 4.5,SalePrice = 15.0,Quantity = 45} ,
                    new SaleLine(){ID = 1,Desination = "Test Product2",Discount = 2.5,SalePrice = 15.0,Quantity = 123} ,
                    new SaleLine(){ID = 1,Desination = "Test Product3",Discount = 4.5,SalePrice = 15.0,Quantity = 45} ,
                    new SaleLine(){ID = 1,Desination = "Test Product4",Discount = 1.5,SalePrice = 15.0,Quantity = 62} ,
                    new SaleLine(){ID = 1,Desination = "Test Product5",Discount = 2.5,SalePrice = 15.0,Quantity = 100} ,
                    new SaleLine(){ID = 1,Desination = "Test Product6",Discount = 3.5,SalePrice = 15.0,Quantity = 5} ,
                    new SaleLine(){ID = 1,Desination = "Test Product77777",Discount = 8.5,SalePrice = 15.0,Quantity = 3} ,
                }
        };
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var f = Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
    }
}