using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLon.GiaoDien.Dialog
{
    public partial class ThemChiTietSanPham : Form
    {
        private DataTable tbThongTin = new DataTable();
        private HoTro.TatCaDelegate.getResultCHiTietSanPham result;
        string chiTiet;
        public ThemChiTietSanPham(string chiTiet, HoTro.TatCaDelegate.getResultCHiTietSanPham result)
        {
            InitializeComponent();
            this.chiTiet = chiTiet;
            tbThongTin.Columns.Add("Ten Thong Tin", Type.GetType("System.String"));
            tbThongTin.Columns.Add("Gia tri", Type.GetType("System.String"));
            this.result = result;

            duLieuCoSan();
            Data.DataSource = tbThongTin;

            Data.Font = new Font("Tahoma", 9F);
        }
        private void duLieuCoSan()
        {
            string[] listString = chiTiet.Split(';');
            foreach (string str in listString)
            {
                string[] dat = str.Split(':');
                tbThongTin.Rows.Add(dat);
            }
        }
        private void EXIT(object sender, EventArgs e)
        {

            this.Close();
        }

   

        

        private void OK(object sender, EventArgs e)
        {

            chiTiet = "";
            for (int i = 0; i < tbThongTin.Rows.Count; i++)
            {
                DataRow dataRow = tbThongTin.Rows[i];
                if (new ThongTin(dataRow[0].ToString(), dataRow[1].ToString()).thongTinHopLe())
                {
                    chiTiet += dataRow[0] + ":" + dataRow[1];
                    if (i != tbThongTin.Rows.Count - 1)
                        chiTiet += ";";
                }
            }
            result(chiTiet);
            this.Close();
        }

        private void XOA(object sender, EventArgs e)
        {
            if (Data.SelectedRows.Count > 0)
            {
                tbThongTin.Rows.RemoveAt(Data.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Ban phai chon mot dong truoc khi xoa");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            tbThongTin.Rows.Add(new string[] { "", "" });

        }
    }

}
public class ThongTin
{
    private string tenThongTin;
    private string soLieu;

    public ThongTin(string tenThongTin, string soLieu)
    {
        this.tenThongTin = tenThongTin;
        this.soLieu = soLieu;
    }

    public string TenThongTin { get => tenThongTin; set => tenThongTin = value; }
    public string SoLieu { get => soLieu; set => soLieu = value; }
    public bool thongTinHopLe()
    {
        tenThongTin = tenThongTin.Trim();
        soLieu = soLieu.Trim();
        return tenThongTin != "" && soLieu != "";
    }
}