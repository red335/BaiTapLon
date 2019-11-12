using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon.KetNoi
{
   public class BinhLuanDAO:KetNoiCSDL
    {
        //==================THAO TAC DU LIEU ===============\\
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
        //================ DOC DU LIEU ==================\\
        public List<Model.BinhLuan> layDS(Model.SanPham sp) {
            List<Model.BinhLuan> ds = new List<Model.BinhLuan>(); 
           string maSP = "";
            if (sp.Loai == Model.LoaiSanPham.DIEN_THOAI)
                maSP = sp.MaSP.Split('D')[1];
            else maSP = sp.MaSP.Split('L')[1];
          
            string query = "select * from TAIKHOAN tk, NHANXET_SP nx where tk.MATAIKHOAN = " +
                "nx.MATAIKHOAN and MASP = " + maSP;
            DataTable dtbale =  DocCSDL(query);
            if (dtbale == null || dtbale.Rows.Count == 0) return null;
            foreach (DataRow row in dtbale.Rows) {
                int maTK = Convert.ToInt32(row[0]);
                string username = row[1].ToString();
                string pass = row[2].ToString();
                string display_name = row[3].ToString();
                DateTime timeCreate = Convert.ToDateTime(row[4]);
                string loai = row[5].ToString();
                string avatar = row[6].ToString();
                Model.TaiKhoan taiKhoan = new Model.TaiKhoan(maTK,display_name,avatar,timeCreate,pass,username,loai);

                // BinhLuan
                string noiDung = row[9].ToString();
                string title = row[10].ToString();
                int like = Convert.ToInt32(row[11]);
                int dislike = Convert.ToInt32(row[12]);
                int score = Convert.ToInt32(row[13]);
                DateTime Posttime = Convert.ToDateTime(row[14]);
                Model.BinhLuan binhLuan = new Model.BinhLuan(noiDung, score,title,like, dislike, Posttime);
                binhLuan.TaiKhoan = taiKhoan;
                ds.Add(binhLuan);
            }
            return ds;
        }


    }
}
