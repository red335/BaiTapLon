using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon.Model
{
   public class DonHang
    {
        private SanPham sanPhamMua;
        private int soLuong;
        private DateTime ngayDat;
        public DonHang()
        {
            sanPhamMua = null;
            soLuong = 0;
            ngayDat = DateTime.Now;
        }
        public DonHang(SanPham sanPhamMua, int soLuong, DateTime ngayDat)
        {
            this.sanPhamMua = sanPhamMua;
            this.soLuong = soLuong;
            this.ngayDat = ngayDat;
        }

        public SanPham SanPhamMua { get => sanPhamMua; set => sanPhamMua = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public DateTime NgayDat { get => ngayDat; set => ngayDat = value; }
    }
}
