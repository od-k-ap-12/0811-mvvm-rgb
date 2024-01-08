using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0811_mvvm_rgb.Models
{
    internal class MyColor
    {
        public byte Alpha { get; set; }
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }

        public MyColor(byte _Alpha, byte _Red, byte _Green, byte _Blue)
        {
            Alpha = _Alpha;
            Red = _Red;
            Green = _Green;
            Blue = _Blue;
        }

    }
}
