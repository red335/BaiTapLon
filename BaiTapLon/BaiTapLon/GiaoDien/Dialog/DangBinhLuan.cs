using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaiTapLon.HoTro;
namespace BaiTapLon.GiaoDien.Dialog
{
    public partial class DangBinhLuan : Form
    {
        public TatCaDelegate.ResultDangNhanXet result;
        public Model.TaiKhoan TaiKhoan;
        int score = 5;
        PictureBox[] arr = new PictureBox[5];
      
        const string St1 = "Img/icon/Star.png";
        const string St2 = "Img/icon/Star_2.png";
        const string St3 = "Img/icon/Star_3.png";
        public DangBinhLuan(TatCaDelegate.ResultDangNhanXet result,Model.TaiKhoan taiKhoan)
        {
            InitializeComponent();
            this.result = result;
            this.TaiKhoan = taiKhoan;
            arr[0] = S1;
            arr[1] = S2;
            arr[2] = S3;
            arr[3] = S4;
            arr[4] = S5;
            for (int i = 0; i < 5; i++) {
                arr[i].MouseHover += MouseHover_Star;
             //   arr[i].MouseLeave += MouseLeave_Star;
            }
            lbName.Text = TaiKhoan.Name;
            Avatar.Image = Image.FromFile(TaiKhoan.Avatar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void MouseHover_Star(object sender, EventArgs e) {
            score = Convert.ToInt32((sender as Control).Tag);
            HienThiDiem(score); 
        }
       
        private void MouseClick_Star(object sender, EventArgs e)
        {
            score = Convert.ToInt32((sender as Control).Tag);
            HienThiDiem(score);
        }
        private void HienThiDiem( float score)
        {
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

        private void button2_Click(object sender, EventArgs e)
        {
            Model.BinhLuan binhLuan = new Model.BinhLuan(noiDung.Text,score,tieuDe.Text,0,0,DateTime.Now);
            binhLuan.TaiKhoan = TaiKhoan;
            result(binhLuan);
            this.Close();
        }
    }
}
