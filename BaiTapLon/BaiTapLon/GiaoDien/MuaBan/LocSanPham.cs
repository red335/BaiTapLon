using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using BaiTapLon.Model;
using System.Windows.Forms;
using BaiTapLon.HoTro;

namespace BaiTapLon.GiaoDien.MuaBan
{
    public partial class LocSanPham : UserControl
    {
        List<SanPham> sanPhams = new List<SanPham>();
        const int soluongMax = 12;
        private int begin=-1, end=-1, MAX;
        HoTro.TatCaDelegate.AddOnHome AddOn;

        public TatCaDelegate.AddOnHome AddON { get => AddOn; set => AddOn = value; }

        public LocSanPham()
        {
            InitializeComponent();
         
        }
        public LocSanPham(List<SanPham> sanPhams)
        {
            InitializeComponent();
            this.sanPhams = sanPhams;

        }

        // GIAO DIEN 
        #region Giao Dien
        private void Updated() {
            MAX  = soluongMax <= sanPhams.Count-end-1 ? soluongMax : sanPhams.Count -end-1;
            begin += end+1;
            end += MAX;
        }
        private void HienThi() {
            Updated();
            for (int i = begin; i <= end; i++) {
                FlistDS.Controls.Add(new ChiTietSanPham_1(sanPhams[i],AddOn));
            }
        }
        #endregion

    }
}
