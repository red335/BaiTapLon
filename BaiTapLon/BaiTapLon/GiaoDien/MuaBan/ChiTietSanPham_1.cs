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
        HoTro.TatCaDelegate.AddOnHome Mo;
        public ChiTietSanPham_1()
        {
            InitializeComponent();
         //   Load();
        }
        public ChiTietSanPham_1(SanPham sanPham, HoTro.TatCaDelegate.AddOnHome Mo)
        {
            InitializeComponent();
            this.sanPham = sanPham;
            this.Mo = Mo;
            Loaded();
        }

     
        private void Loaded() {
            pbAnh.Image = Image.FromFile(sanPham.DuongDanHinhAnh);
            lbTen.Text = sanPham.TenSP;
            lbGiaBan.Text = (sanPham.GiaBan*1000) .ToString("#,###") + " VND";
            this.Click += Click_Panel;
            foreach (Control control in this.Controls)
            {
                control.Click += Child_Click;
                control.MouseHover += Child_Hover;
                control.MouseLeave += Child_Leave;
            }
        }

        //ADD SU KIEN
        private void Child_Click(object sender, EventArgs e) {
            Click_Panel(this, EventArgs.Empty);
        }
        private void Click_Panel(object sender, EventArgs e) {
            this.Mo(MuaBan_Form.SANPHAM_FORM, new SanPham_Form(sanPham));
        }


        private void Child_Hover(object sender, EventArgs e)
        {
            Panel_Hover(this, EventArgs.Empty);
        }
        private void Child_Leave(object sender, EventArgs e)
        {
            Panel_Leave(this, EventArgs.Empty);
        }


        private void Panel_Hover(object sender, EventArgs e)
        {
            this.BackColor = Color.Gainsboro;
        }
        private void Panel_Leave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }
    }
}
