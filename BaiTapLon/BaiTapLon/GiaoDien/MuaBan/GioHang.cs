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
    public partial class GioHang : Form
    {
        private List<DonHang> MyGioHang = new List<DonHang>();
        private Color color1 = Color.WhiteSmoke;
        private int TongTien = 0;
        private int TongSoLuong = 0;
        public GioHang()
        {
            InitializeComponent();
            HienThi();
            TinhToan();
        }

        private void LayGioHang() {
            MyGioHang = new KetNoi.GioHangDAO().layGioHang("3");
        }
        private void HienThi() {
            LayGioHang();
            Flist.Controls.Clear();
            if (MyGioHang == null || MyGioHang.Count == 0)
            {
                Label label = new Label();
                label.Text = "Không có sản phẩm nào";
                label.Size = new Size(Flist.Size.Width - 10, 80);
                label.Font = new Font("Tahoma", 9.5F, FontStyle.Bold);
                label.TextAlign = ContentAlignment.MiddleCenter;

                Flist.Controls.Add(label);
            }
            else for (int i = 0; i < MyGioHang.Count; i++)
                {
                    GioHang_ChiTietSanPham ct = new GioHang_ChiTietSanPham(MyGioHang[i],CapNhatSoLuong);
                    if (i % 2 == 1) ct.BackColor = color1;
                    Flist.Controls.Add(ct);
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CapNhatSoLuong(int soLuong, int soTien) {
            TongTien += soTien;
            TongSoLuong += soLuong;
            lbSoLuong.Text = TongSoLuong.ToString() + " sản phẩm";
            lbTongTien.Text = (TongTien * 1000).ToString("#,###") + " VND";
        }

        //TINH TONG TIEN
        private void TinhToan() {
           
            for (int i = 0; i < MyGioHang.Count; i++) {
                TongTien += MyGioHang[i].SoLuong * MyGioHang[i].SanPhamMua.GiaBan;
                TongSoLuong += MyGioHang[i].SoLuong;
            }
            lbSoLuong.Text = TongSoLuong.ToString()+ " sản phẩm";
            lbTongTien.Text = (TongTien*1000).ToString("#,###") + " VND";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Khi mua hàng bạn hãy chắc chắn các điều sau: \n1. Hãy kiểm lại các sản phẩm mà bạn đã đặt mua ở shop chúng tôi" +
            //    " chúng đã đúng với nhu cầu bạn chưa \n2. Hãy kiểm tra lại thông tin xác nhận tại mục TÀI KHOẢN \n" +
            //    "3. Hãy xem lại mục hình thức thanh toán cho phù hợp với bản thân cũng như đảm bảo cho uy tín chúng tôi\n" +
            //    "Bạn có muốn tiếp tục", "Thanh Toán", MessageBoxButtons.YesNo) == DialogResult.Yes) {
            //    MessageBox.Show("Bạn đã mua thành công!!");
            //}

            int tt = radioButton1.Checked ? HoTro.TapCacHang.GIAO_DICH_ONLINE : HoTro.TapCacHang.GIAO_DICH_TRUC_TIEP;
            this.Close();
            new XacNhanGiaoDich(MyGioHang,TongTien,tt).ShowDialog();
          
             
        }

       
    }
}
