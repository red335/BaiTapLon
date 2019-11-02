using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaiTapLon.Model;
namespace BaiTapLon.GiaoDien.MuaBan
{
    public partial class ChiTietSanPham_1 : UserControl
    {
        SanPham sanPham;
        public ChiTietSanPham_1()
        {
            InitializeComponent();
        }
        public ChiTietSanPham_1(SanPham sanPham)
        {
            InitializeComponent();
            this.sanPham = sanPham;
        }
    }
}
