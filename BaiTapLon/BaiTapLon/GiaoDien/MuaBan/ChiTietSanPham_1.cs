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
    public delegate void MoSanPham_form(UserControl userControl);
    public partial class ChiTietSanPham_1 : UserControl
    {
              
        SanPham sanPham;
        MoSanPham_form Mo;
        public ChiTietSanPham_1()
        {
            InitializeComponent();
         //   Load();
        }
        public ChiTietSanPham_1(SanPham sanPham,MoSanPham_form Mo)
        {
            InitializeComponent();
            this.sanPham = sanPham;
            this.Mo = Mo;
            Load();
        }
        private void Load() {
            pbAnh.Image = Image.FromFile(sanPham.DuongDanHinhAnh);
            lbTen.Text = sanPham.TenSP;
            lbGiaBan.Text = (sanPham.GiaBan*1000) .ToString("#,###") + " VND";
            this.Click += Click_Panel;
            foreach (Control control in this.Controls)
            {
                control.Click += Child_Click;
            }
        }

        //ADD SU KIEN
        private void Child_Click(object sender, EventArgs e) {
            Click_Panel(this, EventArgs.Empty);
        }
        private void Click_Panel(object sender, EventArgs e) {
            this.Mo( new SanPham_Form(sanPham));
        }
    }
}
