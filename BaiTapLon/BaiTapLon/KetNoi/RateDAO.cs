using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaiTapLon.Model;
namespace BaiTapLon.KetNoi
{
    public class RateDAO: KetNoiCSDL
    {
        public Rate getRate(string id) {
            Rate rate = null;
            string query = "select TOTAL_SCORE, ONE_STAR, TOW_STAR, THREE_STAR, FOUR_STAR, FIVE_STAR" +
                " from DANHGIA where MASP = " + id;
            DataTable table = DocCSDL(query);
            if (table != null || table.Rows.Count != 0)
            {
                int total = Convert.ToInt32(table.Rows[0][0]);
                int one = Convert.ToInt32(table.Rows[0][1]);
                int tow = Convert.ToInt32(table.Rows[0][2]);
                int three = Convert.ToInt32(table.Rows[0][3]);
                int four = Convert.ToInt32(table.Rows[0][4]);
                int five = Convert.ToInt32(table.Rows[0][5]);
                rate = new Rate(total,one,tow,three,four,five);
            }
            return rate;
        }
    }
}
