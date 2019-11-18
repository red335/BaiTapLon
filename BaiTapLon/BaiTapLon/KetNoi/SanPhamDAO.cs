using System;
using System.Collections.Generic;
using BaiTapLon.Model;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BaiTapLon.KetNoi
{
    public class SanPhamDAO : KetNoiCSDL
    {
        #region Thao tac csdl
        public override void Them(object e)
        {
            throw new NotImplementedException();
        }

        public override void Update(object e)
        {
            throw new NotImplementedException();
        }

        public override void Xoa(string id)
        {
            throw new NotImplementedException();
        }
        #endregion

        public  SanPham getElement(string id) 
        {
            string query = "select * from SANPHAM  where MASP  = " + id ;
            DataTable data =  DocCSDL(query);
            SanPham sanPham = null;
            if (data != null || data.Rows.Count != 0)
            {
                int ma = Convert.ToInt32(data.Rows[0][0]);
                string ten = data.Rows[0][1].ToString();
                int tonKho = Convert.ToInt32(data.Rows[0][2]);
                int gia = Convert.ToInt32(data.Rows[0][3]);
                int giaBan = Convert.ToInt32(data.Rows[0][4]);
                string loai = data.Rows[0][5].ToString();
                string hinhAnh = data.Rows[0][6].ToString();
                string chitiet = data.Rows[0][7].ToString();

                Rate rate = new RateDAO().getRate(ma.ToString());
                
                HangSX hangSX = new HangSXDAO().getElement(data.Rows[0][8].ToString());
                sanPham = new SanPham(ma,ten,tonKho,gia,giaBan,loai,hinhAnh,chitiet);
                sanPham.HangSanXuat = hangSX;
                sanPham.Rating = rate;
            }
            return sanPham;
        }

        public  List<SanPham> layDS()
        {
            List<SanPham> sanPhams = new List<SanPham>();
            DataTable dataTable = DocCSDL("select * from SANPHAM ");
            if (dataTable == null || dataTable.Rows.Count == 0) return null;
            foreach (DataRow row in dataTable.Rows)
            {
                SanPham sanPham = null;
                int ma = Convert.ToInt32(row[0]);
                string ten = row[1].ToString();
                int tonKho = Convert.ToInt32(row[2]);
                int gia = Convert.ToInt32(row[3]);

                int giaBan = Convert.ToInt32(row[4]);
                string loai = row[5].ToString();
                string hinhAnh = row[6].ToString();
                string chitiet = row[7].ToString();

                Rate rate = new RateDAO().getRate(ma.ToString());

                HangSX hangSX = new HangSXDAO().getElement(row[8].ToString());
                sanPham = new SanPham(ma, ten, tonKho, gia, giaBan, loai, hinhAnh, chitiet);
                sanPham.HangSanXuat = hangSX;
                sanPham.Rating = rate;
                sanPhams.Add(sanPham);
            }

            return sanPhams;
        }

    }
}
