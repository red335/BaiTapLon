using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon.Model
{   public enum LoaiSanPham{DIEN_THOAI, LINH_KIEN};
    public class SanPham
    {
       
        private string maSP;
        private string tenSP;
        private int tonKho;
        private int giaDoc;
        private int giaBan;
        private LoaiSanPham loai;
        private string duongDanHinhAnh;
        private string chiTiet;
        private HangSX hangSanXuat;
        private Rate rating; 
        public string MaSP { get => maSP; set => maSP = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public int TonKho { get => tonKho; set => tonKho = value; }
        public int GiaDoc { get => giaDoc; set => giaDoc = value; }
        public int GiaBan { get => giaBan; set => giaBan = value; } 
        public string DuongDanHinhAnh { get => duongDanHinhAnh; set => duongDanHinhAnh = value; }
        public string ChiTiet { get => chiTiet; set => chiTiet = value; }
        public LoaiSanPham Loai { get => loai; set => loai = value; }
        public HangSX HangSanXuat { get => hangSanXuat; set => hangSanXuat = value; }
        internal Rate Rating { get => rating; set => rating = value; }

        public SanPham()
        {
            maSP = " " ;
            tenSP = " ";
            tonKho= 0;
            giaDoc=0;
            giaBan=0;
            Loai= LoaiSanPham.DIEN_THOAI;
            duongDanHinhAnh = "Img/Default.png";
            chiTiet = " : ";
            hangSanXuat = null;
            rating = new Rate();
        }
        public SanPham(int maSP, string tenSP, int tonKho, int giaDoc, int giaBan, string loai, string duongDanHinhAnh, string chiTiet)
        {
            this.tenSP = tenSP;
            this.tonKho = tonKho;
            this.giaDoc = giaDoc;
            this.giaBan = giaBan;
            this.loai = loai == "DIEN THOAI" ? LoaiSanPham.DIEN_THOAI: LoaiSanPham.LINH_KIEN;
            this.duongDanHinhAnh = duongDanHinhAnh;
            this.chiTiet = chiTiet;
            char l = Loai == LoaiSanPham.DIEN_THOAI ? 'D' : 'L';
            this.MaSP = l + maSP.ToString();

        }
    }
}
