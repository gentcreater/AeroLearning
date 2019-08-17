using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainDisplayAPP
{
    public enum EdgeType :int
        {
        Line, ArcCtrEdge
    }
    class Edge
    {
        public List<EndPoint> points = new List<EndPoint>();
        
        public EdgeType edgeType;

        public Edge(List<EndPoint> ps, EdgeType type)
        {
            points = ps;
            edgeType = type;
            switch (edgeType)
            {
                case EdgeType.Line://是直线
                    {
                        points.Sort((EndPoint e1, EndPoint e2) => e1.X.CompareTo(e2.X));//保持点以X坐标从小到大
                        break;
                    }
                case EdgeType.ArcCtrEdge://是三点圆弧
                    {
                        //points.Sort((EndPoint e1, EndPoint e2) => e1.X.CompareTo(e2.X));//保持点以X坐标从小到大
                        if (points[1].X > points[2].X)
                        {
                            //交换1、2号点，使弧的两个端点始终从X坐标小到大
                            EndPoint temp = points[1];
                            points[1] = points[2];
                            points[2] = temp;                            
                        }
                        break;
                    }
            }
        }
    }
    class Line:Edge
    {
        public EndPoint p1, p2;
        //public double Y,X;
        public Line(List<EndPoint> ps, EdgeType type) :base(ps,type)
        {
            this.p1 = base.points[0];
            this.p2 = base.points[1];
        }
        public double getY(EndPoint X)
        {
            return (p2.Y - p1.Y) * (X.X - p1.X) / (p2.X - p1.X) + p1.Y;
        }
        public double getX(EndPoint Y)
        {
            return (p1.X - p2.X) * (Y.Y - p2.Y) / (p1.Y - p2.Y) + p2.X;
        }
    }
    class ArcCtrEdgeTreePoints:Edge
    {
        public EndPoint p1, p2,p3;
        public double CenterX, CenterY, Radius;
        double A, B, C, D;
        //public ArcCtrEdge(EndPoint p1, EndPoint midPoint, EndPoint p2) 
        public ArcCtrEdgeTreePoints(List<EndPoint> ps, EdgeType type) : base(ps, type)
        {
            this.p1 = base.points[0];
            this.p2 = base.points[1];
            this.p3 = base.points[2];
             A = p1.X * (p2.Y - p3.Y) - p1.Y * (p2.X - p3.X) + p2.X * p3.Y - p3.X * p2.Y;
             B = (p1.X * p1.X + p1.Y * p1.Y) * (p3.Y - p2.Y) + (p2.X * p2.X + p2.Y * p2.Y) * (p1.Y - p3.Y) + (p3.X * p3.X + p3.Y * p3.Y) * (p2.Y - p1.Y);
             C = (p1.X * p1.X + p1.Y * p1.Y) * (p2.X - p3.X) + (p2.X * p2.X + p2.Y * p2.Y) * (p3.X - p1.X) + (p3.X * p3.X + p3.Y * p3.Y) * (p1.X - p2.X);
             D = (p1.X * p1.X + p1.Y * p1.Y) * (p3.X * p2.Y - p2.X * p3.Y) + (p2.X * p2.X + p2.Y * p2.Y) * (p1.X * p3.Y - p3.X * p1.Y) + (p3.X * p3.X + p3.Y * p3.Y) * (p2.X * p1.Y - p1.X * p2.Y);
        }
        public double getCenterY()
        {
            return CenterY = -0.5 * C / A;
        }
        public double getCenterX()
        {
            return CenterX = -0.5 * B / A;
        }
        public double getRadius()
        {
            return Radius = Math.Sqrt((B * B + C * C - 4 * A * D) / (4 * A * A));
        }
        public double getYbyThreePoints(EndPoint xendPoint)
        {
            double K = A * xendPoint.X * xendPoint.X + B * xendPoint.X + D;
            double y1 = (-C + Math.Sqrt(C * C - 4 * A * K)) / (2 * A);
            double y2 = (-C - Math.Sqrt(C * C - 4 * A * K)) / (2 * A);
            if ((y1 >= 0 && y1 <= 10) && !(y2 >= 0 && y2 <= 10))
            {
                return y1;
            }
            else if (!(y1 >= 0 && y1 <= 10) && (y2 >= 0 && y2 <= 10))
            {
                return y2;
            }
            else if ((y1 >= 0 && y1 <= 10) && (y2 >= 0 && y2 <= 10) && (y1 == y2))
            {
                return y1;
            }
            else if ((y1 >= 0 && y1 <= 10) && (y2 >= 0 && y2 <= 10))
            {
                new ShowException("特征提取区域内同一X坐标上，存在两个点：(" + xendPoint.X.ToString() + "," + y1.ToString() + "),(" + xendPoint.X.ToString() + "," + y2.ToString() + ")");
                return double.NaN;
            }
            else
            {
                return double.NaN;//无解
            }
        }
        public double getXbyThreePoints(EndPoint yendPoint)
        {
            double K = A * yendPoint.Y * yendPoint.Y + C * yendPoint.Y + D;
            double x1 = (-B + Math.Sqrt(B * B - 4 * A * K)) / (2 * A);
            double x2 = (-B - Math.Sqrt(B * B - 4 * A * K)) / (2 * A);
            if ((x1 >= 0 && x1 <= 60) && !(x2 >= 0 && x2 <= 60))
            {
                return x1;
            }
            else if (!(x1 >= 0 && x1 <= 60) && (x2 >= 0 && x2 <= 60))
            {
                return x2;
            }
            else if ((x1 >= 0 && x1 <= 60) && (x2 >= 0 && x2 <= 60) && (x1 == x2))
            {
                return x1;
            }
            else if ((x1 >= 0 && x1 <= 60) && (x2 >= 0 && x2 <= 60))
            {
                new ShowException("特征提取区域内同一Y坐标上，存在两个点：(" + x1.ToString() + "," + yendPoint.Y.ToString() + "),(" + x2.ToString() + "," + yendPoint.Y.ToString() + ")");
                return double.NaN;
            }
            else
            {
                return double.NaN;//无解
            }
        }

        //public double getYbyCenterTwoPoints(double X)
        //{
        //    double Radius;

        //    Radius = Math.Sqrt()
        //}
    }

    class ArcCtrEdge : Edge
    {
        public EndPoint p1, p2, p3;
        public double Radius;

        //public ArcCtrEdge(EndPoint p1, EndPoint midPoint, EndPoint p2) 
        public ArcCtrEdge(List<EndPoint> ps, EdgeType type) : base(ps, type)
        {
            this.p1 = base.points[0]; //圆心
            this.p2 = base.points[1]; //弧始点
            this.p3 = base.points[2]; //弧末点
            this.Radius = Math.Sqrt((p1.X-p2.X)* (p1.X - p2.X)+(p1.Y-p2.Y)* (p1.Y - p2.Y));
        }

        public double getYbyCenterTwoPoints(EndPoint xEndpoin)
        {
            double y1 = Math.Sqrt(Radius * Radius - (xEndpoin.X - p1.X) * (xEndpoin.X - p1.X)) + p1.Y;
            double y2 = -1*Math.Sqrt(Radius * Radius - (xEndpoin.X - p1.X) * (xEndpoin.X - p1.X)) + p1.Y;
            if ((y1 >= 0 && y1 <= 10) && !(y2 >= 0 && y2 <= 10))
            {
                return y1;
            }
            else if (!(y1 >= 0 && y1 <= 10) && (y2 >= 0 && y2 <= 10))
            {
                return y2;
            }
            else if ((y1 >= 0 && y1 <= 10) && (y2 >= 0 && y2 <= 10) && (y1 == y2))
            {
                return y1;
            }
            else if ((y1 >= 0 && y1 <= 10) && (y2 >= 0 && y2 <= 10)) //有2个值相同
            {
                double distance1 = Math.Abs(y1- xEndpoin.preY);
                double distance2 = Math.Abs(y2 - xEndpoin.preY);
                if (distance1 > distance2) return y2; else return y1;
                //return double.PositiveInfinity;//返回正无穷表示有2个值相同
            }
            else
            {
                return double.NaN;//无解
            }
        }


        public double getXbyCenterTwoPoints(double Y)
        {
            double x1 = Math.Sqrt(Radius * Radius - (Y - p1.Y) * (Y - p1.Y)) + p1.X;
            double x2 = -1*Math.Sqrt(Radius * Radius - (Y - p1.Y) * (Y - p1.Y)) + p1.X;
            if ((x1 >= 0 && x1 <= 60) && !(x2 >= 0 && x2 <= 60))
            {
                return x1;
            }
            else if (!(x1 >= 0 && x1 <= 60) && (x2 >= 0 && x2 <= 60))
            {
                return x2;
            }
            else if ((x1 >= 0 && x1 <= 60) && (x2 >= 0 && x2 <= 60) && (x1 == x2))
            {
                return x1;
            }
            else if ((x1 >= 0 && x1 <= 60) && (x2 >= 0 && x2 <= 60))
            {
                new ShowException("特征提取区域内同一Y坐标上，存在两个不同点：(" + x1.ToString() + "," + Y.ToString() + "),(" + x2.ToString() + "," + Y.ToString() + ")");
                return double.NaN;
            }
            else
            {
                return double.NaN;//无解
            }

        }
    }
}
