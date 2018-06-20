namespace ReadWriteXml
{
    partial class settingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.ckLimit = new System.Windows.Forms.CheckBox();
            this.ckAutoSave = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.ckLimit);
            this.groupBox1.Controls.Add(this.ckAutoSave);
            this.groupBox1.Location = new System.Drawing.Point(72, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(581, 240);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Logging";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(201, 67);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 19);
            this.numericUpDown1.TabIndex = 2;
            // 
            // ckLimit
            // 
            this.ckLimit.AutoSize = true;
            this.ckLimit.Location = new System.Drawing.Point(38, 67);
            this.ckLimit.Name = "ckLimit";
            this.ckLimit.Size = new System.Drawing.Size(74, 16);
            this.ckLimit.TabIndex = 1;
            this.ckLimit.Text = "ViewLimit";
            this.ckLimit.UseVisualStyleBackColor = true;
            this.ckLimit.CheckedChanged += new System.EventHandler(this.ckLimit_CheckedChanged);
            // 
            // ckAutoSave
            // 
            this.ckAutoSave.AutoSize = true;
            this.ckAutoSave.Location = new System.Drawing.Point(38, 32);
            this.ckAutoSave.Name = "ckAutoSave";
            this.ckAutoSave.Size = new System.Drawing.Size(73, 16);
            this.ckAutoSave.TabIndex = 0;
            this.ckAutoSave.Text = "AutoSave";
            this.ckAutoSave.UseVisualStyleBackColor = true;
            // 
            // settingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 340);
            this.Controls.Add(this.groupBox1);
            this.Name = "settingForm";
            this.Text = "Setting";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.CheckBox ckLimit;
        private System.Windows.Forms.CheckBox ckAutoSave;
    }
}