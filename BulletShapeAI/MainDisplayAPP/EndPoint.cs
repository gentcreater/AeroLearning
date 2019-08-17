using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainDisplayAPP
{
    class EndPoint
    {
        public double preX = double.MinValue;//前驱点X
        public double preY = double.MinValue;
        public double X;
        public double Y;
        public double backX = double.MaxValue;//后驱点X
        public double backY = double.MaxValue;

        public EndPoint(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
        public EndPoint()
        { }

        
    }
    //class CharaterPoint : EndPoint
    //{
    //    public double preX;//前驱点X
    //    public double preY;
    //    public double backX;//后驱点X
    //    public double backY;
    //    public CharaterPoint(double x, double y)
    //    {
    //        this.X = x;
    //        this.Y = y;
    //    }
    //    public CharaterPoint()
    //    { }
    //}
}
