using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon.Model
{
    public class HangSX
    {
        private string maHSX;
        private string tenHSX;
        private string quocGia;

        public string MaHSX { get => maHSX; set => maHSX = value; }
        public string TenHSX { get => tenHSX; set => tenHSX = value; }
        public string QuocGia { get => quocGia; set => quocGia = value; }

        public HangSX()
        {
            MaHSX = " ";
            TenHSX = " ";
            QuocGia = " ";
        }

        public HangSX(int ma, string ten,string quocgia) {
            MaHSX = "M" + ma.ToString();
            TenHSX = ten;
            QuocGia = quocgia;
        }
    }
}
