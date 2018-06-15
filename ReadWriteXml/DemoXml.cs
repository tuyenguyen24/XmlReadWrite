using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Data.SqlClient;
using System.Collections;


namespace ReadWriteXml
{
    public partial class DemoXml : Form
    {
        private int rowIndex = 0;
        DataTable table = new DataTable();
        

        public DemoXml()
        {
            InitializeComponent();
            //table.Columns.Add("Id", typeof(int));
            //table.Columns.Add("First Name", typeof(string));
            //table.Columns.Add("Last Name", typeof(string));
            //table.Columns.Add("Age", typeof(int));

            //// add rows
            //table.Rows.Add(1, "First A", "Last A", 10);
            //table.Rows.Add(2, "First B", "Last B", 20);
            //table.Rows.Add(3, "First C", "Last C", 30);
            //table.Rows.Add(4, "First D", "Last D", 40);
            //table.Rows.Add(5, "First E", "Last E", 50);
            //table.Rows.Add(6, "First F", "Last F", 60);
            //table.Rows.Add(7, "First G", "Last G", 70);
            //table.Rows.Add(8, "First H", "Last H", 80);

            //dataGridView1.DataSource = table;
            tabPage1.Text =  "TabLogViewNormal";
            tabPage2.Text = "TabLogViewArrange";
            groupBox2.Text = "Filter";
            groupBox2.Text = "Change";
            this.AllowDrop = true;
            treeView1.DragEnter += Form1_DragEnter;
            treeView1.DragDrop += new DragEventHandler(Form1_DragDrop);

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName = null;
            OpenFileDialog OpenFileDlg = new OpenFileDialog
            {
                FilterIndex = 0,
                RestoreDirectory = true
            };

            if (OpenFileDlg.ShowDialog() == DialogResult.OK)
            {
                fileName = OpenFileDlg.FileName;
            }
            DataSet ds = new DataSet();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(DataSet));
            FileStream readStream = new FileStream(fileName, FileMode.Open);
            ds = (DataSet)xmlSerializer.Deserialize(readStream);
            readStream.Close();

            //add combox to datagirdview
            //DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            //cmb.HeaderText = "Select Data";
            //cmb.Name = "cmb";
            //cmb.DefaultCellStyle.BackColor = Color.LightGray;
            //List<string> dataList = new List<string>(){"TX","RX","FUNC",};
            //foreach (var element in dataList)
            //{
            //    cmb.Items.Add(element);
            //}
            //ds.Tables[0].Columns.Add(cmb);

            dataGridView1.DataSource = ds.Tables[0];

            table = ds.Tables[0];

        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.dataGridView1.Rows[e.RowIndex].Selected = true;
                this.rowIndex = e.RowIndex;
                this.dataGridView1.CurrentCell = this.dataGridView1.Rows[e.RowIndex].Cells[1];
                this.contextMenuStrip1.Show(this.dataGridView1, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                upToolStripMenuItem.Enabled = false;
                downToolStripMenuItem.Enabled = false;
            }
            else
            {
                int currentIndex = dataGridView1.CurrentRow.Index;
                upToolStripMenuItem.Enabled = (dataGridView1.RowCount >= 2 && currentIndex > 0) ? true : false; ;
                downToolStripMenuItem.Enabled = (dataGridView1.RowCount >= 2 && currentIndex < (dataGridView1.RowCount - 2)) ? true : false;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName = null;

            // オープンファイルダイアログ
            SaveFileDialog SaveFileDlg = new SaveFileDialog()
            {
                FilterIndex = 0,
                RestoreDirectory = true,
                OverwritePrompt = true,
                CheckPathExists = true,
            };
            if (SaveFileDlg.ShowDialog() == DialogResult.OK)
            {
                fileName = SaveFileDlg.FileName;
            }
            StreamWriter serialWriter;
            serialWriter = new StreamWriter(fileName);
            XmlSerializer xmlWriter = new XmlSerializer(dataGridView1.DataSource.GetType());
            xmlWriter.Serialize(serialWriter, dataGridView1.DataSource);
            serialWriter.Close();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.dataGridView1.Rows[this.rowIndex].IsNewRow)
            {
                this.dataGridView1.Rows.RemoveAt(this.rowIndex);
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab && dataGridView1.CurrentCell.ColumnIndex == 1)
            {
                e.Handled = true;
                DataGridViewCell cell = dataGridView1.Rows[0].Cells[0];
                dataGridView1.CurrentCell = cell;
                dataGridView1.BeginEdit(true);
            }
        }

        private void upToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.SelectedCells[0].OwningColumn.Index;
            DataRow row = table.NewRow();
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                row[i] = dataGridView1.Rows[rowIndex].Cells[i].Value.ToString();
            }

            if (rowIndex > 0)
            {
                // delete the selected row
                table.Rows.RemoveAt(rowIndex);
                // add the new row 
                table.Rows.InsertAt(row, rowIndex - 1);
                //dataGridView1.ClearSelection();
                // select the new row
                dataGridView1.Rows[rowIndex - 1].Selected = true;
            }

        }

        private void downToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rowIndex = dataGridView1.SelectedCells[0].OwningRow.Index;
            DataRow row = table.NewRow();

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                row[i] = dataGridView1.Rows[rowIndex].Cells[i].Value.ToString();
            }

            if (rowIndex < dataGridView1.Rows.Count - 2)
            {
                table.Rows.RemoveAt(rowIndex);
                table.Rows.InsertAt(row, rowIndex + 1);
                dataGridView1.ClearSelection();
                dataGridView1.Rows[rowIndex + 1].Selected = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rowIndex = dataGridView1.SelectedCells[0].OwningRow.Index;

            // create a new row
            DataRow row = table.NewRow();
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                row[i] = dataGridView1.Rows[rowIndex].Cells[i].Value.ToString();
            }

            if (rowIndex > 0)
            {
                // delete the selected row
                table.Rows.RemoveAt(rowIndex);
                // add the new row 
                table.Rows.InsertAt(row, rowIndex - 1);
                dataGridView1.ClearSelection();
                // select the new row
                dataGridView1.Rows[rowIndex - 1].Selected = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addNode_Click(object sender, EventArgs e)
        {
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("FirstName", typeof(string));
            table.Columns.Add("LastName", typeof(string));
            table.Columns.Add("Age", typeof(int));

            // add rows
            table.Rows.Add(1, "Lam", "Last A", 10);
            table.Rows.Add(2, "Tuyen", "Last B", 30);
            table.Rows.Add(3, "Thuong", "Last C", 20);
            table.Rows.Add(4, "Lan", "Last D", 70);
            table.Rows.Add(5, "Anh", "Last E", 60);
            table.Rows.Add(6, "Ni", "Last F", 40);
            table.Rows.Add(7, "Aoe", "Last G", 80);
            table.Rows.Add(8, "Bie", "Last H", 50);

            dataGridView1.DataSource = table;

        }

        private void contextAddNode_Opening(object sender, CancelEventArgs e)
        {
        }

        private void treeView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point btnPosition = PointToScreen(this.treeView1.Location);

                Point startPoint = new Point(btnPosition.X, btnPosition.Y + this.button1.Height);

                this.contextAddNode.Show(startPoint);
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selectedItem = cbFilter.SelectedItem.ToString();
            DataView dv = table.DefaultView;
            if (dv != null)
            {
                if (selectedItem !="None")
                {
                    //dv.RowFilter = string.Format("Age Like '%{0}'", selectedItem);
                    string cl = table.Columns[2].ToString();
                    dv.RowFilter = string.Format(cl+" = {0}", selectedItem);
                    
                    
                    //dv.RowFilter = string.Format("Age  = {0}", selectedItem);
                    dataGridView1.DataSource = dv;
                }
                else
                {
                    dataGridView1.DataSource = table;
                }
            }

        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                 string load = table.Columns[2].ToString();
                cbFilter.Items.Add(table.Rows[i][""+load+""]);
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {            
            //DataView dv = table.DefaultView;
            //dv.RowFilter = string.Format("Id = {0}", tbSearch.Text);
            //dataGridView1.DataSource = dv;

            //(dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("FirstName like '%{0}%'", tbSearch.Text);]

            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format(table.Columns[1].ToString()+" like '%{0}%'", tbSearch.Text);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                tabPage1.BackColor = Color.LightGray;
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                tabPage2.BackColor = Color.BlueViolet;
            }
            
        }

       

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            foreach (string file in files)
            {
                DataSet ds = new DataSet();
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(DataSet));
                FileStream readStream = new FileStream(file, FileMode.Open);
                ds = (DataSet)xmlSerializer.Deserialize(readStream);
                readStream.Close();
                dataGridView1.DataSource = ds.Tables[0];

                table = ds.Tables[0];
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void ckId_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);

        }

        private void ckName_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            tabPage1.BackColor = Color.FromArgb(Convert.ToInt32(trackBar1.Value), Convert.ToInt32(trackBar1.Value), Convert.ToInt32(trackBar1.Value), Convert.ToInt32(trackBar1.Value));

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.BackColor = Color.LightSkyBlue;
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
        }

        private void btClear_Click(object sender, EventArgs e)
        {
         
            if (this.dataGridView1.DataSource != null)
            {
                dataGridView1.DataSource = null;
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
        }

        private void btShow_Click(object sender, EventArgs e)
        {
            string sql = "Select InvoiceNo from Receipt";
            SqlConnection connection = new SqlConnection(@"Data Source=TUYENNT13-HP\SQLEXPRESS;Initial Catalog=Demo;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter(sql, connection);
           

            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;

            //手工追加

            //DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            //cmb.HeaderText = "Fill Data";
            //cmb.Name = "cmb";
            //cmb.MaxDropDownItems = 4;
            //cmb.Items.Add("TX");
            //cmb.Items.Add("RX");
            //dataGridView2.Columns.Add(cmb);

            // リストで追加

            ArrayList StringList = new ArrayList();

            SqlDataAdapter sda1 = new SqlDataAdapter("Select PartNo From Invoice", connection);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);

            foreach (DataRow item in dt1.Rows)
            {
                StringList.Add(item["PartNo"].ToString());
            }
            //Add Combobox
            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            cmb.HeaderText = "Fill Data";
            cmb.Name = "cmb";
            cmb.DataSource = StringList;
            //cmb.DataSource = Enum.GetNames(typeof(Propellants));
            cmb.Width = 70;
            dataGridView2.Columns.Add(cmb);

            //Add Checkbox
            DataGridViewCheckBoxColumn ck = new DataGridViewCheckBoxColumn();
            ck.HeaderText = "状態";
            ck.Width = 70;

            dataGridView2.Columns.Add(ck);
            dataGridView2.Rows[1].Cells[2].Value = true;

            //Add Button
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "実行";
            btn.Text = "Up/Down";
            btn.Width = 40;
            dataGridView2.Columns.Add(btn);

            //Add Image list
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            //Image image = Image.FromFile("Image Path");
            Image image = (imageList1.Images)[0];
            img.Image = image;
            img.Width = 50;
            dataGridView2.Columns.Add(img);
            img.HeaderText = "Image";


            DataGridViewComboBoxColumn cmb2 = new DataGridViewComboBoxColumn();
            cmb2.HeaderText = "Chanel";
            cmb2.Name = "cmb2";
            //cmb2.DataSource = StringList;
            //cmb.DataSource = Enum.GetNames(typeof(Propellants));
            cmb2.Width = 70;
            dataGridView2.Columns.Add(cmb2);


        }

        private void btChange_Click(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow row in dataGridView2.Rows)
            //{
            //    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[2];
            //    if (chk.Selected == false )
            //    {
            //        chk.Value = chk.TrueValue;
            //    }
            //    else if (chk.Selected == true)
            //    {
            //        chk.Value = chk.FalseValue;
            //    }

            //}
            //dataGridView2.EndEdit();

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                rowIndex = dataGridView2.SelectedCells[1].OwningRow.Index;
                dataGridView2.Rows[1].Cells[2].Value = true;
                //dataGridView2.Rows[e.RowIndex].Cells[1].ReadOnly = true;
                //dataGridView2.Rows[e.RowIndex].Cells[1].Style.BackColor = SystemColors.Window;
            }

            //for (int i = 0; i < dataGridView2.RowCount; i++)
            //{
            //    if (dataGridView2.Rows[i].Cells[2].Value = true)
            //    {

            //    }
            //    dataGridView2.Rows[i].Cells[2].Value = true;
            //}

        }
        //Button click action

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3) //make sure button index here
            {
                
                dataGridView2.CurrentRow.Cells[1].ReadOnly = true;
                dataGridView2.CurrentRow.Cells[1].Style.BackColor = Color.Blue;
                dataGridView2.CurrentRow.Cells[4].Value = (imageList1.Images)[1]; ;
            }
        }

        //Select combobox action
        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView2.CurrentCell.ColumnIndex ==1)
            {
                //string selectDevice = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                //if (selectDevice == "50120065")
                //{

                //}
                List<string> channelList = new List<string>{"ss","bb" };
                List<string> channelList1 = new List<string> { "aa", "tt" };


                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    DataGridViewComboBoxCell comboBoxCell1 = (DataGridViewComboBoxCell)row.Cells[1];
                    DataGridViewComboBoxCell comboBoxCell5 = (DataGridViewComboBoxCell)row.Cells[5];

                  //  for (int i = 0; i < dataGridView2.RowCount - 1; i++)
                   // {
                       // string cmbvalue = dataGridView2.Rows[i].Cells[1].Value.ToString();
                        //int SelecteVal = Convert.ToInt32(dataGridView2.Rows[0].Cells[1].Value);
                        string SelecteText = Convert.ToString((dataGridView2.Rows[0].Cells[1] as DataGridViewComboBoxCell).FormattedValue.ToString());

                        if (SelecteText == "50120065")
                        {
                            comboBoxCell5.DataSource = channelList;
                        }
                  //  }
                }

               

            }
        }
        // Get Selected Value from that ComboBox
        void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedValue != null)
            {
                string sId = ((ComboBox)sender).SelectedValue.ToString();
                string sName = ((ComboBox)sender).Text.ToString();
            }
        }
    }

    //enumで追加
    enum Propellants
    {
        Chemical = 10,
        Solar = 20,
        Laser = 30,
        Nuclear = 40,
        Plasma = 50,
        AntiMatter = 60
    }
}
