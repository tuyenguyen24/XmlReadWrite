using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadWriteXml
{
    public partial class AboutDialog : Form
    {
        public AboutDialog(List<string[]> stringsMain, List<string[]> stringsReference)
        {
            InitializeComponent();
            // カラム設定
            ColumnHeader columnName = new ColumnHeader();
            ColumnHeader columnType = new ColumnHeader();
            columnName.Text = "Name";
            columnName.Width = 150;
            columnType.Text = "Information";
            columnType.Width = 400;
            ColumnHeader[] colHeaderRegValue =
                { columnName, columnType};
            listView1.Columns.AddRange(colHeaderRegValue);
            ColumnHeader columnName2 = new ColumnHeader();
            ColumnHeader columnType2 = new ColumnHeader();
            columnName2.Text = "Name";
            columnName2.Width = 150;
            columnType2.Text = "Information";
            columnType2.Width = 400;
            ColumnHeader[] colHeaderRegValue2 =
                { columnName2, columnType2};
            listView2.Columns.AddRange(colHeaderRegValue2);
            // カラム非表示
            listView1.HeaderStyle = ColumnHeaderStyle.None;
            listView2.HeaderStyle = ColumnHeaderStyle.None;
            foreach (var element in stringsMain)
            {
                listView1.Items.Add(new ListViewItem(element));
            }

            int index = 0;
            Color backColor = Color.AliceBlue;
            listView2.Items.Clear();
            foreach (var element in stringsReference)
            {
                if (index % 6 == 0)
                {
                    if (((index / 6) & 0x01) == 0)
                    {
                        backColor = Color.AliceBlue;
                    }
                    else
                    {
                        backColor = Color.SeaShell;
                    }
                }
                listView2.Items.Add(new ListViewItem(element));
                listView2.Items[index].BackColor = backColor;
                index++;
            }
        }
    }
}
