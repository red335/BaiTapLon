using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaiTapLon.Model;
namespace BaiTapLon.KetNoi
{
   public  class TaiKhoanDAO:KetNoiCSDL
    {
        public TaiKhoan getTaiKhoan(string maTaiKhoan) {
            TaiKhoan taiKhoan = null;
            string ma = maTaiKhoan.Split('K')[1];
            string query = "select * from TAIKHOAN where MATAIKHOAN = " + ma;
            DataTable dtbale = DocCSDL(query);
            if (dtbale == null || dtbale.Rows.Count == 0) return null;
            foreach (DataRow row in dtbale.Rows)
            {
                int maTK = Convert.ToInt32(row[0]);
                string username = row[1].ToString();
                string pass = row[2].ToString();
                string display_name = row[3].ToString();
                DateTime timeCreate = Convert.ToDateTime(row[4]);
                string loai = row[5].ToString();
                string avatar = row[6].ToString();
                taiKhoan = new Model.TaiKhoan(maTK, display_name, avatar, timeCreate, pass, username, loai);
            }
            return taiKhoan;
        }
    }
}
