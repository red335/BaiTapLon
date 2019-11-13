using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaiTapLon.Model;
namespace BaiTapLon.GiaoDien.Dialog
{
    public partial class ChiTietSanPham_2 : Form
    {
        SanPham sanPham;
        string[] chiTiet;
        List<HangSX> hangSXes = new KetNoi.HangSXDAO().layDS();
        public ChiTietSanPham_2(SanPham sanPham)
        {
            InitializeComponent();

            this.sanPham = sanPham;
            cbbHSX.DataSource = hangSXes;
            cbbHSX.DisplayMember = "TenHSX";

            Updated();
        }

        private void Updated() {
           
            HienThiThongTinCoBan();
            HienThiChiTietSP();
        }
        private void ClearChiTiet() {

            const int MAX = 10;
            if (MAX > FlistCT.Controls.Count) return;
            for (int i = MAX; i < FlistCT.Controls.Count; i++) 
                FlistCT.Controls.RemoveAt(MAX+1);
            
        }
        private void HienThiThongTinCoBan() {

            txtTen.Text = sanPham.TenSP;
            txtGiaBan.Text = sanPham.GiaBan.ToString("#,###")+" VND";
            txtGiaGoc.Text = sanPham.GiaDoc.ToString("#,###") + " VND";
            txtDiem.Text = sanPham.Rating.Average().ToString() + "/5";

            int index = hangSXes.FindIndex( (s) => { return s.MaHSX == sanPham.HangSanXuat.MaHSX; });
            // txtHang.Text = sanPham.HangSanXuat.TenHSX;
            cbbHSX.SelectedIndex= index;
            txtLoai.Text = sanPham.Loai.ToString();
            txtTon.Text = sanPham.TonKho.ToString();
            pictureBox1.Image = Image.FromFile(sanPham.DuongDanHinhAnh);

        }
        private void HienThiChiTietSP() {
            ClearChiTiet();
            chiTiet = sanPham.ChiTiet.Split(';');
            foreach (string ele in chiTiet) {
                string[] dat = ele.Split(':');
                FlistCT.Controls.Add( createPanel(dat[0],dat[1]));
            }
            FlistCT.Controls.Add(createXemThem());
        }

        #region Tao Chi Tiet
        
        private Panel createPanel(string Title, string data) {
            Panel panel = new Panel();
            panel.Controls.Add(createLabel1(data));
            panel.Controls.Add(createLabel2(Title));
            panel.Controls.Add(createLine());
            panel.Location = new System.Drawing.Point(0, 341);
            panel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 9);
            panel.Size = new System.Drawing.Size(441, 32);
            panel.Tag = "Del";

            return panel;
        }
        
        // DU LIEU Du LIEU
        private Label createLabel1(string dat) {
            Label label = new Label();
            label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            label.Location = new System.Drawing.Point(182, 12);    
            label.Size = new System.Drawing.Size(218, 16);
            label.Text = dat;
            return label;
        }

        // Tieu DE
        private Label createLabel2(string tit) {
            Label label = new Label();
            label.AutoSize = true;
            label.Location = new System.Drawing.Point(25, 13);
            label.Size = new System.Drawing.Size(55, 16);
            label.Text = tit;
            return label;
        }
        private Panel createLine() {
            Panel panel = new Panel();
            panel.BackColor = System.Drawing.Color.Gainsboro;
            panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel.Location = new System.Drawing.Point(0, 31);        
            panel.Size = new System.Drawing.Size(441, 1);          
            return panel;
        }
        #endregion

        #region Xu Ly
        private Button createXemThem() {
            Button button = new Button();
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            button.Location = new System.Drawing.Point(180, 389);
            button.Margin = new System.Windows.Forms.Padding(180, 7, 0, 10);
            button.Size = new System.Drawing.Size(75, 23);
            button.Text = "Thêm";
            button.Click += XemThem;
            button.UseVisualStyleBackColor = true;
            return button;
        }
        private void XemThem(object sender, EventArgs e)
        {
            new ThemChiTietSanPham(sanPham.ChiTiet,ThemChiTiet).ShowDialog();  
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ThemChiTiet(string chiTiet) {
            sanPham.ChiTiet = chiTiet;
            HienThiChiTietSP();
        }
        #endregion
    }
}
