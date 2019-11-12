using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLon.GiaoDien.Dialog
{
    public partial class KhungBInhLuan : UserControl
    {
        Model.BinhLuan binhLuan = null;
        public KhungBInhLuan(Model.BinhLuan binhLuan)
        {
            InitializeComponent();
            this.binhLuan = binhLuan;
            Loaded();
        }
        private void Loaded() {
            Avatar.Image =Image.FromFile( binhLuan.TaiKhoan.Avatar);
            name.Text = binhLuan.TaiKhoan.Name;
            Title.Text = binhLuan.Title;
            noiDung.Text = binhLuan.NoiDung;
            like.Text = binhLuan.Like.ToString();
            dislike.Text = binhLuan.Dislike.ToString();
            HienThiDiem(S1,S2,S3,S4,S5,binhLuan.Score);
        }
        private void HienThiDiem(PictureBox p1, PictureBox p2, PictureBox p3, PictureBox p4, PictureBox p5, float score)
        {
            PictureBox[] arr = new PictureBox[5];
            arr[0] = p1;
            arr[1] = p2;
            arr[2] = p3;
            arr[3] = p4;
            arr[4] = p5;
            const string St1 = "Img/icon/Star.png";
            const string St2 = "Img/icon/Star_2.png";
            const string St3 = "Img/icon/Star_3.png";

            int completeStar = (int)Math.Floor(score);
            int halfStar = 6;

            if (score - (int)score > 0.2) halfStar = (int)Math.Ceiling(score);
            for (int i = 0; i < 5; i++)
            {
                if (i + 1 <= completeStar)
                    arr[i].Image = Image.FromFile(St1);
                else if (i + 1 == halfStar) arr[i].Image = Image.FromFile(St2);
                else arr[i].Image = Image.FromFile(St3);
            }
        }
    }
}
