using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLon.GiaoDien.MuaBan
{
    public partial class Header_Form : UserControl
    {
       
        private HoTro.TatCaDelegate.BackHome back;

        public HoTro.TatCaDelegate.BackHome Back { get => back; set => back = value; }

        public Header_Form()
        {
            InitializeComponent();
            btnKM.MouseHover += Menu_Hover;
            btnLS.MouseHover += Menu_Hover;
            btnSC.MouseHover += Menu_Hover;
            btnTB.MouseHover += Menu_Hover;
            btnTK.MouseHover += Menu_Hover;

            btnKM.MouseLeave += Menu_Leave;
            btnLS.MouseLeave += Menu_Leave;
            btnSC.MouseLeave += Menu_Leave;
            btnTB.MouseLeave += Menu_Leave;
            btnTK.MouseLeave += Menu_Leave;

        }
        private void Menu_Hover(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.ForeColor = Color.Red;
        }
        private void Menu_Leave(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.ForeColor = Color.White;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void HOME_CLICK(object sender, EventArgs e)
        {
            back(GIAO_DIEN_QUAN_LY.BUON_BAN);
        }
    }
}
