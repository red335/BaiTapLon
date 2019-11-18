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
namespace BaiTapLon.GiaoDien.MuaBan
{
    public partial class XacNhanGiaoDich : Form
    {
        List<DonHang> gioHang;
        long TongTien;
        int hinhThucThanhToan;
        public XacNhanGiaoDich()
        {
            InitializeComponent();
        }
        public XacNhanGiaoDich(List<DonHang>gioHang,long tt, int httt)
        {
            InitializeComponent();
            this.gioHang = gioHang;
            TongTien = tt;
            hinhThucThanhToan = httt;
            Detail_Bill();
        }

        private void Detail_Bill() {
            lbThanhTien.Text = (TongTien * 1000).ToString("#,###") + " VND";
            lbHTthanhToan.Text = "ONLINE";
            if (hinhThucThanhToan == HoTro.TapCacHang.GIAO_DICH_TRA_GOP)
                lbHTthanhToan.Text = "Trả Góp";
            else if (hinhThucThanhToan == HoTro.TapCacHang.GIAO_DICH_TRUC_TIEP)
                lbHTthanhToan.Text = "Trực Tiếp";

            foreach (DonHang donHang in gioHang) {
                Label label = new Label();
                label.Text = "Sản Phẩm: " + donHang.SanPhamMua.TenSP + " , Số Lượng: " + donHang.SoLuong.ToString();
                label.Font = new Font("Arial",9.5F,FontStyle.Regular);
                label.Size = new Size(Flist.Width - 30, 50);
                Flist.Controls.Add(label);
                Panel panel = new Panel();
                panel.Size = new Size(Flist.Width - 30, 1);
                panel.BackColor = Color.Gainsboro;
                Flist.Controls.Add(panel);

            }
                    
        }
        //Huy
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Xac Nhan
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã mua thành công");
            this.Close();
        }
    }
}
