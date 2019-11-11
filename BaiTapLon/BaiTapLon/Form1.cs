using System;
using System.Collections.Generic;
using System.ComponentModel;
using BaiTapLon.KetNoi;
using System.Drawing;
using System.Linq;
using BaiTapLon.GiaoDien.MuaBan;
using System.Windows.Forms;
using System.IO;

namespace BaiTapLon
{

    public partial class Form1 : Form
    {
        MuaBan_Form muaBan_Form = null;
        public Form1()
        {
            InitializeComponent();
          
            pbMinimum.Click += btnMinimum_Click;
            pbMinimum.MouseHover += btnMinimum_Hover;
            pbMinimum.MouseLeave += btnMinimum_Leave;
            Add_Main_Form();
        }
        private void Add_Main_Form() {
            Body.Controls.Clear();
            Body.Controls.Add(new MuaBan_Form(Body.Size));
            
        }


        //===============EVENT BUTTON===========\\
        #region Event Button
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnMinimum_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnMinimum_Hover(object sender, EventArgs e)
        {
            (sender as PictureBox).BackColor = Color.FromArgb(0, 122, 244);
        }
        private void btnMinimum_Leave(object sender, EventArgs e)
        { 
            (sender as PictureBox).BackColor = pnHeader.BackColor;
        }
        #endregion
    }
}
