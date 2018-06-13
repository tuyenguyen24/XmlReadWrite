using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;
using System.Configuration;
using System.Data.Common;
using System.Runtime.InteropServices;


namespace NhapKho
{
    public partial class frmImportExport : Form
    {
        public frmImportExport()
        {
            InitializeComponent();
        }

        private void frmImportExport_Load(object sender, EventArgs e)
        {
            
        }

        private void btImport_Click(object sender, EventArgs e)
        {
            
           
            SqlConnection Con = new SqlConnection(@"Data Source=TUYENNT13-HP\SQLEXPRESS;Initial Catalog=Demo;Integrated Security=True");
            SqlCommand com;
            string str;
            Con.Open();
            for (int index = 1; index < dataGridView3.Rows.Count - 1; index++)
            {
                str = @"Insert Into Receipt(InvoiceNo,PartNo,Amount) Values(" + "'" + dataGridView3.Rows[index].Cells[0].Value.ToString() + "', '" + dataGridView3.Rows[index].Cells[1].Value.ToString()+ "', '" + dataGridView3.Rows[index].Cells[2].Value.ToString() +"')";
                com = new SqlCommand(str, Con);
                com.ExecuteNonQuery();
            }
            Con.Close();

        }
        

        private void btExport_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            Int16 i, j;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);

            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            for (i = 0; i <= dataGridView1.RowCount - 2; i++)
            {
                for (j = 0; j <= dataGridView1.ColumnCount - 1; j++)
                {
                    xlWorkSheet.Cells[i + 1, j + 1] = dataGridView1[j, i].Value.ToString();
                }
            }

            xlWorkBook.SaveAs(@"D:\DATAOUT.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
        }

        private void btLoad_Click(object sender, EventArgs e)
        {

            

            DataGridViewRow row = new DataGridViewRow();
            DataGridViewColumn col = new DataGridViewColumn();
            DataTable Dt = new DataTable();
            Dt.Columns.Add("MÃ HÀNG");
            Dt.Columns.Add("TÊN HÀNG");
            Dt.Columns.Add("MÃ HS");
            Dt.Columns.Add("SỐ LƯỢNG");
            Dt.Columns.Add("ĐVT");
            Dt.Columns.Add("ĐƠN GIÁ");

            for (int i = 1; i < dataGridView2.Rows.Count-1; i++)
            {
               //row = (DataGridViewRow)dataGridView2.Rows[i].Clone();
               //row.CreateCells(dataGridView1);
                for (int j = 1; j < dataGridView3.Rows.Count-1; j++)
                {
                    if (dataGridView2.Rows[i].Cells[0].Value.ToString()== dataGridView3.Rows[j].Cells[1].Value.ToString())
                    {
                        //row.Cells[0].Value = dataGridView2.Rows[i].Cells[0].Value.ToString();
                        //row.Cells[1].Value = dataGridView2.Rows[i].Cells[1].Value.ToString();
                        //row.Cells[2].Value = dataGridView2.Rows[i].Cells[2].Value.ToString();
                        //row.Cells[3].Value = dataGridView3.Rows[j].Cells[2].Value.ToString();
                        //row.Cells[4].Value = dataGridView2.Rows[i].Cells[5].Value.ToString();
                        //row.Cells[5].Value = dataGridView2.Rows[i].Cells[6].Value.ToString();

                        //dataGridView1.Rows.Add(row);

                       
                        

                        DataRow row1 = Dt.NewRow();
                        row1["MÃ HÀNG"] = dataGridView2.Rows[i].Cells[0].Value.ToString(); 
                        row1["TÊN HÀNG"] = dataGridView2.Rows[i].Cells[1].Value.ToString(); 
                        row1["MÃ HS"] = dataGridView2.Rows[i].Cells[2].Value.ToString(); ;
                        row1["SỐ LƯỢNG"] = dataGridView3.Rows[j].Cells[2].Value.ToString(); 
                        row1["ĐVT"] = dataGridView2.Rows[i].Cells[5].Value.ToString();
                        row1["ĐƠN GIÁ"] = dataGridView2.Rows[i].Cells[6].Value.ToString(); 
                        Dt.Rows.Add(row1);
                       


                    }

                    dataGridView1.DataSource = Dt;
                }
               
            }
           
           
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void btShow_Click(object sender, EventArgs e)
        {
            //Open file
            string fname = "";
            OpenFileDialog fopen = new OpenFileDialog();
            fopen.Filter = "(All file)|*.*|(Excel file)|*.xlsx";
            fopen.ShowDialog();
            if (fopen.ShowDialog() == DialogResult.OK)
            {
                fname = fopen.FileName;
                txtFilepath.Text = fopen.FileName;
            }


            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fname);
            Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            dataGridView2.ColumnCount = colCount;
            dataGridView2.RowCount = rowCount;

            for (int i = 1; i <= rowCount; i++)
            {
                for (int j = 1; j <= colCount; j++)
                {


                    //write the value to the Grid  


                    if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                    {
                        dataGridView2.Rows[i - 1].Cells[j - 1].Value = xlRange.Cells[i, j].Value2.ToString();
                    }
                    
                }
            }

            //cleanup  
            GC.Collect();
            GC.WaitForPendingFinalizers();

          
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release  
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release  
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);

        }

        private void btShow2_Click(object sender, EventArgs e)
        {
            //Open file
            string fname = "";
            OpenFileDialog fopen = new OpenFileDialog();
            fopen.Filter = "(All file)|*.*|(Excel file)|*.xlsx";
            fopen.ShowDialog();
            if (fopen.ShowDialog() == DialogResult.OK)
            {
                fname = fopen.FileName;
                txtPath.Text = fopen.FileName;
            }


            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fname);
            Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            dataGridView3.ColumnCount = colCount;
            dataGridView3.RowCount = rowCount;

            for (int i = 1; i <= rowCount; i++)
            {
                for (int j = 1; j <= colCount; j++)
                {


                    //write the value to the Grid  


                    if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                    {
                        dataGridView3.Rows[i - 1].Cells[j - 1].Value = xlRange.Cells[i, j].Value2.ToString();
                    }

                }
            }

            //cleanup  
            GC.Collect();
            GC.WaitForPendingFinalizers();


            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release  
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release  
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);

        }

        private void btImport2_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(@"Data Source=TUYENNT13-HP\SQLEXPRESS;Initial Catalog=Demo;Integrated Security=True");
            SqlCommand com;
            string str;
            Con.Open();
            for (int index = 1; index < dataGridView2.Rows.Count - 1; index++)
            {
                str = @"Insert Into Invoice(PartNo,TenHang,HSCode,XuatSu,Amount,Unit,PriceUnit,Total) Values(" + "'" + dataGridView2.Rows[index].Cells[0].Value.ToString() + "',N'" + dataGridView2.Rows[index].Cells[1].Value.ToString() + "', '" + dataGridView2.Rows[index].Cells[2].Value.ToString() + "', '" + dataGridView2.Rows[index].Cells[3].Value.ToString() + "', '" + dataGridView2.Rows[index].Cells[4].Value.ToString() + "',N'" + dataGridView2.Rows[index].Cells[5].Value.ToString() + "', '" + dataGridView2.Rows[index].Cells[6].Value.ToString() + "', '" + dataGridView2.Rows[index].Cells[7].Value.ToString() + "')";
                com = new SqlCommand(str, Con);
                com.ExecuteNonQuery();
            }
            Con.Close();
        }

        private void btLoad2_Click(object sender, EventArgs e)
        {
            string sql = "Select Invoice.PartNo,Invoice.TenHang,Invoice.HSCode, Receipt.Amount,Invoice.Unit,Invoice.PriceUnit from Invoice INNER JOIN Receipt ON Invoice.PartNo = Receipt.PartNo";
            SqlConnection connection = new SqlConnection(@"Data Source=TUYENNT13-HP\SQLEXPRESS;Initial Catalog=Demo;Integrated Security=True");
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            connection.Open();
            dataadapter.Fill(ds, "Authors_table");
            connection.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Authors_table";
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
        }
    }
    
}
