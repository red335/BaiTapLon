using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon.Model
{
   public class KhachHang
    {
        private string maKH;
        private string hoTen;
        private string sdt;
        private string diaChi;   
        private string hang;
        private DateTime namSinh;
        private bool gioiTinh;

        public KhachHang(int maKH, string hoTen, string sdt, string diaChi, string hang, DateTime namSinh, bool gioiTinh)
        {
            this.maKH ="KH" +maKH.ToString();
            this.hoTen = hoTen;
            this.sdt = sdt;
            this.diaChi = diaChi;
            this.hang = hang;
            this.namSinh = namSinh;
            this.gioiTinh = gioiTinh;
        }

        public string HoTen { get => hoTen; set => hoTen = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string MaKH { get => maKH; set => maKH = value; }
        public string Hang { get => hang; set => hang = value; }
        public DateTime NamSinh { get => namSinh; set => namSinh = value; }
        public bool GioiTinh { get => gioiTinh; set => gioiTinh = value; }
    }
}
