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
    public partial class GioHang_ChiTietSanPham : UserControl
    {
        private DonHang donHang;
        private HoTro.TatCaDelegate.XuLySoLuongTrongGioHang xuLy;
        public GioHang_ChiTietSanPham()
        {
            InitializeComponent();
        }
        public GioHang_ChiTietSanPham(DonHang donHang, HoTro.TatCaDelegate.XuLySoLuongTrongGioHang xuLy)
        {
            InitializeComponent();
            this.donHang = donHang;
            this.xuLy = xuLy;
            HienThi();
        }
        public GioHang_ChiTietSanPham(DonHang donHang)
        {
            InitializeComponent();
            this.donHang = donHang;
            btnAddSP.Visible = btnSUBSP.Visible = false;
            HienThi();
        }
        private void HienThi() {
            txtSLSP.Text = donHang.SoLuong.ToString();
            lbGia.Text = (donHang.SanPhamMua.GiaBan *1000).ToString("#,###")+" VND";
            lbTen.Text = donHang.SanPhamMua.TenSP;
            lbHangSX.Text = donHang.SanPhamMua.HangSanXuat.TenHSX;
            pictureBox1.Image = Image.FromFile(DonHang1.SanPhamMua.DuongDanHinhAnh);

        }

        public DonHang DonHang1 { get => donHang; set => donHang = value; }

        //Giam soLuong
        private void btnSUBSP_Click(object sender, EventArgs e)
        {
            DonHang1.SoLuong -= 1;
            xuLy(-1,DonHang1.SanPhamMua.GiaBan * -1);
            txtSLSP.Text = DonHang1.SoLuong.ToString();
        }
        //tang soLuong
        private void btnAddSP_Click(object sender, EventArgs e)
        {
            DonHang1.SoLuong += 1;
            xuLy(1,  DonHang1.SanPhamMua.GiaBan );
            txtSLSP.Text = DonHang1.SoLuong.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }
    }
}
