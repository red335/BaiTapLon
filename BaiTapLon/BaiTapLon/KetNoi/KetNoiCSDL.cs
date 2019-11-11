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
    public  class KetNoiCSDL
    {
        public  string getStringConnection() {
           
            string folderName = "/stringConnection/stringConnection.dat"; 
            DirectoryInfo pathEXE = new DirectoryInfo(Directory.GetCurrentDirectory());// Directory.GetCurrentDirectory();
              
           
            //Chon duong dan ben ngoai thu muc github
            for (int i = 0; i < 5; i++)
                pathEXE = pathEXE.Parent;
            if (File.Exists(pathEXE.FullName + folderName))
            {
                string stringConnect;
                stringConnect = File.ReadAllText(pathEXE.FullName + folderName);
                //   System.Windows.Forms.MessageBox.Show("String Connect: "+stringConnect); ;
                return stringConnect;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("File ko ton tai: "+ pathEXE.FullName + folderName);
            }
            return "";
        }

        //================= KET NOI CSDL ==================\\
        public  SqlConnection ketNoi() {
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
            DataTable dataTable = new DataTable();

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
        virtual public void Them(object e) { }
        virtual public void Xoa(string id) { }
        virtual public void Update(object e) { }
      //  abstract public List<Object> layDS();
   //    abstract  public Object getElement(string id);
    }
}
