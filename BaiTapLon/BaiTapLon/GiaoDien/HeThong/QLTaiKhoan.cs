using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaiTapLon.Model;
using BaiTapLon.KetNoi;
using System.IO;
using BaiTapLon.GiaoDien.MuaBan;
namespace BaiTapLon.GiaoDien.HeThong
{
    public partial class QLTaiKhoan : UserControl
    {
        private KhachHang kh;
        List<DonHang> lsMua = new List<DonHang>();
        private TaiKhoan taiKhoan;
        private int mode = 0; //che do xem , 0 la cua khach, 1 la cua nhan vien
        private int menu = 0;
        public QLTaiKhoan()
        {
            InitializeComponent();
        }

        public QLTaiKhoan(TaiKhoan taiKhoan)
        {
            InitializeComponent();
            this.TaiKhoan = taiKhoan;
            CheDoXem();
            HienThi();
        }

        public TaiKhoan TaiKhoan { get => taiKhoan; set => taiKhoan = value; }

        private void CheDoXem() {
         //   MessageBox.Show(taiKhoan.Location);
            if (taiKhoan.Location != "KHACH")
            {
                gbCTKH.Visible = false;
                mode = 1;
            }
            else { 
                kh = new KhachHangDAO().getTKKH(TaiKhoan.MaTK);
                lsMua = new GioHangDAO().lsMua("8");
            }
           
        }

        private void HienThi() {
          
            txtTenTK.Text = TaiKhoan.Name;
            txtNL.Text = TaiKhoan.TimeCreater.ToString("dd/MM/yyyy");
            if(TaiKhoan.Avatar != "" || TaiKhoan.Avatar != null)
                pbAvatar.Image = Image.FromFile(TaiKhoan.Avatar);
            if (mode == 0)
            {   
                txtDiaChiKhach.Text = kh.DiaChi;
                txtNamSinh.Text = kh.NamSinh.ToString("dd/MM/yyyy");
                txtSDTKhach.Text = kh.Sdt;
                if (kh.GioiTinh) { radioButton1.Checked = true;radioButton2.Checked = false; }
                layDS();
            }
            if (mode == 1) {
                btnSelt.Enabled = false;
                btnTotal.Enabled = false;
            }
            UpdateHienThi(0);
        } 

        #region Su Kien

        //DOI AVATAR
        private void button1_Click(object sender, EventArgs e)
        {
            string pathDes = "";
            const string dd = "Img/TaiKhoan/";
     
            OpenFileDialog open = new OpenFileDialog();
            if (DialogResult.OK == open.ShowDialog())
            {
                string[] tenFile = open.FileName.Split('\\');
                pathDes = tenFile[tenFile.Length - 1];
                pathDes = dd + pathDes;
                pbAvatar.Image = Image.FromFile(open.FileName);
                File.Copy(open.FileName,pathDes);
                taiKhoan.Avatar = pathDes;
            }
        }

        #endregion

        private void ChinhSua(bool t) {
            txtNL.Enabled = txtTenTK.Enabled = txtEmail.Enabled = t;
            if (mode == 0) {
                txtSDTKhach.Enabled = txtDiaChiKhach.Enabled = txtNamSinh.Enabled = t;
            }
        }
        private void UpdateHienThi(int m) {
            //Thong tin
            if (m == 0)
            {
                gbCTKH.Visible = gbTK.Visible = true;
                gbLS.Visible = gbDMK.Visible = false;
                btnHUY.Visible = btnOK.Visible = false;
            }
            //CHINH SUA
            else if (m == 1) {
                gbCTKH.Visible = gbTK.Visible = true;
                gbLS.Visible = gbDMK.Visible = false;
                btnHUY.Visible = btnOK.Visible = true;
            }
            // Doi mat khau
            else if (m == 2)
            {
                gbDMK.Visible =  true;
                gbCTKH.Visible = gbLS.Visible = gbTK.Visible = false;
               
            }
            // LICH SU
            else if (m == 3)
            {
                gbLS.Visible = btnHUY.Visible = true;
                gbCTKH.Visible = gbDMK.Visible = gbTK.Visible = false;
                btnOK.Visible = btnHuyXacNhan.Visible = btnXNhan.Visible = false;
            }
            mode = m;
        }
        
        #region Chinh Sua

        // CHINH SUA
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (menu != 0) return;
            UpdateHienThi(1);
            ChinhSua(true);           
        }

        private void btnHUY_Click(object sender, EventArgs e)
        {
            UpdateHienThi(0);
            ChinhSua(false);
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            UpdateHienThi(0);
            ChinhSua(false);
        }
        #endregion

        #region DOi Mat Khau

        // DOI MAT KHAU
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (menu != 0) return;
            UpdateHienThi(2);            
        }

        private void btnXNhan_Click(object sender, EventArgs e)
        {
            UpdateHienThi(0);
            ChinhSua(false);
        }

        private void btnHuyXacNhan_Click(object sender, EventArgs e)
        {         
            UpdateHienThi(0);
            ChinhSua(false);
        }
        #endregion

        #region Lich Su Mua
        private void btnSelt_Click(object sender, EventArgs e)
        {
            if (mode != 0) return;
            UpdateHienThi(3);

        }


        #endregion
        ////////////=================XU LY================//////////////////
        #region Xu Ly
        private void layDS() {
            foreach (DonHang donHang in lsMua) {
                flLSMua.Controls.Add(new GioHang_ChiTietSanPham(donHang));
            }

        }

        #endregion

     
    }
}
