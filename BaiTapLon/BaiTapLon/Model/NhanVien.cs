using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon.Model
{
    public class NhanVien
    {
        private string maNV;
        private string tenNV;
        private string queQuan;
        private DateTime ngaySinh;
        private string sDT;
        private int luong;
        private bool gioiTinh;
        private string anhChanDung;
        private string chanDung;

        public NhanVien(int maNV, string tenNV, string queQuan, DateTime ngaySinh, string sDT, int luong, bool gioiTinh, string anhChanDung, string chanDung)
        {
            this.maNV = "NV"+maNV.ToString();
            this.tenNV = tenNV;
            this.queQuan = queQuan;
            this.ngaySinh = ngaySinh;
            this.sDT = sDT;
            this.luong = luong;
            this.gioiTinh = gioiTinh;
            this.anhChanDung = anhChanDung;
            this.chanDung = chanDung;
        }

        public string MaNV { get => maNV; set => maNV = value; }
        public string TenNV { get => tenNV; set => tenNV = value; }
        public string QueQuan { get => queQuan; set => queQuan = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string SDT { get => sDT; set => sDT = value; }
        public int Luong { get => luong; set => luong = value; }
        public bool GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string AnhChanDung { get => anhChanDung; set => anhChanDung = value; }
        public string ChanDung { get => chanDung; set => chanDung = value; }
    }
}
