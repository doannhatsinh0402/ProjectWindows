
namespace QuanLySinhVien.GUI
{
    partial class form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtMaMH = new System.Windows.Forms.TextBox();
            this.txtTenMH = new System.Windows.Forms.TextBox();
            this.txtSoTC = new System.Windows.Forms.TextBox();
            this.txtMaMHTQ = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.chkNam = new System.Windows.Forms.CheckBox();
            this.chkNu = new System.Windows.Forms.CheckBox();
            this.dtpickerNS = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(293, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // txtMaMH
            // 
            this.txtMaMH.Location = new System.Drawing.Point(329, 40);
            this.txtMaMH.Name = "txtMaMH";
            this.txtMaMH.Size = new System.Drawing.Size(100, 20);
            this.txtMaMH.TabIndex = 1;
            // 
            // txtTenMH
            // 
            this.txtTenMH.Location = new System.Drawing.Point(329, 77);
            this.txtTenMH.Name = "txtTenMH";
            this.txtTenMH.Size = new System.Drawing.Size(100, 20);
            this.txtTenMH.TabIndex = 2;
            // 
            // txtSoTC
            // 
            this.txtSoTC.Location = new System.Drawing.Point(329, 120);
            this.txtSoTC.Name = "txtSoTC";
            this.txtSoTC.Size = new System.Drawing.Size(100, 20);
            this.txtSoTC.TabIndex = 3;
            // 
            // txtMaMHTQ
            // 
            this.txtMaMHTQ.Location = new System.Drawing.Point(329, 158);
            this.txtMaMHTQ.Name = "txtMaMHTQ";
            this.txtMaMHTQ.Size = new System.Drawing.Size(100, 20);
            this.txtMaMHTQ.TabIndex = 4;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(329, 200);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(205, 200);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 6;
            this.btnXoa.Text = "Xoa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(105, 200);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 7;
            this.btnSua.Text = "Sua";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // chkNam
            // 
            this.chkNam.AutoSize = true;
            this.chkNam.Location = new System.Drawing.Point(25, 161);
            this.chkNam.Name = "chkNam";
            this.chkNam.Size = new System.Drawing.Size(48, 17);
            this.chkNam.TabIndex = 8;
            this.chkNam.Text = "Nam";
            this.chkNam.UseVisualStyleBackColor = true;
            this.chkNam.Click += new System.EventHandler(this.chkNam_Click);
            // 
            // chkNu
            // 
            this.chkNu.AutoSize = true;
            this.chkNu.Location = new System.Drawing.Point(25, 184);
            this.chkNu.Name = "chkNu";
            this.chkNu.Size = new System.Drawing.Size(40, 17);
            this.chkNu.TabIndex = 9;
            this.chkNu.Text = "Nu";
            this.chkNu.UseVisualStyleBackColor = true;
            this.chkNu.Click += new System.EventHandler(this.chkNu_Click);
            // 
            // dtpickerNS
            // 
            this.dtpickerNS.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpickerNS.Location = new System.Drawing.Point(329, 12);
            this.dtpickerNS.Name = "dtpickerNS";
            this.dtpickerNS.Size = new System.Drawing.Size(100, 20);
            this.dtpickerNS.TabIndex = 10;
            // 
            // form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 247);
            this.Controls.Add(this.dtpickerNS);
            this.Controls.Add(this.chkNu);
            this.Controls.Add(this.chkNam);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtMaMHTQ);
            this.Controls.Add(this.txtSoTC);
            this.Controls.Add(this.txtTenMH);
            this.Controls.Add(this.txtMaMH);
            this.Controls.Add(this.dataGridView1);
            this.Name = "form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtMaMH;
        private System.Windows.Forms.TextBox txtTenMH;
        private System.Windows.Forms.TextBox txtSoTC;
        private System.Windows.Forms.TextBox txtMaMHTQ;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.CheckBox chkNam;
        private System.Windows.Forms.CheckBox chkNu;
        private System.Windows.Forms.DateTimePicker dtpickerNS;
    }
}

