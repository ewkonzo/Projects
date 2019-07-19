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

namespace Weigh
{
    public partial class Collection : Form
    {
        public Collection()
        {
            InitializeComponent();
            Serial.mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            Serial.mySerialPort.ErrorReceived += new SerialErrorReceivedEventHandler(serialerrorHandler);
            try
            {
                if (AutoweighEntities.user.Type != "Admin")
                {
                    btnManual.Visible = false;
                    txtkg.Enabled = false;
                }
                Serial.serial();
                btnopenport.Enabled = false;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                try
                {
                    loadtodayscollections();
                }catch (Exception ex)
                {
                    Logging.Logging.ReportError(ex);
                }
            }
        }
        Farmer f;
        Daily_Collections_Detail c;
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new AutoweighEntities())
                {
                    if (this.txtfarmer.Text.Equals(""))
                    {
                        errorProvider1.SetError(txtfarmer, "Farmer No required");
                        return;
                    }

                    if (this.txtkg.Text.Equals(""))
                    {
                        errorProvider1.SetError(txtkg, "Kg required");
                        return;
                    }
                    if (f == null)
                    {
                        MessageBox.Show("Farmer record not found");
                        txtfarmer.Focus();
                        return;
                    }
                    if (Convert.ToDouble(this.txtkg.Text) ==0 ) { 
                    errorProvider1.SetError(txtkg, "Kg required");
                    return;
                }
                    var dat = DateTime.Now.Date;
                    var sold = db.Daily_Collections_Details.FirstOrDefault(o => o.Collections_Date == dat && o.Farmers_Number == f.No && o.Cancelled == "No");
                    if (sold != null)
                    {
                        MessageBox.Show("Farmer cannot deliver twice per day");
                        return;
                    }
                    var cn = string.Format("{0}{1}", f.No, DateTime.Now.ToString("yyMMddmmss"));
                    c = new Daily_Collections_Detail();
                    c.Collections_Date = DateTime.Now.Date;
                    c.Collection_time = DateTime.Now;
                    c.Farmers_Number = txtfarmer.Text;
                    c.Farmers_Name = f.Name;
                    c.Sent = false;
                    c.Collection_Number = cn;
                    c.Cancelled = "No";
                    c.Coffee_Type = (AutoweighEntities.setup.Coffe_type == 0 ? "CHERRY" : "MBUNI");
                    c.Factory = AutoweighEntities.setup.Branch;
                    c.Crop = AutoweighEntities.setup.Current_crop;
                    c.Kg__Collected = Convert.ToDouble(txtkg.Text);
                    c.User = AutoweighEntities.user.Name;
                    c.Collect_type = (auto == true ? "Auto" : "Manual");
                    var ff = db.Farmers.FirstOrDefault(o => o.No == f.No);
                    if (ff != null)
                        if (AutoweighEntities.setup.Coffe_type == 0)
                        {
                            ff.Cum_Cherry += c.Kg__Collected;
                            c.Cumm = (double)ff.Cum_Cherry;
                        }
                        else
                        {
                            ff.Cum_Mbuni += c.Kg__Collected;
                            c.Cumm = (double)ff.Cum_Mbuni;

                        }


                  db.Daily_Collections_Details.Add(c);
                    db.SaveChanges();
                }
                loadcollections();
                Run(c);
                loadtodayscollections();
                txtfarmer.Text = "";
                txtkg.Text = "";
                txtfarmer.Focus();
            }
            catch (Exception ex) { Logging.Logging.ReportError(ex);
                MessageBox.Show("Unable to post, please try again");
            }
        }

        private int m_currentPageIndex;
        private IList<Stream> m_streams;
        private void Print()
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.PrinterSettings.PrinterName = AutoweighEntities.setup.Printer;
                printDoc.Print();
            }
        }
        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding,  string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }
        // Export the given report as an EMF (Enhanced Metafile) file.
        private void Export(LocalReport report)
        {
            var lr = report.ListRenderingExtensions();
            string deviceInfo =
              @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>5in</PageWidth>
                <PageHeight>7in</PageHeight>
                <MarginTop>0in</MarginTop>
                <MarginLeft>0in</MarginLeft>
                <MarginRight>0in</MarginRight>
                <MarginBottom>0in</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream, out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Bitmap pageImage = new
                  Bitmap(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }
        private void Run(Daily_Collections_Detail c)
        {
            //Receipt.printdata p = new Receipt.printdata();
            //p.c = c;
            //p.u = AutoweighEntities.user;

            BindingSource bs = new BindingSource();
            BindingSource st = new BindingSource();
            BindingSource us = new BindingSource();

            bs.DataSource = c;
            st.DataSource = AutoweighEntities.setup;
            us.DataSource = AutoweighEntities.user;
            //LocalReport report = new LocalReport();
            //report.ReportPath = @"Report1.rdlc";
            //report.DataSources.Add(new ReportDataSource("DataSet1", bs));
            //report.DataSources.Add(new ReportDataSource("Setup", st));
            //report.DataSources.Add(new ReportDataSource("user", us));

            //Export(report);
            //Print();
            this.c = c;
            PrintDocument p = new PrintDocument();
          
            p.PrintPage += new PrintPageEventHandler(this.printDocument_PrintPage);
            p.PrinterSettings.PrinterName = AutoweighEntities.setup.Printer;
     
            p.Print();
              p.PrintController = new System.Drawing.Printing.StandardPrintController();
        }
        void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                int p = e.PageSettings.PaperSize.Width;
                float y = e.PageSettings.Margins.Top;
                float ml = 30;// e.PageSettings.Margins.Left;
                float mt = 30;//e.PageSettings.Margins.Top;
                float mr = 30;//e.PageSettings.Margins.Right;
                float mb = 30;//e.PageSettings.Margins.Bottom;
                float sm = ml + mr;
                float ps = p - sm;
                Point l, l2;
                string space = " ";
                string str = "";
                var dd = Application.StartupPath;
                Font font = new Font("Segoe UI Light", 9f,FontStyle.Bold);
                SolidBrush solidBrush = new SolidBrush(Color.Black);
                Pen pen = new Pen(solidBrush);
                Image image = Image.FromFile(dd + @"\files\logo.bmp");

                e.Graphics.DrawImage(image, ((ps - image.Size.Width) / 2) + ml, y);
                y += image.Size.Height;

                string Branch = AutoweighEntities.Factory_Name;
                var ssize = e.Graphics.MeasureString(Branch, font);
                e.Graphics.DrawString(Branch, font, solidBrush, ((ps - ssize.Width) / 2) + ml, y);
                y += ssize.Height + 3;

                 Branch = AutoweighEntities.setup.Branch;
                 ssize = e.Graphics.MeasureString(Branch, font);
                e.Graphics.DrawString(AutoweighEntities.setup.Branch, font, solidBrush, ((ps - ssize.Width) / 2) + ml, y);
                y += ssize.Height + 3;


                l = new Point((int)ml, (int)y);

                l2 = new Point((int)(ml + ps), (int)y);

                e.Graphics.DrawLine(pen, l, l2);
                y += e.Graphics.MeasureString(str, font).Height + 3;

                str = "Member no: ";
                space = padspace(e.Graphics.MeasureString(space, font).Width, (ps - (e.Graphics.MeasureString(str, font).Width + e.Graphics.MeasureString(c.Farmers_Number, font).Width)));

                e.Graphics.DrawString(str + space + c.Farmers_Number, font, solidBrush, ml, y);
                y += e.Graphics.MeasureString(str, font).Height + 3;
                str = "Member name: ";
                space = padspace(e.Graphics.MeasureString(space, font).Width, (ps - (e.Graphics.MeasureString(str, font).Width + e.Graphics.MeasureString(c.Farmers_Name, font).Width)));

                e.Graphics.DrawString(str + space + c.Farmers_Name, font, solidBrush, ml, y);
                y += e.Graphics.MeasureString(str, font).Height + 3;
                str = "Collection no: ";

                space = padspace(e.Graphics.MeasureString(space, font).Width, (ps - (e.Graphics.MeasureString(str, font).Width + e.Graphics.MeasureString(c.Collection_Number, font).Width)));

                e.Graphics.DrawString(str + space + c.Collection_Number, font, solidBrush, ml, y);
                y += e.Graphics.MeasureString(str, font).Height + 3;
                str = "Date: ";
                space = padspace(e.Graphics.MeasureString(space, font).Width, (ps - (e.Graphics.MeasureString(str, font).Width + e.Graphics.MeasureString(c.Collections_Date.ToString("yyyy/MM/dd"), font).Width)));

                e.Graphics.DrawString(str + space + c.Collections_Date.ToString("yyyy/MM/dd"), font, solidBrush, ml, y);
                y += e.Graphics.MeasureString(str, font).Height + 3;

                str = "Time: ";
              

                space = padspace(e.Graphics.MeasureString(space, font).Width, (ps - (e.Graphics.MeasureString(str, font).Width + e.Graphics.MeasureString(((DateTime)c.Collection_time).ToString("hh:mm"), font).Width)));

                e.Graphics.DrawString(str + space + ((DateTime)c.Collection_time).ToString("hh:mm"), font, solidBrush, ml, y);
                y += e.Graphics.MeasureString(str, font).Height + 3;

                str = "Coffee type: ";
                space = padspace(e.Graphics.MeasureString(space, font).Width, (ps - (e.Graphics.MeasureString(str, font).Width + e.Graphics.MeasureString(c.Coffee_Type, font).Width)));

                e.Graphics.DrawString(str + space + c.Coffee_Type, font, solidBrush, ml, y);
                y += e.Graphics.MeasureString(str, font).Height + 3;

                str = "Kg: ";
                space = padspace(e.Graphics.MeasureString(space, font).Width, (ps - (e.Graphics.MeasureString(str, font).Width + e.Graphics.MeasureString(c.Kg__Collected.ToString(), font).Width)));

                e.Graphics.DrawString(str + space + c.Kg__Collected.ToString(), font, solidBrush, ml, y);
                y += e.Graphics.MeasureString(str, font).Height + 3;

                str = "Cummulative: ";
                space = padspace(e.Graphics.MeasureString(space, font).Width, (ps - (e.Graphics.MeasureString(str, font).Width + e.Graphics.MeasureString(c.Cumm.ToString(), font).Width)));

                e.Graphics.DrawString(str + space + c.Cumm.ToString(), font, solidBrush, ml, y);
                y += e.Graphics.MeasureString(str, font).Height + 3;

                str = "Collection type: ";
                space = padspace(e.Graphics.MeasureString(space, font).Width, (ps - (e.Graphics.MeasureString(str, font).Width + e.Graphics.MeasureString(c.Collect_type, font).Width)));

                e.Graphics.DrawString(str + space + c.Collect_type, font, solidBrush, ml, y);
                y += e.Graphics.MeasureString(str, font).Height + 3;

                l = new Point((int)ml, (int)y);
                l2 = new Point((int)(ml + ps), (int)y);

                e.Graphics.DrawLine(pen, l, l2);
                y += e.Graphics.MeasureString(str, font).Height + 3;

                str = "Served by: ";
                space = padspace(e.Graphics.MeasureString(space, font).Width, (ps - (e.Graphics.MeasureString(str, font).Width + e.Graphics.MeasureString(AutoweighEntities.user.Name, font).Width)));

                e.Graphics.DrawString(str + space + AutoweighEntities.user.Name, font, solidBrush, ml, y);
                y += e.Graphics.MeasureString(str, font).Height + 3;

                str = "Asante Karibu Tena";

                e.Graphics.DrawString(str, font, solidBrush, ((ps - e.Graphics.MeasureString(str, font).Width) / 2) + ml, y);

                y += e.Graphics.MeasureString(str, font).Height + 3;
                e.Graphics.DrawString("\n", font, solidBrush, ml, y);
            }
            catch (Exception ex)
            { Logging.Logging.ReportError(ex); }
        }
        private string padspace(float ssize,float size) {
            string space = "";
            if(ssize>0)
            if (size > ssize)
            {
                for (int i = 0; i < size/ssize; i++)
                {
                    space += " ";
                }
             
            }
            return space;
        }



        //private void printreceipt(Daily_Collections_Detail c)
        //{
        //    try
        //    {
        //        Receipt.printdata p = new Receipt.printdata();
        //        p.c = c;
        //        p.u = AutoweighEntities.user;

        //        Receipt r = new Receipt(p);
        //        r.PrintingSystem.ShowMarginsWarning = false;
        //        r.PrintingSystem.ShowPrintStatusDialog = false;
        //        using (ReportPrintTool printTool = new ReportPrintTool(r))
        //        {
        //            // Invoke the Print dialog.
        //            //   printTool.PrintDialog();
        //            // Send the report to the default printer.
        //            // printTool.Print();
        //            // Send the report to the specified printer.
        //            printTool.Print(AutoweighEntities.setup.Printer);
        //        }
        //    }
        //    catch (Exception ex) { Logging.Logging.ReportError(ex); }
        //    }

        private void txtfarmer_Leave(object sender, EventArgs e)
        {

            if (this.txtfarmer.Text.Equals(""))
            {
                errorProvider1.SetError(txtfarmer, "Farmer No required");
                txtfarmer.Focus();
            }
            else
            {
                errorProvider1.SetError(txtfarmer, null);
                using (var db = new AutoweighEntities())
                {
                    f = db.Farmers.FirstOrDefault(o => o.No == txtfarmer.Text);
                    if (f == null)
                    {
                        MessageBox.Show("Farmer record not found");
                        txtfarmer.Focus();
                        return;
                    }
                }
                viewfarmername.Text = f.Name;
                if (AutoweighEntities.setup.Coffe_type == 0)
                                    viewcummulative.Text = f.Cum_Cherry.ToString();
                                    
                else viewcummulative.Text = f.Cum_Mbuni.ToString();
                loadcollections();
            }
        }
        private void loadcollections()
        {
            try
            {
                using (var db = new AutoweighEntities())
                {
                  db.Daily_Collections_Details.Load();
                  var cumm = db.Daily_Collections_Details.Local.ToBindingList().Where(o => o.Farmers_Number == txtfarmer.Text && o.Cancelled == "No" && o.Crop == AutoweighEntities.setup.Current_crop);
                    daily_Collections_DetailsBindingSource.DataSource = cumm;
                    viewcummulative.Text = "Cummulative Kgs: " + ((AutoweighEntities.setup.Coffe_type==0? f.Cum_Cherry:f.Cum_Mbuni) + Convert.ToDouble(txtkg.Text));
                }
            }
            catch (Exception ex) { }
        }
        private void loadtodayscollections()
        {
            using (var db = new AutoweighEntities()) {
                db.Daily_Collections_Details.Load();
                // This line of code is generated by Data Source Configuration Wizard
                var total = db.Daily_Collections_Details.Local.ToBindingList().Where(o => o.Collections_Date == DateTime.Now.Date).OrderByDescending(o => o.No_);
                bindingSource1.DataSource = total;

                txttotal.Text = "TOTAL KGS: " + total.Where(o => o.Cancelled == "No").Sum(o => o.Kg__Collected).ToString();

            }
        }
        private void txtkg_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtkg_Leave(object sender, EventArgs e)
        {
            if (this.txtkg.Text.Equals(""))
                errorProvider1.SetError(txtkg, "Kgs required");
            else
            {
                errorProvider1.SetError(txtkg, null);

            }
        }
        public void serialerrorHandler(object sender, SerialErrorReceivedEventArgs e)
        {
           
        
        }
        SerialPort sp;
        public void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                sp = (SerialPort)sender;
                string readdata = sp.ReadLine();
                Char[] strarr = readdata.Replace("\r", "").ToCharArray().Where(c => Char.IsDigit(c) || Char.IsPunctuation(c)).ToArray();
                decimal number = Convert.ToDecimal(new string(strarr).Replace(",", ""));
                SetText(number.ToString());
                //  txtkg.Text = indata;
            }
            catch (Exception ex)
            { Logging.Logging.ReportError(ex); }
        }

        string readdata = string.Empty;
        delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (auto)
            {
                if (this.txtkg.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    this.txtkg.Text = text;
                }
            }
        }


        private void Collection_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Serial.mySerialPort.IsOpen)
            {
                e.Cancel = true; //cancel the fom closing

                System.Threading.Thread CloseDown = new System.Threading.Thread(new System.Threading.ThreadStart(CloseSerialOnExit)); //close port in new thread to avoid hang

                CloseDown.Start(); //close port in new thread to avoid hang
            }
        }
        private void CloseSerialOnExit()
        {
            try
            {
                Serial.mySerialPort.Close(); //close the serial port
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); //catch any serial port closing error messages
            }
            this.Invoke(new EventHandler(NowClose)); //now close back in the main thread
        }
        private void NowClose(object sender, EventArgs e)

        {

            this.Close(); //now close the form

        }
        private void btnopenport_Click(object sender, EventArgs e)
        {
            try
            {
                Serial.serial();
                btnopenport.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            sp.WriteLine("Zero");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sp.WriteLine("Tare");
        }
        private void Control_KeyUp(object sender, KeyEventArgs e)
        {

            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                if (txtkg.Enabled == true)
                {
                    if (txtfarmer.Text.Equals(""))
                    {
                        errorProvider1.SetError(txtfarmer, "Farmer No required");
                        txtfarmer.Focus();
                    }
                    else
                    {

                        txtkg.Focus();
                    }
                }
                else
                    btnprocess.Focus();

            }
        }
        private void OtherControl_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);

            }
        }
        private void txtfarmer_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnprocess_Enter(object sender, EventArgs e)
        {
            //  ((Button)sender) 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new AutoweighEntities())
                {
                    string c = dataGridView2.SelectedRows[0].Cells["collectionNumberDataGridViewTextBoxColumn1"].Value.ToString();
                    DialogResult d = MessageBox.Show("Are you sure you want to cancel this receipt", c, MessageBoxButtons.YesNo);
                    if (d == DialogResult.Yes)
                    {
                        var coll = db.Daily_Collections_Details.FirstOrDefault(o => o.Collection_Number == c);
                        if (coll != null)
                        {
                            if (coll.Cancelled == "Yes")
                            {
                               
                                MessageBox.Show("You can't reverse an already reversed transaction");
                                return;
                            }
                            coll.Cancelled = "Yes";
                            Daily_Collections_Detail ct = new Daily_Collections_Detail();
                            ct.Collections_Date =coll.Collections_Date;
                            ct.Collection_time = coll.Collection_time;
                            ct.Farmers_Number = coll.Farmers_Number;
                            ct.Farmers_Name = coll.Farmers_Name;
                            ct.Sent = false;
                            ct.Collection_Number = coll.Collection_Number+"-1";
                            ct.Cancelled = "Yes";
                            ct.Coffee_Type = coll.Coffee_Type;
                            ct.Factory = coll.Factory;
                            ct.Kg__Collected = coll.Kg__Collected*-1;
                            ct.User = AutoweighEntities.user.Name;
                            ct.Collect_type = coll.Collect_type;

                            var ff = db.Farmers.FirstOrDefault(o => o.No == coll.Farmers_Number);
                            if (ff != null)
                            {
                                if (AutoweighEntities.setup.Coffe_type == 0)
                                {
                                    ff.Cum_Cherry -= coll.Kg__Collected;

                                    ct.Cumm = (double)ff.Cum_Cherry;
                                }
                                else
                                {
                                    ff.Cum_Mbuni -= coll.Kg__Collected;

                                    ct.Cumm = (double)ff.Cum_Mbuni;
                                }
                            }
                           
                            db.Daily_Collections_Details.Add(ct);
                        }
                       db.SaveChanges();
                        loadtodayscollections();
                    }
                }
                            }
            catch (Exception ex)
            { Logging.Logging.ReportError(ex); }
        }
        private void Reprint(object sender, EventArgs e)
        {
            try
            {
                using (var db = new AutoweighEntities())
                {
                    string c = dataGridView2.SelectedRows[0].Cells["collectionNumberDataGridViewTextBoxColumn1"].Value.ToString();
                //DialogResult d = MessageBox.Show("Are you sure you want to reprint this receipt", c, MessageBoxButtons.YesNo);
                //if (d == DialogResult.Yes)
                //{
                var coll = db.Daily_Collections_Details.FirstOrDefault(o => o.Collection_Number == c);
                if (coll != null)
                {
                    Run(coll);
                }
                }
            }
            catch (Exception ex)
            { Logging.Logging.ReportError(ex); }


        }
        private bool auto = true;
        private void btnManual_Click(object sender, EventArgs e)
        {
            auto = (auto == true ? false : true);
            btnManual.Text = (auto == true ? "Manual" : "Auto");
        }

        private void Collection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.M)
            {
                btnManual_Click(null, null);
            }
        }

        private void txtfarmer_KeyPress(object sender, KeyPressEventArgs e)
        {
       //     if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       //(e.KeyChar != '.'))
       //     {
       //         e.Handled = true;
       //     }

       //     // only allow one decimal point
       //     if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
       //     {
       //         e.Handled = true;
       //     }
        }

        private void txtkg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
