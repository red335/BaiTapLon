using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLon.GiaoDien.MuaBan
{
    public partial class SanPham_Form : UserControl
    {
        public SanPham_Form()
        {
            InitializeComponent();
        }



        //=======================TAT CA CAC SU KIEN ====================\\
        #region SUKIEN CUA FORM VA CONTROLS
        private void SanPham_Form_Load(object sender, EventArgs e)
        {
            // chon binh luan
            cbbComment_LoaiKhach.SelectedIndex = 0;
            cbbComment_Sao.SelectedIndex = 0;
            cbbComment_ThoiGian.SelectedIndex = 0;
        }
        #endregion
    }
}
