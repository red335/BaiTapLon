using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon.Model
{
    class Rate
    {
        private int total;
        private int oneStar;
        private int towStar;
        private int threeStar;
        private int fourStar;
        private int fiveStar;
      //  private float average;
        public Rate()
        {

        }

        public Rate(int total, int oneStar, int towStar, int threeStar, int fourStar, int fiveStar)
        {
            this.total = total;
            this.oneStar = oneStar;
            this.towStar = towStar;
            this.threeStar = threeStar;
            this.fourStar = fourStar;
            this.fiveStar = fiveStar;
        }

        public int Total { get => total; set => total = value; }
        public int OneStar { get => oneStar; set => oneStar = value; }
        public int TowStar { get => towStar; set => towStar = value; }
        public int ThreeStar { get => threeStar; set => threeStar = value; }
        public int FourStar { get => fourStar; set => fourStar = value; }
        public int FiveStar { get => fiveStar; set => fiveStar = value; }
        public float Average() {
            if (total == 0) return 5.0f;
            return (float) Math.Round((float)(oneStar +towStar*2 + threeStar * 3+ fourStar *4 + fiveStar * 5)/Total,1);
        }

        public int[] getPercentage() {
            int[] arrPercent = new int[5]; if (total == 0) return arrPercent;
            arrPercent[0] = (int)((float)oneStar * 100 / total);
            arrPercent[1] = (int)((float)towStar * 100 / total);
            arrPercent[2] = (int)((float)threeStar * 100 / total);
            arrPercent[3] = (int)((float)fourStar * 100 / total);
            arrPercent[4] = 100 - arrPercent[0] - arrPercent[1] - arrPercent[2] - arrPercent[3];
            
            return arrPercent;
        }
    
    }
}
