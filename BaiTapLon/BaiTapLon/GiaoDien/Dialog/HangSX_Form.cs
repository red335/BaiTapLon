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
    public partial class HangSX_Form : Form
    {
        HoTro.TatCaDelegate.getResultHangSXDialog result;
        public HangSX_Form()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                string r = textBox1.Text + ";" + textBox2.Text;
                result(r);
            }
            else {
                MessageBox.Show("Các trường không được để trống!!");
            }
        }
    }
}
