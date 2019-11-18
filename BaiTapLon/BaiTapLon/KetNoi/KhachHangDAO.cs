using BaiTapLon.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon.KetNoi
{
    public  class KhachHangDAO:KetNoiCSDL
    {
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

        public KhachHang getTKKH(string idTK) {
            KhachHang khach = null;
            if (idTK.Contains("K")) idTK = idTK.Split('K')[1];
            string query = "select KH.MAKH,KH.TENKH,KH.SDT,KH.DIACHI,TK.LOAI_KHACH,KH.NAMSINH,KH.GIOITINH from KHACHHANG KH, TAIKHOAN_KHACH TK where KH.MAKH = TK.MAKH and TK.MATAIKHOAN  = " + idTK;
            DataTable table = DocCSDL(query);
            if (table != null || table.Rows.Count != 0)
            {
                int ma = Convert.ToInt32(table.Rows[0][0]);
                string ten = table.Rows[0][1].ToString();
                string SDT = table.Rows[0][2].ToString();
                string dicChi = table.Rows[0][3].ToString();
                string hang = table.Rows[0][4].ToString();
                DateTime ns = Convert.ToDateTime(table.Rows[0][5]);
                bool gt = Convert.ToBoolean(table.Rows[0][6]);
                khach = new KhachHang(ma, ten, SDT, dicChi, hang,ns,gt);
            }

            return khach;
        }
        public KhachHang getKH(string id) {
            KhachHang khach = null;
            if (id.Contains("K")) id = id.Split('H')[1];
            string query = "select KH.MAKH,KH.TENKH,KH.SDT,KH.DIACHI,TK.LOAI_KHACH,KH.NAMSINH,KH.GIOITINH from KHACHHANG KH, TAIKHOAN_KHACH TK where KH.MAKH = TK.MAKH and KH.MAKH = " + id;
            DataTable table = DocCSDL(query);
            if(table != null || table.Rows.Count != 0)
            {
                int ma =Convert.ToInt32( table.Rows[0][0]);
                string ten  = table.Rows[0][1].ToString();
                string SDT = table.Rows[0][2].ToString();
                string dicChi = table.Rows[0][3].ToString();
                string hang = table.Rows[0][4].ToString();
                DateTime ns = Convert.ToDateTime(table.Rows[0][5]);
                bool gt = Convert.ToBoolean(table.Rows[0][6]);
                khach = new KhachHang(ma, ten, SDT, dicChi,hang,ns,gt);
            }

            return khach;
        }

        public List< KhachHang> getDS(string id)
        {
            List<KhachHang> ds = new List<KhachHang>();
            if (id.Contains("K")) id = id.Split('H')[1];
            string query = "select KH.MAKH,KH.TENKH,KH.SDT,KH.DIACHI,TK.LOAI_KHACH,KH.NAMSINH,KH.GIOITINH from KHACHHANG KH, TAIKHOAN_KHACH TK where KH.MAKH = TK.MAKH";
            DataTable table = DocCSDL(query);
            if (table == null || table.Rows.Count == 0) return null;
            foreach(DataRow row in table.Rows)
            {
                int ma = Convert.ToInt32(row[0]);
                string ten = row[1].ToString();
                string SDT = row[2].ToString();
                string dicChi = row[3].ToString();
                string hang = row[4].ToString();
                DateTime ns = Convert.ToDateTime(row[5]);
                bool gt = Convert.ToBoolean(row[6]);
                ds.Add( new KhachHang(ma, ten, SDT, dicChi,hang,ns,gt));
            }

            return ds;

        }
    }
}
