using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaiTapLon.HoTro;
using BaiTapLon.GiaoDien.HeThong;

namespace BaiTapLon.GiaoDien.MuaBan
{
    public partial class MuaBan_Form : UserControl
    {
        #region Khai bao thuoc tinh

        static public  int HOME_FORM = 1;
        static public int SANPHAM_FORM = 2;

        private Size defautlSize = new Size(885, 499);
        private Color selectedColor = Color.FromArgb(0, 115, 230);
 //       private Panel selectedMenu = null;


        HoTro.TatCaDelegate.BackHome back;

        public TatCaDelegate.BackHome Back { get => back; set => back = value; }

        //   public enum KieuFormMuaBan { FORM_HOME, FORM_SANPHAM };

        #endregion
        public MuaBan_Form(Size parentSize)
        {
            InitializeComponent();
            this.Size = parentSize;
            this.Location = new Point(0, 0);
            LoadEvent();
            AddUseControls(1, new Home(AddUseControls));
        }
        public MuaBan_Form()
        {
            InitializeComponent();
            this.Size = defautlSize;
            this.Location = new Point(0, 0);
            LoadEvent();
            AddUseControls(1, new Home(AddUseControls));
        }

        private void AddUseControls(int mode,UserControl user) {
            pnBody.Controls.Clear();
            if (mode == 1)
            {
                (user as Home).Back = back;
                pnBody.Controls.Add(user );
            }
            else if (mode == 2)
            {
                (user as SanPham_Form).Back = back; 
                pnBody.Controls.Add(user);
                
            }
            else if (mode == 3)
            {
                (user as LocSanPham).AddON = AddUseControls;
                pnBody.Controls.Add(user);

            }
            else if (mode == 4)
            {
               // (user as QLTaiKhoan).AddON = AddUseControls;
                pnBody.Controls.Add(user);

            }
        }

        // ======================  SU KIEN NHAN NUT BUTON =================\\
        #region Event Button
        private void LoadEvent()
        {
            //CLICK
            pbCart.Click += ButtonMenu_Click;
            pbClassify.Click += ButtonMenu_Click;
            pbMess.Click += ButtonMenu_Click;
            pbUser.Click += ButtonMenu_Click;
            pbShop.Click += ButtonMenu_Click;
            pbHOME.Click += ButtonMenu_Click;

            pnCart.Click += ButtonMenu_Click;
            pnClassify.Click += ButtonMenu_Click;
            pnMess.Click += ButtonMenu_Click;
            pnUser.Click += ButtonMenu_Click;
            pnShop.Click += ButtonMenu_Click;
            pnHOME.Click += ButtonMenu_Click;
            //HOVER 
            pbCart.MouseHover += ButtonMenu_Hover;
            pbClassify.MouseHover += ButtonMenu_Hover;
            pbMess.MouseHover += ButtonMenu_Hover;
            pbUser.MouseHover += ButtonMenu_Hover;
            pbShop.MouseHover += ButtonMenu_Hover;
            pbHOME.MouseHover += ButtonMenu_Hover;

            pnCart.MouseHover += ButtonMenu_Hover;
            pnClassify.MouseHover += ButtonMenu_Hover;
            pnMess.MouseHover += ButtonMenu_Hover;
            pnUser.MouseHover += ButtonMenu_Hover;
            pnShop.MouseHover += ButtonMenu_Hover;
            pnHOME.MouseHover += ButtonMenu_Hover;
            //LEAVE
            pbCart.MouseLeave += ButtonMenu_Leave;
            pbClassify.MouseLeave += ButtonMenu_Leave;
            pbMess.MouseLeave += ButtonMenu_Leave;
            pbUser.MouseLeave += ButtonMenu_Leave;
            pbShop.MouseLeave += ButtonMenu_Leave;
            pbHOME.MouseLeave += ButtonMenu_Leave;

            pnCart.MouseLeave += ButtonMenu_Leave;
            pnClassify.MouseLeave += ButtonMenu_Leave;
            pnMess.MouseLeave += ButtonMenu_Leave;
            pnUser.MouseLeave += ButtonMenu_Leave;
            pnShop.MouseLeave += ButtonMenu_Leave;
            pnHOME.MouseLeave += ButtonMenu_Leave;
        }
        //CLICK MENU
        private void ButtonMenu_Click(object sender, EventArgs e)
        {
           
            LoadForm((sender as Control).Tag.ToString());
        }
        private void LoadForm(string Tag) {
            if (Tag == "HOME") { back(GIAO_DIEN_QUAN_LY.BUON_BAN); }
           else if (Tag == "Cart") { new GioHang().ShowDialog(); }
           else if (Tag == "User") {
                Model.TaiKhoan tk = new KetNoi.TaiKhoanDAO().getTaiKhoan("8");
                AddUseControls(4,new QLTaiKhoan(tk)); 
            }
        }

        //HOVER MENU
        private void ButtonMenu_Hover(object sender, EventArgs e)
        {
          
            Control s = sender as Control;
            if (sender is Panel)
                {
                    s.BackColor = selectedColor;
                    s.Controls[0].ForeColor = Color.White;
                }
                else
                {
                    s.Parent.BackColor = selectedColor;
                    s.Parent.Controls[0].ForeColor = Color.White;
                
            }

        }
        //LEAVE MENU
        private void ButtonMenu_Leave(object sender, EventArgs e)
        {
            if (!(sender is Panel)) return;
            Control s = sender as Control;
            s.BackColor = Color.White;
            s.Controls[0].ForeColor = Color.Black;
          
        }
        #endregion
    }
}
