using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon.Model
{
    public class BinhLuan
    {
        private string noiDung;
        private int score;
        private string title;
        private int like;
        private int dislike;
        private DateTime timePost;
        TaiKhoan taiKhoan;

        public BinhLuan(string noiDung, int score, string title, int like, int dislike, DateTime timePost)
        {
            this.noiDung = noiDung;
            this.score = score;
            this.title = title;
            this.like = like;
            this.dislike = dislike;
            this.timePost = timePost;
          
        }

        public string NoiDung { get => noiDung; set => noiDung = value; }
        public int Score { get => score; set => score = value; }
        public int Like { get => like; set => like = value; }
        public int Dislike { get => dislike; set => dislike = value; }
        public DateTime TimePost { get => timePost; set => timePost = value; }
        public TaiKhoan TaiKhoan { get => taiKhoan; set => taiKhoan = value; }
        public string Title { get => title; set => title = value; }
    }
}
