using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using BaiTapLon.GiaoDien.MuaBan;
using System.Windows.Forms;

namespace BaiTapLon
{

    public partial class Form1 : Form
    {
        MuaBan_Form muaBan_Form = null;
        public Form1()
        {
            InitializeComponent();
            muaBan_Form = new MuaBan_Form(Body.Size);
            pbMinimum.Click += btnMinimum_Click;
            pbMinimum.MouseHover += btnMinimum_Hover;
            pbMinimum.MouseLeave += btnMinimum_Leave;
            Add_Main_Form();
        }
        private void Add_Main_Form() {
            Body.Controls.Add(muaBan_Form);
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
