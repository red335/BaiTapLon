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
         //   Load();
        }
        public ChiTietSanPham_1(SanPham sanPham)
        {
            InitializeComponent();
            this.sanPham = sanPham;
            Load();
        }
        private void Load() {
            pbAnh.Image = Image.FromFile(sanPham.DuongDanHinhAnh);
            lbTen.Text = sanPham.TenSP;
            lbGiaBan.Text = (sanPham.GiaBan*1000) .ToString("#,###") + " VND";
        
        }
    }
}
