using System;
using System.Collections.Generic;
using System.Linq;
using BaiTapLon.Model;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon.KetNoi
{
    class HangSXDAO : KetNoiCSDL
    {
        public  HangSX getElement(string id)
        { 
            string query = "select * from HANGSX where MAHSX = '"+id +"'" ;
            DataTable dataTable = DocCSDL(query);
            HangSX hangSX1 = null;
            if (dataTable != null || dataTable.Rows.Count != 0) {
                int ma = Convert.ToInt32( dataTable.Rows[0][0]);
                string ten = dataTable.Rows[0][1].ToString();
                string quocGia = dataTable.Rows[0][2].ToString();
                hangSX1 = new HangSX(ma, ten, quocGia);
            }
            return hangSX1;
        }

        public  List<HangSX> layDS()
        {
            List<HangSX> hangSXes = new List<HangSX>();
            string query = "select * from HANGSX ";
            DataTable dataTable = DocCSDL(query);
            
            if (dataTable == null || dataTable.Rows.Count == 0) return null;
            foreach (var row in dataTable.Rows)
            {
                int ma = Convert.ToInt32(dataTable.Rows[0][0]);
                string ten = dataTable.Rows[0][1].ToString();
                string quocGia = dataTable.Rows[0][2].ToString();
                hangSXes.Add( new HangSX(ma, ten, quocGia));

            }
            return hangSXes;
            
        }
        #region thao tac
        public override void Them(object e)
        {
            throw new NotImplementedException();
        }

        public override void Update(object e)
        {
            throw new NotImplementedException();
        }

        public override void Xoa(string id)
        {
            throw new NotImplementedException();
        }
        #endregion



    }
}
