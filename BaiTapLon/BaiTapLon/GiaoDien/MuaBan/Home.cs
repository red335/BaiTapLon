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

namespace BaiTapLon.GiaoDien.MuaBan
{
    public partial class Home : UserControl
    {
        List<SanPham> dienThoais = new List<SanPham>();

        public Home()
        {
            InitializeComponent();
        }
    }
}
