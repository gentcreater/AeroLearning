using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainDisplayAPP
{
    class Bullet
    {
        public List<VectorVertex> bulletOutline;//子弹轮廓
        public double AirDensity;//气流密度
        public double AirSpeed;//气流速度
        public double BulletHeadLength;//弹头长度
        public double AirViscosity;//气流粘性
        public double ReRuo//弹体侧面临界雷诺数
        {
            get { return AirDensity * AirSpeed * BulletHeadLength / AirViscosity; }
        }

        public double CX0;//阻力系数
    }
}
