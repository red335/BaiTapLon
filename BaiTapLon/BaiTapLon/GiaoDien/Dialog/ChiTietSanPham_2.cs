using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaiTapLon.Model;
namespace BaiTapLon.GiaoDien.Dialog
{
    public partial class ChiTietSanPham_2 : Form
    {
        SanPham sanPham;
        public ChiTietSanPham_2(SanPham sanPham)
        {
            InitializeComponent();

            this.sanPham = sanPham;
        }
        private void HienThiThongTinCoBan() { 
           
        }
    }
}
