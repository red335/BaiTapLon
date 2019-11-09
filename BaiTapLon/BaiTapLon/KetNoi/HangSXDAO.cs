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
        public  SanPham getElement(string id)
        { string query = "select * from HANGSX where MAHSX = '"+id +"'" ;
            DataTable dataTable = DocCSDL(query);
            HangSX hangSX1 = null;
            if (dataTable == null || dataTable.Rows.Count == 0) {
                int ma = Convert.ToInt32( dataTable.Rows[0][0]);
                string ten = dataTable.Rows[0][1].ToString();
                string quocGia = dataTable.Rows[0][2].ToString();
                hangSX1 = new HangSX(ma, ten, quocGia);
            }
            return hangSX1;
        }

        public  List<object> layDS()
        {
            throw new NotImplementedException();
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
