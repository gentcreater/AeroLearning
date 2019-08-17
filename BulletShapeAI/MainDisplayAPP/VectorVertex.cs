using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainDisplayAPP
{
    class VectorVertex
    {
        public double x;//统一坐标系下X坐标
        public double y;//统一坐标系下Y坐标
        public double modular//统一球坐标系下模距离
        {
            get { return Math.Sqrt(x * x + y * y); }
        }
        public double arctang//统一球坐标系下向量角度
        {
            get { return Math.Atan2(y, x); }
        }

    }
}
