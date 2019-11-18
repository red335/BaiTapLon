using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using BaiTapLon.GiaoDien.Dialog;
using System.Windows.Forms;
using BaiTapLon.Model;
using BaiTapLon.HoTro;

namespace BaiTapLon.GiaoDien.MuaBan
{
    public partial class SanPham_Form : UserControl
    {

        HoTro.TatCaDelegate.BackHome back;


        private SanPham sanPham;
        const string S1 = "Img/icon/Star.png";
        const string S2 = "Img/icon/Star_2.png";
        const string S3 = "Img/icon/Star_3.png";
        TaiKhoan TaiKhoan = new KetNoi.TaiKhoanDAO().getTaiKhoan("TK3");
        List<BinhLuan> binhLuans = null;
        public SanPham_Form()
        {
            InitializeComponent();
          
        }
        public SanPham_Form(SanPham sanPham)
        {
            InitializeComponent();
            this.SanPham = sanPham;
            binhLuans = new KetNoi.BinhLuanDAO().layDS(sanPham);
            if(binhLuans == null)
                binhLuans = new List<BinhLuan>(); ;
            HienThiThongTin();
        }

        public SanPham SanPham { get => sanPham; set => sanPham = value; }
        public TatCaDelegate.BackHome Back { get => back; set => back = value; }

        public void HienThiThongTin()
        {
            pbAnhSanPham.Image = Image.FromFile(sanPham.DuongDanHinhAnh);
            lbTenSP.Text = sanPham.TenSP;
            if (sanPham.TonKho <= 0)
            {
                lbTonKho.ForeColor = Color.Red;
                lbTonKho.Text = "Hết hàng";
            }
            else
            {
                lbTonKho.ForeColor = Color.Blue;
                lbTonKho.Text = "Hết hàng";
            }
            lbGiaBan.Text = (sanPham.GiaBan * 1000).ToString("#,###") + " VND";
            lbHangSX.Text = sanPham.HangSanXuat.TenHSX;
            HienThiRating();
            ChiTietSanPham();
            DocBinhLuan();
        }
        //====== BINH LUAN VE SAN PHAM ===========\\
        #region BINH LUAN SAN PHAM
        private void DocBinhLuan() {
            // binhLuans  = new KetNoi.BinhLuanDAO().layDS(sanPham);
            FlistBinhLuan.Controls.Clear();
            if ( binhLuans.Count != 0)
            {
                lbSLNhanXet.Text = binhLuans.Count.ToString()+" Nhận xét";
                int MAX = 7 <= binhLuans.Count ? 7 : binhLuans.Count;
                for (int i = 0; i < MAX; i++)
                    FlistBinhLuan.Controls.Add(new GiaoDien.Dialog.KhungBInhLuan(binhLuans[i]));
            }
            else {
                Label label = new Label();
                label.Font = new Font("Tahoma", 9.5F, FontStyle.Regular);
                label.Size = FlistBinhLuan.Size;
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Text = "Không Có Bình Luận Nào !!!";
                FlistBinhLuan.Controls.Add(label);
                lbSLNhanXet.Text = "0 Nhận xét";
            }
        
        }
        

    
        #endregion
        // ============= DANH GIA SAN PHAM ================\\
        #region Rating
        private void HienThiRating() {
            HienThiLuot();
            float score = sanPham.Rating.Average();
            lbRate_1.Text = lbRate_2.Text = score.ToString() + "/5";
            HienThiDiem(pbStar_1,pbStar_2,pbStar_3,pbStar_4,pbStar_5,score);
            HienThiDiem(pbStar_6, pbStar_7, pbStar_8, pbStar_9, pbStar_10, score);

        }
        private void HienThiLuot() {
            lbSoLuongRating.Text = lbSoLuongRating_2.Text = "(" + sanPham.Rating.Total.ToString() + " lượt đánh giá)";
            int[] score = sanPham.Rating.getPercentage();
            lbOneStar.Text = score[0].ToString() + "%";
            lbTowStar.Text = score[1].ToString() + "%";
            lbThreeStar.Text = score[2].ToString() + "%";
            lbFourStar.Text = score[3].ToString() + "%";
            lbFiveStar.Text = score[4].ToString() + "%";
        }
        private void HienThiDiem ( PictureBox  p1,PictureBox p2,PictureBox p3, PictureBox p4, PictureBox p5,float score) {
            PictureBox[] arr = new PictureBox[5];
            arr[0] = p1;
            arr[1] = p2;
            arr[2] = p3;
            arr[3] = p4;
            arr[4] = p5;
         

            int completeStar = (int)Math.Floor(score);
            int halfStar = 6;
           
            if (score - (int)score > 0.2) halfStar = (int)Math.Ceiling(score);
            for (int i = 0; i < 5; i++) {
                if (i + 1 <= completeStar)
                    arr[i].Image = Image.FromFile(S1);
                else if(i+1 == halfStar) arr[i].Image = Image.FromFile(S2);
                else arr[i].Image = Image.FromFile(S3);
            }
        }
       
        #endregion
        //=================CHI TIET SAN PHAM===================\\
        #region CHI TIET SAN PHAM
        private void ChiTietSanPham()
        {
            string[] chiTiet = sanPham.ChiTiet.Split(';');
            int MAX = 4 < chiTiet.Length ? 4 : chiTiet.Length;
            FlistChiTiet.Controls.Add(createPanel("Tên Sản Phẩm", sanPham.TenSP));
            FlistChiTiet.Controls.Add(createLine());
            for (int i = 0; i < MAX; i++)
            {
                string[] element = chiTiet[i].Split(':');
                FlistChiTiet.Controls.Add(createPanel(element[0], element[1]));
                FlistChiTiet.Controls.Add(createLine());

            }
            if (chiTiet.Length > 4) {
              
                Button button = new Button();
                button.AutoSize = true;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.ForeColor = Color.Green;
                button.Font = new Font("Tahoma", 9.3F, FontStyle.Regular);
                button.Text = "XEM THÊM";
                button.Margin = new Padding(190, 10, 0, 0);
                button.Click += XemThemChiTiet;
                FlistChiTiet.Controls.Add(button);
            }
        }

      

        private Panel createPanel(string tit, string dat)
        {
            Panel panel = new Panel();
            panel.AutoScroll = true;
            panel.Controls.Add(createLabel1(tit));
            panel.Controls.Add(createLabel2(dat));
            panel.Location = new System.Drawing.Point(3, 7);
            panel.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            panel.Size = new System.Drawing.Size(586, 33);

            return panel;
        }
        private Label createLabel1(String title)
        {
            Label label = new Label();
            label.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label.Location = new System.Drawing.Point(3, 7);

            label.Size = new System.Drawing.Size(216, 17);
            label.Text = title;
            return label;
        }
        private Label createLabel2(String data)
        {
            Label label = new Label();
            label.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            label.Location = new System.Drawing.Point(225, 7);

            label.Size = new System.Drawing.Size(349, 17);

            label.Text = data;
            return label;
        }
        private Panel createLine()
        {
            Panel panel = new Panel();
            panel.BackColor = System.Drawing.Color.LightGray;
            panel.Location = new System.Drawing.Point(0, 40);
            panel.Margin = new System.Windows.Forms.Padding(0);
            panel.Size = new System.Drawing.Size(604, 1);

            return panel;
        }

        #endregion
        //=======================TAT CA CAC SU KIEN ====================\\
        #region SUKIEN CUA FORM VA CONTROLS
        private void SanPham_Form_Load(object sender, EventArgs e)
        {
            // chon binh luan
            cbbComment_LoaiKhach.SelectedIndex = 0;
            cbbComment_Sao.SelectedIndex = 0;
            cbbComment_ThoiGian.SelectedIndex = 0;
        }

        // dang binh luan
        private void button12_Click(object sender, EventArgs e)
        {
            new GiaoDien.Dialog.DangBinhLuan(dangBinhLuan,TaiKhoan).ShowDialog();
        }

        //di chuyen tren cac nut tag
        private void Tag_Hover(object sender, EventArgs e)
        {
            Label lb = sender as Label;
            lb.ForeColor = Color.Red;
           
        }

        // thoat khoi cac nut tag
        private void Tag_Leave(object sender, EventArgs e)
        {
            Label lb = sender as Label;
            lb.ForeColor = Color.White;
        }

       
        //click vao label HOme
        private void BackHome_Click(object sender, EventArgs e)
        {
            back(GIAO_DIEN_QUAN_LY.BUON_BAN);
        }
        #endregion

        //
        //NUT GIMA SO LUONG SAN PHAM
        //
        private void btnSUBSP_Click(object sender, EventArgs e)
        {
            int X = Int32.Parse( txtSLSP.Text);
            if (X-1 <= 0) return;
            txtSLSP.Text=(X - 1).ToString();
        }

        //
        //  NUT THEM SO LUONG SAN PHAM
        //
        private void btnAddSP_Click(object sender, EventArgs e)
        {
            int X = Int32.Parse(txtSLSP.Text);
            if (X +1 >100) return;
            txtSLSP.Text = (X + 1).ToString();
        }



        //Them Vao Gio Hang
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sản phẩm đã được thêm vào giỏ hàng");
        }
        //===============HAM XU LY ===============\\
        #region XU LY
        private void dangBinhLuan(BinhLuan binhLuan) {
            binhLuans.Add(binhLuan);
            DocBinhLuan();
        }
        private void XemThemChiTiet(object sender, EventArgs e)
        {
            new ChiTietSanPham_2(sanPham).ShowDialog();
        }




        #endregion


    }
}
