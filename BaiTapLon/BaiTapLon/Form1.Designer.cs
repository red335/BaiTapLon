namespace BaiTapLon
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pnHeader = new System.Windows.Forms.Panel();
            this.pbMinimum = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.Body = new System.Windows.Forms.Panel();
            this.header_Form1 = new BaiTapLon.GiaoDien.MuaBan.Header_Form();
            this.pnHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimum)).BeginInit();
            this.SuspendLayout();
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pnHeader.Controls.Add(this.pbMinimum);
            this.pnHeader.Controls.Add(this.header_Form1);
            this.pnHeader.Controls.Add(this.btnExit);
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHeader.Location = new System.Drawing.Point(0, 0);
            this.pnHeader.Margin = new System.Windows.Forms.Padding(0);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(1143, 71);
            this.pnHeader.TabIndex = 0;
            // 
            // pbMinimum
            // 
            this.pbMinimum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMinimum.Image = ((System.Drawing.Image)(resources.GetObject("pbMinimum.Image")));
            this.pbMinimum.Location = new System.Drawing.Point(1071, 12);
            this.pbMinimum.Name = "pbMinimum";
            this.pbMinimum.Size = new System.Drawing.Size(27, 23);
            this.pbMinimum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMinimum.TabIndex = 2;
            this.pbMinimum.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(1103, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(27, 23);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Body
            // 
            this.Body.BackColor = System.Drawing.Color.White;
            this.Body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Body.Location = new System.Drawing.Point(0, 71);
            this.Body.Margin = new System.Windows.Forms.Padding(0);
            this.Body.Name = "Body";
            this.Body.Size = new System.Drawing.Size(1143, 667);
            this.Body.TabIndex = 2;
            // 
            // header_Form1
            // 
            this.header_Form1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.header_Form1.Location = new System.Drawing.Point(0, 0);
            this.header_Form1.Margin = new System.Windows.Forms.Padding(0);
            this.header_Form1.Name = "header_Form1";
            this.header_Form1.Size = new System.Drawing.Size(1032, 71);
            this.header_Form1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 738);
            this.ControlBox = false;
            this.Controls.Add(this.Body);
            this.Controls.Add(this.pnHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnHeader;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel Body;
        private GiaoDien.MuaBan.Header_Form header_Form1;
        private System.Windows.Forms.PictureBox pbMinimum;
    }
}

