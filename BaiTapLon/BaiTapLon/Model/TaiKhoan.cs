using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon.Model
{
  public  class TaiKhoan
    {
        private string maTK;
        private string name;
        private string avatar;
        private DateTime timeCreater;
        private string pass;
        private string username;
        private string location; // chuc vu

        public TaiKhoan(int maTK, string name, string avatar, DateTime timeCreater, string pass, string username, string location)
        {
            this.maTK ="TK"+ maTK.ToString();
            this.name = name;
            this.avatar = avatar;
            this.timeCreater = timeCreater;
            this.pass = pass;
            this.username = username;
            this.location = location;
        }

        public string MaTK { get => maTK; set => maTK = value; }
        public string Name { get => name; set => name = value; }
        public string Avatar { get => avatar; set => avatar = value; }
        public DateTime TimeCreater { get => timeCreater; set => timeCreater = value; }
        public string Pass { get => pass; set => pass = value; }
        public string Username { get => username; set => username = value; }
        public string Location { get => location; set => location = value; }
    }
}
