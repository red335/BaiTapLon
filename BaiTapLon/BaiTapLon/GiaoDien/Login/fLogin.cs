using BaiTapLon.KetNoi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLon
{
    public partial class FLogin : Form
    {
        public static string LoaiTaiKhoan = "";

        public FLogin()
        {
            InitializeComponent();

            //Round Form
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private bool Login(string userName, string passWord)
        {
            TaiKhoanDAO taikhoan = new TaiKhoanDAO();
            return taikhoan.Login(userName, passWord);
        }

        #region Cac Events Button + Textbox
        //Button Dang Nhap
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string passWord = txbPassWord.Text;
            if (Login(userName, passWord))
            {
                //Mở form Main
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!");
            }
        }

        //Button Exit
        private void BtnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Button Close "X"
        private void Label2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Textbox Username + Password
        private void TxbUserName_Enter(object sender, EventArgs e)
        {
            (sender as TextBox).SelectAll();
        }

        private void TxbUserName_Click(object sender, EventArgs e)
        {
            (sender as TextBox).SelectAll();
        }

        private void TxbPassWord_TextChanged(object sender, EventArgs e)
        {
            txbPassWord.UseSystemPasswordChar = true;
        }
        #endregion

        #region Giao diện
        //Hàm di chuyển form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void PictureBoxLogo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        //Hàm bo tròn góc form
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        //Hàm Esc để tắt form
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        //Hàm đổ bóng form
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = 0x20000;
                return cp;
            }
        }
        #endregion

        private void TxbUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txbPassWord.Focus();
            }
        }

        private void TxbPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void FLogin_Load(object sender, EventArgs e)
        {
            this.Activate();
        }
    }
}
