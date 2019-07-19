using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Data.Entity;
using System.IO.Ports;

using System.Drawing.Printing;
using System.Drawing.Imaging;
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Web;



namespace Weigh
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }
        private static reports creport;
        BindingSource bs = new BindingSource();
        BindingSource farmer = new BindingSource();
        BindingSource cm = new BindingSource();
        BindingSource us = new BindingSource();
        public Reports(reports r)
        {
            InitializeComponent();
            creport = r;
            using (var db = new AutoweighEntities())
            {

                cm.DataSource = db.Settings.FirstOrDefault();
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Company", cm));


                cm.DataSource = AutoweighEntities.user;
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("user", us));


                ReportParameterCollection reportParameters = new ReportParameterCollection();
                reportParameters.Add(new ReportParameter("Factory", AutoweighEntities.Factory_Name));

                reportViewer1.LocalReport.SetParameters(reportParameters);
            }

            switch (r)
            {
                case reports.Dailycollection:
                    panel1.Visible = true;
                    using (var db = new AutoweighEntities())
                    {
                        bs.DataSource = db.Daily_Collections_Details.ToList();
                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", bs));
                        reportViewer1.LocalReport.ReportEmbeddedResource = "Weigh.Reports.Daily Collection.rdlc";
                        reportViewer1.RefreshReport();


                    }
                    break;
                case reports.Todays:
                    panel1.Visible = true;
                    using (var db = new AutoweighEntities())
                    {
                        DateTime d = DateTime.Now.Date;
                        bs.DataSource = db.Daily_Collections_Details.Where(o => o.Collections_Date == d).ToList();
                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", bs));
                        reportViewer1.LocalReport.ReportEmbeddedResource = "Weigh.Reports.Daily Collection.rdlc";
                        reportViewer1.RefreshReport();

                    }
                    break;
                case reports.Farmerdailycollection:
                    panel2.Visible = true;
                    using (var db = new AutoweighEntities())
                    {
                        farmer.DataSource = db.Farmers.FirstOrDefault();

                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Farmer", farmer));

                        bs.DataSource = db.Daily_Collections_Details.Where(o => o.Farmers_Number == db.Farmers.FirstOrDefault().No).ToList();

                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Coll", bs));

                        reportViewer1.LocalReport.ReportEmbeddedResource = "Weigh.Reports.Farmer Delivery.rdlc";
                        reportViewer1.RefreshReport();

                    }
                    break;
                case reports.cummulative:
                    panel2.Visible = true;
                    using (var db = new AutoweighEntities())
                    {
                        farmer.DataSource = db.Farmers.ToList();

                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Farmers", farmer));

                      
                        reportViewer1.LocalReport.ReportEmbeddedResource = "Weigh.Reports.Farmerscummulative.rdlc";
                        reportViewer1.RefreshReport();

                    }
                    break;
            }



        }

        private void Reports_Load(object sender, EventArgs e)
        {


        }

        public enum reports
        {
            Dailycollection = 0,
            Todays = 1,
            Farmerdailycollection = 2,
                cummulative =3
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (creport)
            {
                case reports.Farmerdailycollection:
                    {  using (var db = new AutoweighEntities())
                        {
                            farmer.DataSource = db.Farmers.FirstOrDefault(o=> o.No == comboBox1.SelectedValue.ToString());


                            bs.DataSource = db.Daily_Collections_Details.Where(o => o.Farmers_Number == comboBox1.SelectedValue.ToString()).ToList();
 reportViewer1.RefreshReport();
                        }
                        break;
                    }
                default:
                    using (var db = new AutoweighEntities())
                    {
                        DateTime d = dateTimePicker1.Value.Date;
                        bs.DataSource = db.Daily_Collections_Details.Where(o => o.Collections_Date == d).ToList();
                        reportViewer1.RefreshReport();
                    }

                    break;


            }
        }
    }
}
