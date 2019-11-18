using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaiTapLon.Model;
namespace BaiTapLon.KetNoi
{
    public  class GioHangDAO: KetNoiCSDL
    {
        // THAO TAC THEM san pham vao gio hang, xoa san pham ra khoi gio hang, sau san pham trong gio hang(tuc la da mua)
        public override void Them(object e)
        {
            base.Them(e);
        }
        public override void Update(object e)
        {
            base.Update(e);
        }
        public override void Xoa(string id)
        {
            base.Xoa(id);
        }


        //lay lich su mua

        public List<DonHang> lsMua(string maTK) {
            if (maTK.Contains('K'))
                maTK = maTK.Split('K')[1];
            List<DonHang> ls = new List<DonHang>();
            string query = "select MA_SANPHAM ,NGAYMUA ,SOLUONG  from LICHSUMUA Where MATAIKHOAN = " + maTK;
            DataTable table = DocCSDL(query);
            SanPhamDAO sanPhamDAO = new SanPhamDAO();
            if (table == null || table.Rows.Count == 0) return null;
            foreach (DataRow row in table.Rows) {
                SanPham sanPham = sanPhamDAO.getElement(row[0].ToString());
                DateTime nMua = Convert.ToDateTime(row[1]);
                int soLuong = Convert.ToInt32(row[2]);
                ls.Add(new DonHang(sanPham,soLuong,nMua));

            }
            return ls;
        }

        // Lay Gio Hang

        public List<DonHang> layGioHang(string maTK) {
            if(maTK.Contains('K'))
                maTK = maTK.Split('K')[1];
            List<DonHang> gioHang = new List<DonHang>();
            string query = "select * from GIOHANG where  DAMUA = 0 and MATAIKHOAN  = " + maTK;
            DataTable table = DocCSDL(query);
            if (table == null || table.Rows.Count == 0) return null;
            SanPhamDAO sanPhamDAO = new SanPhamDAO();
            foreach (DataRow row in table.Rows) {
              
              SanPham sanPham = sanPhamDAO.getElement(row[1].ToString());
              int SoLuong =Convert.ToInt32( row[2]);
              DateTime ngayDat = Convert.ToDateTime(row[4]);
                gioHang.Add(new DonHang(sanPham, SoLuong, ngayDat)); 
            }
            return gioHang;
        }

    }
}
