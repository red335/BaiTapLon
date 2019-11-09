 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace BaiTapLon.KetNoi
{
    public abstract class KetNoiCSDL
    {
        public static string getStringConnection() {
           
            string folderName = "stringConnection/stringConnection.dat"; 
            DirectoryInfo pathEXE = new DirectoryInfo(Directory.GetCurrentDirectory());// Directory.GetCurrentDirectory();
            //Chon duong dan ben ngoai thu muc github
            for (int i = 0; i < 4; i++)
                pathEXE = pathEXE.Parent;
            return pathEXE.FullName + folderName;
        }

        //================= KET NOI CSDL ==================\\
        public static SqlConnection ketNoi() {
            SqlConnection conn = null;
            string stringConn = getStringConnection();
            try
            {
                conn = new SqlConnection(stringConn);
            }
            catch (Exception e) {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            return conn;
        }

        // ================== CAC THAO TAC CSDL ==================\\
         public DataTable DocCSDL(string query) {
            SqlConnection conn = ketNoi();
            conn.Open();
            SqlDataAdapter sqlDataAdapter = null;
            DataTable dataTable = null;
            try
            {
                sqlDataAdapter = new SqlDataAdapter(query, conn);
                sqlDataAdapter.Fill(dataTable);
            }
            catch (Exception e) {
                System.Windows.Forms.MessageBox.Show(e.Message);
                dataTable = null;
            }
            conn.Close();
            return dataTable;
         }
         public bool ThaoTacCSDL(string query) {
            bool hopLe = true;
            SqlConnection conn = ketNoi();
            conn.Open();
            SqlCommand command = null;
            try {
                command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
            }catch(Exception e){
                System.Windows.Forms.MessageBox.Show(e.Message);
            }


            conn.Close();
            return hopLe;

        }

        // ================ OVERRIED FUNCTION ====================\\
        abstract public void Them(object e);
        abstract public void Xoa(string id);
        abstract public void Update(object e);
      //  abstract public List<Object> layDS();
   //    abstract  public Object getElement(string id);
    }
}
