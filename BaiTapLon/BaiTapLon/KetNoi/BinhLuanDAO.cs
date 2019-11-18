using BaiTapLon.Model;
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
          
            string query = "select * from  NHANXET_SP  where MASP = " + maSP;
            DataTable dtbale =  DocCSDL(query);
            if (dtbale == null || dtbale.Rows.Count == 0) return null;
            foreach (DataRow row in dtbale.Rows) {
                TaiKhoan tk = new TaiKhoanDAO().getTaiKhoan(row[1].ToString());
                // BinhLuan
                string noiDung = row[2].ToString();
                string title = row[3].ToString();
                int like = Convert.ToInt32(row[4]);
                int dislike = Convert.ToInt32(row[5]);
                int score = Convert.ToInt32(row[6]);
                DateTime Posttime = Convert.ToDateTime(row[7]);
                Model.BinhLuan binhLuan = new Model.BinhLuan(noiDung, score,title,like, dislike, Posttime);
                binhLuan.TaiKhoan = tk;
                ds.Add(binhLuan);
            }
            return ds;
        }


    }
}
