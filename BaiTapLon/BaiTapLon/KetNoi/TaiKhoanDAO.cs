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
            if(maTaiKhoan.Contains('K'))
            maTaiKhoan = maTaiKhoan.Split('K')[1];
            string query = "select * from TAIKHOAN where MATAIKHOAN = " + maTaiKhoan;
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



        //Toan-Login
        public bool Login(string userName, string passWord)
        {
            string query = "dbo.USP_Login @userName = N'" + userName + "', @passWord = N'" + passWord + "'";

            DataTable result = DocCSDL(query);

            return result.Rows.Count > 0;
        }

        //Ma-Hoa
        //private string MaHoa(string matKhau)
        //{
        //    byte[] temp = ASCIIEncoding.ASCII.GetBytes(matKhau);
        //    byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);

        //    string hasPass = "";

        //    foreach (byte item in hasData)
        //    {
        //        hasPass += item;
        //    }

        //    return hasPass;
        //}
    }
}
