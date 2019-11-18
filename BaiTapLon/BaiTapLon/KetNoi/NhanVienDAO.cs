using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaiTapLon.Model;
namespace BaiTapLon.KetNoi
{
   public class NhanVienDAO:KetNoiCSDL
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

        public NhanVien getNV(string id)
        {
            NhanVien khach = null;
            if (id.Contains("N")) id = id.Split('V')[1];
            string query = "select * from NHANVIEN where MATK  = " + id;
            DataTable table = DocCSDL(query);
            if (table != null || table.Rows.Count != 0)
            {
                int ma = Convert.ToInt32(table.Rows[0][0]);
                string ten = table.Rows[0][1].ToString();
                string que = table.Rows[0][2].ToString();
                DateTime ns = Convert.ToDateTime(table.Rows[0][3]);
                string SDT = table.Rows[0][4].ToString();
                int luong = Convert.ToInt32( table.Rows[0][5]);
                bool gt = Convert.ToBoolean(table.Rows[0][6]);
                string acd = table.Rows[0][7].ToString();
                string cv = table.Rows[0][8].ToString();
                khach = new NhanVien(ma, ten, que, ns, SDT, luong, gt, acd, cv);
            }

            return khach;
        }

        public List<NhanVien> getDS(string id)
        {
            List<NhanVien> ds = new List<NhanVien>();
            if (id.Contains("N")) id = id.Split('V')[1];
            string query = "select KH.MAKH,KH.TENKH,KH.SDT,KH.DIACHI,TK.LOAI_KHACH from NhanVien KH, TAIKHOAN_KHACH TK where KH.MAKH = TK.MAKH";
            DataTable table = DocCSDL(query);
            if (table == null || table.Rows.Count == 0) return null;
            foreach (DataRow row in table.Rows)
            {
                int ma = Convert.ToInt32(row[0]);
                string ten = row[1].ToString();
                string que = row[2].ToString();
                DateTime ns = Convert.ToDateTime(row[3]);
                string SDT = row[4].ToString();
                int luong = Convert.ToInt32(row[5]);
                bool gt = Convert.ToBoolean(row[6]);
                string acd = row[7].ToString();
                string cv = row[8].ToString();
                ds.Add(new NhanVien(ma, ten, que, ns, SDT, luong, gt, acd, cv));
            }

            return ds;

        }

    }
}
