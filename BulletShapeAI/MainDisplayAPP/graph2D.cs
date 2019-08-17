using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace MainDisplayAPP
{
    class graph2D
    {
        Bitmap objBitmap;
        Graphics objGraphics;
        Bitmap objVectormap;
        Graphics objVectorGraphics;
        string XAxisText;//轴线说明文字
        string YAxisText;//轴线说明文字
        string TitleText;//图标题
        string TitleTextVector;//矢量图标题
        int Width, Height, AxisScale;
        Boolean isMeshLine;
        const int AxisWith = 600;
        const int AxisHeight = 200;
        List<EndPoint> points;//特征点集
        List<Edge> vectoredges;//矢量图点集

        public Color BorderColor;//边框色
        public Color BgColor;//背景色
        public Color AxisColor;//对称轴色
        public Color AxisTextColor;//轴文本颜色
        public Color TitelColor;//标题颜色
        public Color MeshLineColor;//网格线颜色
        public Color PointColor;//特征点颜色
        public Image img; //生成2D坐标全图
        public Image imgVector;//生成2D矢量原图
        public string displayAllPoints;//存放所有点集坐标转成字符串

        public List<Edge> VectorEdges
        {
            set
            {
                if (this.vectoredges != null)
                {
                    foreach (Edge p in vectoredges)
                    {
                        switch (p.edgeType)
                        {
                            case EdgeType.Line:
                                {
                                    //消除画边的端点
                                    objVectorGraphics.DrawEllipse(new Pen(this.BgColor, 3), (float)p.points[0].X * AxisWith / 60 + 30, Height - (float)p.points[0].Y * AxisHeight / 20 - 20, 2, 2); 
                                    objVectorGraphics.DrawEllipse(new Pen(this.BgColor, 3), (float)p.points[1].X * AxisWith / 60 + 30, Height - (float)p.points[1].Y * AxisHeight / 20 - 20, 2, 2);
                                    objVectorGraphics.DrawLine(new Pen(this.BgColor, 1), 
                                        (float)p.points[0].X * AxisWith / 60 + 30,
                                        Height - (float)p.points[0].Y * AxisHeight / 20 - 20,
                                        (float)p.points[1].X * AxisWith / 60 + 30,
                                         Height - (float)p.points[1].Y * AxisHeight / 20 - 20);
                                    break;
                                }
                            case EdgeType.ArcCtrEdge:
                                {
                                    //消除画弧
                                    objVectorGraphics.DrawEllipse(new Pen(this.BgColor, 3), (float)p.points[2].X * AxisWith / 60 + 30, Height - (float)p.points[2].Y * AxisHeight / 20 - 20, 2, 2);
                                    objVectorGraphics.DrawEllipse(new Pen(this.BgColor, 3), (float)p.points[1].X * AxisWith / 60 + 30, Height - (float)p.points[1].Y * AxisHeight / 20 - 20, 2, 2);
                                    DrawArc(new Pen(this.BgColor, 1),
                                              new EndPoint((float)p.points[0].X * AxisWith / 60 + 30, Height - (float)p.points[0].Y * AxisHeight / 20 - 20),
                                              new EndPoint((float)p.points[1].X * AxisWith / 60 + 30, Height - (float)p.points[1].Y * AxisHeight / 20 - 20),
                                              new EndPoint((float)p.points[2].X * AxisWith / 60 + 30, Height - (float)p.points[2].Y * AxisHeight / 20 - 20));
                                    break;
                                }
                        }
                    }
                    //重画下坐标轴
                    InitVectorGraph();
                }


                this.vectoredges = (List<Edge>)value;
                foreach (Edge p in vectoredges)
                {
                    switch (p.edgeType)
                    {
                        case EdgeType.Line:
                            {
                                //画边的端点
                                objVectorGraphics.DrawEllipse(new Pen(this.PointColor, 3), (float)p.points[0].X * AxisWith / 60 + 30, Height - (float)p.points[0].Y * AxisHeight / 20 - 20, 2, 2);
                                objVectorGraphics.DrawEllipse(new Pen(this.PointColor, 3), (float)p.points[1].X * AxisWith / 60 + 30, Height - (float)p.points[1].Y * AxisHeight / 20 - 20, 2, 2);
                                objVectorGraphics.DrawLine(new Pen(this.PointColor, 1),
                                        (float)p.points[0].X * AxisWith / 60 + 30,
                                        Height - (float)p.points[0].Y * AxisHeight / 20 - 20,
                                        (float)p.points[1].X * AxisWith / 60 + 30,
                                        Height - (float)p.points[1].Y * AxisHeight / 20 - 20);
                                break;
                            }
                        case EdgeType.ArcCtrEdge:
                            {
                                //画弧
                                objVectorGraphics.DrawEllipse(new Pen(this.PointColor, 3), (float)p.points[2].X * AxisWith / 60 + 30, Height - (float)p.points[2].Y * AxisHeight / 20 - 20, 2, 2);
                                objVectorGraphics.DrawEllipse(new Pen(this.PointColor, 3), (float)p.points[1].X * AxisWith / 60 + 30, Height - (float)p.points[1].Y * AxisHeight / 20 - 20, 2, 2);
                                //DrawArc(new Pen(this.PointColor, 1),
                                //          new EndPoint(p.points[0].X, p.points[0].Y),
                                //          new EndPoint(p.points[1].X, p.points[1].Y),
                                //          new EndPoint(p.points[2].X, p.points[2].Y));
                                DrawArc(new Pen(this.PointColor, 1),
                                          new EndPoint((float)p.points[0].X * AxisWith / 60 + 30, Height - (float)p.points[0].Y * AxisHeight / 20 - 20),
                                          new EndPoint((float)p.points[1].X * AxisWith / 60 + 30, Height - (float)p.points[1].Y * AxisHeight / 20 - 20),
                                          new EndPoint((float)p.points[2].X * AxisWith / 60 + 30, Height - (float)p.points[2].Y * AxisHeight / 20 - 20));
                                break;
                            }
                    }
                }
                //显示2D矢量图形区域
                imgVector = Image.FromHbitmap(objVectormap.GetHbitmap());
            }
            get
            {
                return this.vectoredges;
            }
        }
        public List<EndPoint> Points//绘图点集
        {
            set
            {
                if (this.points != null)
                {
                    foreach (EndPoint p in points)
                    {
                        if (!double.IsNaN(p.X) && !double.IsNaN(p.Y) && !double.IsPositiveInfinity(p.Y))
                        {
                            objGraphics.DrawEllipse(new Pen(this.BgColor, 2), (float)p.X * AxisWith / 60 + 30, Height - (float)p.Y * AxisHeight / 20 - 20, 2, 2);
                        }
                    }
                    //重画下坐标轴
                    this.InitCharaterGraph();
                }


                this.points = (List<EndPoint>)value;
                displayAllPoints = "";
                foreach (EndPoint p in points)
                {
                    if (!double.IsNaN(p.X) && !double.IsNaN(p.Y) && !double.IsPositiveInfinity(p.Y))
                    {
                        objGraphics.DrawEllipse(new Pen(this.PointColor, 2), (float)p.X * AxisWith / 60 + 30, Height - (float)p.Y * AxisHeight / 20 - 20, 2, 2);
                        displayAllPoints += points.IndexOf(p).ToString() + ".(" + p.X.ToString() + "," + p.Y.ToString() + ")    \r\n";
                    }
                    else if (double.IsNaN(p.X))
                    {
                        displayAllPoints += points.IndexOf(p).ToString() + ".(" + "double.NaN" + "," + p.Y.ToString() + ")    \r\n";
                    }
                    else if (double.IsNaN(p.Y))
                    {
                        displayAllPoints += points.IndexOf(p).ToString() + ".(" + p.X.ToString() + "," + "double.NaN" + ")    \r\n";
                    }
                    else
                    {
                        displayAllPoints += points.IndexOf(p).ToString() + ".(" + p.Y.ToString() + "," + "double.IsPositiveInfinity" + ")    \r\n";
                    }
                }
                //显示2D图形区域
                img = Image.FromHbitmap(objBitmap.GetHbitmap());
            }
            get
            {
                return this.points;
            }
        }

        public Boolean IsMeshLine//是否有网格线
        {
            set
            {
                this.isMeshLine = value;
                if (this.isMeshLine)
                {
                    Pen pen = new Pen(this.MeshLineColor, 1);
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                    pen.DashPattern = new float[] { 2, 2 };
                    int i;
                    for (i = 1; i <= this.AxisScale; i++)
                    {
                        objGraphics.DrawLine(pen, 30 + i * (AxisWith) / this.AxisScale, Height - 20, 30 + i * (AxisWith) / this.AxisScale, Height - 20 - AxisHeight);
                        objVectorGraphics.DrawLine(pen, 30 + i * (AxisWith) / this.AxisScale, Height - 20, 30 + i * (AxisWith) / this.AxisScale, Height - 20 - AxisHeight);
                    }
                    for (i = 1; i <= this.AxisScale; i++)
                    {
                        objGraphics.DrawLine(pen, 30, Height - 20 - i * (AxisHeight) / this.AxisScale, 30 + AxisWith, Height - 20 - i * (AxisHeight) / this.AxisScale);
                        objVectorGraphics.DrawLine(pen, 30, Height - 20 - i * (AxisHeight) / this.AxisScale, 30 + AxisWith, Height - 20 - i * (AxisHeight) / this.AxisScale);
                    }
                    pen.Dispose();
                }
                else
                {
                    Pen pen = new Pen(this.BgColor, 1);
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                    pen.DashPattern = new float[] { 2, 2 };
                    int i;
                    for (i = 1; i <= this.AxisScale; i++)
                    {
                        objGraphics.DrawLine(pen, 30 + i * (AxisWith) / this.AxisScale, Height - 20, 30 + i * (AxisWith) / this.AxisScale, Height - 20 - AxisHeight);
                        objVectorGraphics.DrawLine(pen, 30 + i * (AxisWith) / this.AxisScale, Height - 20, 30 + i * (AxisWith) / this.AxisScale, Height - 20 - AxisHeight);
                    }
                    for (i = 1; i <= this.AxisScale; i++)
                    {
                        objGraphics.DrawLine(pen, 30, Height - 20 - i * (AxisHeight) / this.AxisScale, 30 + AxisWith, Height - 20 - i * (AxisHeight) / this.AxisScale);
                        objVectorGraphics.DrawLine(pen, 30, Height - 20 - i * (AxisHeight) / this.AxisScale, 30 + AxisWith, Height - 20 - i * (AxisHeight) / this.AxisScale);
                    }
                    pen.Dispose();
                }
                //显示2D图形区域
                img = Image.FromHbitmap(objBitmap.GetHbitmap());
                imgVector = Image.FromHbitmap(objVectormap.GetHbitmap());
            }
            get
            {
                return isMeshLine;
            }
        }

        public string TitleANDmodel
        {
            set
            {
                string modelName = value;

                objGraphics.FillRectangle(new SolidBrush(BgColor), AxisWith - 180, 1, AxisWith, 18);
                objGraphics.DrawString(modelName.Substring(0, modelName.IndexOf(".js")), new Font("宋体", 12), new SolidBrush(PointColor), new Point(AxisWith - 180, 1));
                objVectorGraphics.FillRectangle(new SolidBrush(BgColor), AxisWith - 180, 1, AxisWith, 18);
                objVectorGraphics.DrawString(modelName.Substring(0, modelName.IndexOf(".js")), new Font("宋体", 12), new SolidBrush(PointColor), new Point(AxisWith - 180, 1));
            }
            get
            {
                return this.TitleText;
            }
        }

        public graph2D(int bitmapWidth, int bitmapHeight, string TitleText, string TitleTextVector, int AxisScale, Boolean MeshLine,Color pointcolor)
        {
            Width = bitmapWidth;
            Height = bitmapHeight;
            //根据给定的高度和宽度创建一个位图图像
            objBitmap = new Bitmap(Width, Height);
            objVectormap = new Bitmap(Width, Height);
            //从指定的 objBitmap 对象创建 objGraphics 对象 (即在objBitmap对象中画图)
            objGraphics = Graphics.FromImage(objBitmap);
            objVectorGraphics = Graphics.FromImage(objVectormap);

            BorderColor = Color.FromArgb(255, 100, 100, 100);//透明度=255 ，Red=58, Green=200, Blue=100
            BgColor = Color.FromArgb(255, 255, 255, 255);
            AxisColor = Color.FromArgb(255, 0, 0, 0);
            AxisTextColor = Color.FromArgb(255, 0, 0, 0);
            TitelColor =  Color.FromArgb(255, 0, 0, 0);
            MeshLineColor = Color.FromArgb(255, 200, 200, 200);
            PointColor = pointcolor;//Color.FromArgb(255,50, 255, 100);
            XAxisText = "X轴\n(0.1\nmm)";
            YAxisText = "Y轴(0.1mm)";
            this.TitleText = TitleText;
            this.TitleTextVector = TitleTextVector;
            this.AxisScale = AxisScale;

            InitCharaterGraph();//初始化2D图形区域
            InitVectorGraph();//初始化2D矢量图区域

            IsMeshLine = MeshLine;

            //显示2D图形区域
            //img = Image.FromHbitmap(objBitmap.GetHbitmap());
        }

        private void InitVectorGraph()
        {
            //根据给定颜色(LightGray)填充图像的矩形区域 (背景)
            objVectorGraphics.DrawRectangle(new Pen(BorderColor, 1), 0, 0, Width, Height);
            objVectorGraphics.FillRectangle(new SolidBrush(BgColor), 1, 1, Width - 2, Height - 2);

            //画X轴,pen,x1,y1,x2,y2 注意图像的原始X轴和Y轴计算是以左上角为原点，向右和向下计算的
            //objGraphics.DrawLine(new Pen(new SolidBrush(AxisColor), 1), 45, Height - 45, Width - 5, Height - 45);
            System.Drawing.Drawing2D.AdjustableArrowCap lineCap = new System.Drawing.Drawing2D.AdjustableArrowCap(6, 6, true);
            Pen redArrowPen = new Pen(AxisColor, 1);
            redArrowPen.CustomEndCap = lineCap;
            objVectorGraphics.DrawLine(redArrowPen, 30, Height - 20, Width - 5, Height - 20);

            //画Y轴,pen,x1,y1,x2,y2
            //objGraphics.DrawLine(new Pen(new SolidBrush(AxisColor), 1), 45, Height - 45, 45, 5);
            objVectorGraphics.DrawLine(redArrowPen, 30, Height - 20, 30, 15);
            redArrowPen.Dispose();

            //初始化轴线说明文字
            SetAxisText(ref objVectorGraphics);

            //初始化标题
            objVectorGraphics.DrawString(this.TitleTextVector, new Font("宋体", 16), new SolidBrush(TitelColor), new Point(AxisWith / 2 - 100, 1));
            
        }

        private void InitCharaterGraph()
        {
            //根据给定颜色(LightGray)填充图像的矩形区域 (背景)
            objGraphics.DrawRectangle(new Pen(BorderColor, 1), 0, 0, Width, Height);
            objGraphics.FillRectangle(new SolidBrush(BgColor), 1, 1, Width - 2, Height - 2);

            //画X轴,pen,x1,y1,x2,y2 注意图像的原始X轴和Y轴计算是以左上角为原点，向右和向下计算的
            //objGraphics.DrawLine(new Pen(new SolidBrush(AxisColor), 1), 45, Height - 45, Width - 5, Height - 45);
            System.Drawing.Drawing2D.AdjustableArrowCap lineCap = new System.Drawing.Drawing2D.AdjustableArrowCap(6, 6, true);
            Pen redArrowPen = new Pen(AxisColor, 1);
            redArrowPen.CustomEndCap = lineCap;
            objGraphics.DrawLine(redArrowPen, 30, Height - 20, Width - 5, Height - 20);

            //画Y轴,pen,x1,y1,x2,y2
            //objGraphics.DrawLine(new Pen(new SolidBrush(AxisColor), 1), 45, Height - 45, 45, 5);
            objGraphics.DrawLine(redArrowPen, 30, Height - 20, 30, 15);
            redArrowPen.Dispose();

            //初始化轴线说明文字
            SetAxisText(ref objGraphics);

            //初始化标题
            objGraphics.DrawString(this.TitleText, new Font("宋体", 16), new SolidBrush(TitelColor), new Point(AxisWith / 2 - 120, 1));
        }


        /// <summary>
        /// 初始化轴线的说明文字，注意这不是刻度上的文字
        /// </summary>
        /// <param name="objGraphics"></param>
        private void SetAxisText(ref Graphics objGraphics)
        {
            //int step = AxisWith / this.AxisScale;
            int i;
            for (i = 0; i <= this.AxisScale; i++)
            {
                objGraphics.DrawString((i * (AxisWith) / this.AxisScale).ToString(), new Font("宋体", 10), new SolidBrush(AxisTextColor), 20 + i * (AxisWith) / this.AxisScale, Height - 17);
                //画X轴刻度
                objGraphics.DrawLine(new Pen(new SolidBrush(AxisColor), 1), 30 + i * (AxisWith) / this.AxisScale, Height - 17, 30 + i * (AxisWith) / this.AxisScale, Height - 23);
            }
            objGraphics.DrawString(this.XAxisText, new Font("宋体", 10), new SolidBrush(AxisTextColor), Width - 35, Height - 80);


            for (i = 1; i <= this.AxisScale; i++)
            {
                objGraphics.DrawString((i * (200) / this.AxisScale).ToString(), new Font("宋体", 10), new SolidBrush(AxisTextColor), 2, Height - 25 - i * (AxisHeight) / this.AxisScale);
                //画Y轴刻度
                objGraphics.DrawLine(new Pen(new SolidBrush(AxisColor), 1), 27, Height - 20 - i * (AxisHeight) / this.AxisScale, 33, Height - 20 - i * (AxisHeight) / this.AxisScale);
            }
            objGraphics.DrawString(this.YAxisText, new Font("宋体", 10), new SolidBrush(AxisTextColor), 3, 3);
        }


        //初始化标题
        private void CreateTitle()
        {

        }
        /// <summary>
        /// 三个点，center为原点，p1、p2为圆上另外两点
        /// </summary>
        /// <param name="center"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        private void DrawArc(Pen pe,EndPoint center,EndPoint p1,EndPoint p2)
        {
            //圆心所在X轴上的向量
            double Vector_Xx = 100;
            double Vector_Xy = 0;
            //oa向量
            double Vector_ax = p1.X - center.X;
            double Vector_ay = p1.Y - center.Y;
            //ob向量
            double Vector_bx = p2.X - center.X;
            double Vector_by = p2.Y - center.Y;
            //oa和X轴上向量的点乘积
            double Point_Mul_a = (Vector_ax * Vector_Xx) + (Vector_ay * Vector_Xy);
            double Mul_a = Math.Sqrt(Vector_ax * Vector_ax + Vector_ay * Vector_ay) * Math.Sqrt(Vector_Xx * Vector_Xx + Vector_Xy * Vector_Xy);


            //计算oa和x轴夹角余弦值
            double Cos_a = Point_Mul_a / Mul_a;
            double A_Cos = Math.Acos(Cos_a);
            //求出几何坐标系中的角度，即按逆时针的方法
            double A_Angle = A_Cos * (180 / Math.PI);

            //b和X轴上向量的点乘积
            double Point_Mul_b = (Vector_bx * Vector_Xx) + (Vector_by * Vector_Xy);
            double Mul_b = Math.Sqrt(Vector_bx * Vector_bx + Vector_by * Vector_by) * Math.Sqrt(Vector_Xx * Vector_Xx + Vector_Xy * Vector_Xy);
            ////计算b和x轴夹角余弦值
            double Cos_b = Point_Mul_b / Mul_b;
            double B_Cos = Math.Acos(Cos_b);
            //求出几何坐标系中的角度，即按逆时针的方法
            double B_Angle = B_Cos * (180 / Math.PI);

            //初始化画板
            //Graphics gr = this.CreateGraphics();
            //Brush br = new SolidBrush(Color.Black);
            //Pen pe = new Pen(PointColor, 10);
            //画出原点
            //gr.FillEllipse(br, 200, 200, 7, 7);

            double radius = Math.Sqrt((center.X-p1.X)*(center.X-p1.X)+(center.Y-p1.Y)*(center.Y-p1.Y));
            //画出圆弧
            objVectorGraphics.DrawArc(pe,
                                       (float)(center.X - radius),
                                       (float)(center.Y - radius),
                                       (float)radius * 2,
                                       (float)radius * 2,
                                       (float)(B_Angle),
                                       (float)(A_Angle - B_Angle));
        }


        /// <summary>
        /// 初始化刻度和刻度上的文字，SetXAxis（）和SetYAxis（）：
        /// </summary>
        /// <param name="objGraphics"></param>
        //private void SetXAxis(ref Graphics objGraphics)
        // {
        //int x1 = 100;
        //int y1 = Height - 110;
        //int x2 = 100;
        //int y2 = Height - 90;
        //int iCount = 0;
        //int iSliceCount = 1;
        //float Scale = 0;
        //int iWidth = (int)((Width - 200) * (50 / XSlice));

        //objGraphics.DrawString(Keys[0].ToString(), new Font("宋体", 10), new SolidBrush(AxisColor), 85, Height - 90);

        //for (int i = 0; i <= iWidth; i += 10)
        //{
        //    Scale = i * (XSlice / 50);

        //    if (iCount == 5)
        //    {
        //        objGraphics.DrawLine(new Pen(new SolidBrush(AxisColor)), x1 + Scale, y1, x2 + Scale, y2);
        //        //The Point!这里显示X轴刻度
        //        if (iSliceCount <= Keys.Length - 1)
        //        {
        //            objGraphics.DrawString(Keys[iSliceCount].ToString(), new Font("宋体", 10), new SolidBrush(AxisColor), x1 + Scale - 15, y2);
        //        }
        //        else
        //        {
        //            //超过范围，不画任何刻度文字
        //        }
        //        iCount = 0;
        //        iSliceCount++;
        //        if (x1 + Scale > Width - 100)
        //        {
        //            break;
        //        }
        //    }
        //    else
        //    {
        //        objGraphics.DrawLine(new Pen(new SolidBrush(SliceColor)), x1 + Scale, y1 + 5, x2 + Scale, y2 - 5);
        //    }
        //    iCount++;
        //}
        // }
        //
        //private void SetYAxis(ref Graphics objGraphics)
        // {
        //int x1 = 95;
        //int y1 = (int)(Height - 100 - 10 * (YSlice / 50));
        //int x2 = 105;
        //int y2 = (int)(Height - 100 - 10 * (YSlice / 50));
        //int iCount = 1;
        //float Scale = 0;
        //int iSliceCount = 1;

        //int iHeight = (int)((Height - 200) * (50 / YSlice));

        //objGraphics.DrawString(YSliceBegin.ToString(), new Font("宋体", 10), new SolidBrush(SliceTextColor), 60, Height - 110);

        //for (int i = 0; i < iHeight; i += 10)
        //{
        //    Scale = i * (YSlice / 50);

        //    if (iCount == 5)
        //    {
        //        objGraphics.DrawLine(new Pen(new SolidBrush(AxisColor)), x1 - 5, y1 - Scale, x2 + 5, y2 - Scale);
        //        //The Point!这里显示Y轴刻度
        //        objGraphics.DrawString(Convert.ToString(YSliceValue * iSliceCount + YSliceBegin), new Font("宋体", 10), new SolidBrush(SliceTextColor), 60, y1 - Scale);

        //        iCount = 0;
        //        iSliceCount++;
        //    }
        //    else
        //    {
        //        objGraphics.DrawLine(new Pen(new SolidBrush(SliceColor)), x1, y1 - Scale, x2, y2 - Scale);
        //    }
        //    iCount++;
        //}
        // }


    }
}
