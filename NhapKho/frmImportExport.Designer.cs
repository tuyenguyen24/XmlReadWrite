namespace NhapKho
{
    partial class frmImportExport
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.btImport = new System.Windows.Forms.Button();
            this.btExport = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btLoad = new System.Windows.Forms.Button();
            this.btShow = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.txtFilepath = new System.Windows.Forms.TextBox();
            this.btShow2 = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btImport2 = new System.Windows.Forms.Button();
            this.btLoad2 = new System.Windows.Forms.Button();
            this.btClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // btImport
            // 
            this.btImport.Location = new System.Drawing.Point(605, 16);
            this.btImport.Name = "btImport";
            this.btImport.Size = new System.Drawing.Size(75, 23);
            this.btImport.TabIndex = 0;
            this.btImport.Text = "Import";
            this.btImport.UseVisualStyleBackColor = true;
            this.btImport.Click += new System.EventHandler(this.btImport_Click);
            // 
            // btExport
            // 
            this.btExport.Location = new System.Drawing.Point(921, 16);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(75, 23);
            this.btExport.TabIndex = 1;
            this.btExport.Text = "Export";
            this.btExport.UseVisualStyleBackColor = true;
            this.btExport.Click += new System.EventHandler(this.btExport_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(716, 51);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(408, 509);
            this.dataGridView1.TabIndex = 4;
            // 
            // btLoad
            // 
            this.btLoad.Location = new System.Drawing.Point(716, 16);
            this.btLoad.Name = "btLoad";
            this.btLoad.Size = new System.Drawing.Size(87, 23);
            this.btLoad.TabIndex = 5;
            this.btLoad.Text = "LoadByForm";
            this.btLoad.UseVisualStyleBackColor = true;
            this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
            // 
            // btShow
            // 
            this.btShow.Location = new System.Drawing.Point(12, 12);
            this.btShow.Name = "btShow";
            this.btShow.Size = new System.Drawing.Size(83, 23);
            this.btShow.TabIndex = 6;
            this.btShow.Text = "ShowInvoice";
            this.btShow.UseVisualStyleBackColor = true;
            this.btShow.Click += new System.EventHandler(this.btShow_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 51);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 21;
            this.dataGridView2.Size = new System.Drawing.Size(345, 509);
            this.dataGridView2.TabIndex = 7;
            // 
            // txtFilepath
            // 
            this.txtFilepath.Location = new System.Drawing.Point(113, 14);
            this.txtFilepath.Name = "txtFilepath";
            this.txtFilepath.Size = new System.Drawing.Size(100, 19);
            this.txtFilepath.TabIndex = 8;
            // 
            // btShow2
            // 
            this.btShow2.Location = new System.Drawing.Point(376, 14);
            this.btShow2.Name = "btShow2";
            this.btShow2.Size = new System.Drawing.Size(82, 23);
            this.btShow2.TabIndex = 9;
            this.btShow2.Text = "ShowReceipt";
            this.btShow2.UseVisualStyleBackColor = true;
            this.btShow2.Click += new System.EventHandler(this.btShow2_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(376, 51);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowTemplate.Height = 21;
            this.dataGridView3.Size = new System.Drawing.Size(323, 509);
            this.dataGridView3.TabIndex = 10;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(486, 18);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(100, 19);
            this.txtPath.TabIndex = 11;
            // 
            // btImport2
            // 
            this.btImport2.Location = new System.Drawing.Point(248, 12);
            this.btImport2.Name = "btImport2";
            this.btImport2.Size = new System.Drawing.Size(75, 23);
            this.btImport2.TabIndex = 12;
            this.btImport2.Text = "Import";
            this.btImport2.UseVisualStyleBackColor = true;
            this.btImport2.Click += new System.EventHandler(this.btImport2_Click);
            // 
            // btLoad2
            // 
            this.btLoad2.Location = new System.Drawing.Point(820, 16);
            this.btLoad2.Name = "btLoad2";
            this.btLoad2.Size = new System.Drawing.Size(75, 23);
            this.btLoad2.TabIndex = 13;
            this.btLoad2.Text = "LoadbyDB";
            this.btLoad2.UseVisualStyleBackColor = true;
            this.btLoad2.Click += new System.EventHandler(this.btLoad2_Click);
            // 
            // btClear
            // 
            this.btClear.Location = new System.Drawing.Point(1022, 16);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(75, 23);
            this.btClear.TabIndex = 14;
            this.btClear.Text = "Clear";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // frmImportExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 572);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.btLoad2);
            this.Controls.Add(this.btImport2);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.btShow2);
            this.Controls.Add(this.txtFilepath);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.btShow);
            this.Controls.Add(this.btLoad);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btExport);
            this.Controls.Add(this.btImport);
            this.Name = "frmImportExport";
            this.Text = "NhapKho";
            this.Load += new System.EventHandler(this.frmImportExport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btImport;
        private System.Windows.Forms.Button btExport;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btLoad;
        private System.Windows.Forms.Button btShow;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox txtFilepath;
        private System.Windows.Forms.Button btShow2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btImport2;
        private System.Windows.Forms.Button btLoad2;
        private System.Windows.Forms.Button btClear;
    }
}

