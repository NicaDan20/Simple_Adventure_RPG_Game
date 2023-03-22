using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class AdjacentLocation
    {
        public Location LocationToNorth { get; set; }
        public Location LocationToWest { get; set; }
        public Location LocationToEast { get; set; }
        public Location LocationToSouth { get; set; }
        public int NorthID { get; set; }
        public int SouthID { get; set; }
        public int WestID { get; set; }
        public int EastID { get; set; }
        public AdjacentLocation(int _eastID = 0, int _southID = 0, int _westID = 0, int _northID = 0)
        {
            EastID = _eastID;
            SouthID = _southID;
            NorthID = _northID;
            WestID = _westID;
        }
    }
}
