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
    public partial class Home : UserControl
    {
        List<SanPham> sanPhams = new List<SanPham>();
       
        public Home()
        {
            InitializeComponent();
            LoadKho();
        }

        private void LoadKho() {
            MessageBox.Show("Test");
            KetNoi.SanPhamDAO spDAO = new KetNoi.SanPhamDAO();
            sanPhams = spDAO.layDS();
            NoiBat();
            KhuyenMai();
            DienThoai();
            LinhKien();
        }

        //CAC MUC TRONG APP
        private void NoiBat() {
            // San pham moi la khi no chua co trong kho tu truoc den nay 
            //
            FlistNoiBat.Controls.Clear();
            int MAX_SP = 5;
            for (int i = 0; i < MAX_SP; i++)
            {
                ChiTietSanPham_1 chiTietSanPham_1 = new ChiTietSanPham_1(sanPhams[i]);
                FlistNoiBat.Controls.Add(chiTietSanPham_1);
            }
        }
        private void DienThoai() {
            List<SanPham> dt = sanPhams.Where((s) => { return s.Loai == LoaiSanPham.DIEN_THOAI; }).ToList();

            //Hien Thi moi lan la 20 san pham

            int MAX_SP = 10;
            MAX_SP = dt.Count < MAX_SP ? dt.Count : MAX_SP;
            FlistDT.Controls.Clear();
            for (int i = 0; i < MAX_SP; i++)
            {
                ChiTietSanPham_1 chiTietSanPham_1 = new ChiTietSanPham_1(dt[i]);
                FlistDT.Controls.Add(chiTietSanPham_1);
            }
        }
        private void LinhKien()
        {
            List<SanPham> lk = sanPhams.Where((s) => { return s.Loai == LoaiSanPham.LINH_KIEN; }).ToList();

            int MAX_SP = 10;
            MAX_SP = lk.Count < MAX_SP ? lk.Count : MAX_SP;
            FlistLK.Controls.Clear();
            for (int i = 0; i < MAX_SP; i++)
            {
                ChiTietSanPham_1 chiTietSanPham_1 = new ChiTietSanPham_1(lk[i]);
                FlistLK.Controls.Add(chiTietSanPham_1);
            }
        }
        private void KhuyenMai()
        {
            int MAX_SP = 5;
            FlistKM.Controls.Clear();

            for (int i = 0; i < MAX_SP; i++)
            {
                ChiTietSanPham_1 chiTietSanPham_1 = new ChiTietSanPham_1(sanPhams[i]);
                FlistKM.Controls.Add(chiTietSanPham_1);
            }

        }
    }
}
