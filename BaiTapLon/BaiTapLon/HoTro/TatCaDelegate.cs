using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon.HoTro
{
    public class TatCaDelegate
    {   
        public  delegate void ResultDangNhanXet(Model.BinhLuan binhLuan);
        public delegate void getResultCHiTietSanPham(string cauhinh);
        public delegate void getResultHangSXDialog(string hangSX);
        public delegate void BackHome(GIAO_DIEN_QUAN_LY GD);
        public delegate void AddOnHome(int Mode,System.Windows.Forms.UserControl userControl);

        public delegate void XuLySoLuongTrongGioHang(int soLuong, int soTien);

    }
}
