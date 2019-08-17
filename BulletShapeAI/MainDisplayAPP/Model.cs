using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MainDisplayAPP
{
    class Model
    {
        public string modelName;
        public string modelPathName;
        public string modelNotes;
        public List<Edge> edges;
        public List<EndPoint> characterSet;//特征集合
        public double dragCoefficient;//阻力系数

        public Model(string modelName, string modelPathName)
        {
            this.modelName = modelName;
            this.modelPathName = modelPathName;
            this.modelNotes = string.Empty;
            try
            {
                this.dragCoefficient = Convert.ToDouble(modelName.Substring(modelName.IndexOf("_cd") + 3,
                                                        modelName.IndexOf(".js") - modelName.IndexOf("_cd") - 3));
            }
            catch (Exception e)
            {
                new ShowException(this.modelPathName + "\\" + this.modelName + "文件名:" + e.Message);
            }
            //搜集模型所有边
            string jsText = File.ReadAllText(this.modelPathName);
            this.edges = getEdges(jsText);
        }


        /// <summary>
        /// 按X坐标轴向采集指定个数特征点，并存入模型特征集合
        /// </summary>
        /// <param name="CharaterNumber"></param>
        /// <param name="startX"></param>
        /// <param name="endX"></param>
        public void GenerateModelCharaterByX(int CharaterNumber, double startX, double endX)
        {
            characterSet = new List<EndPoint>();
            try
            {
                this.characterSet = new List<EndPoint>();
                double Xstep = (endX - startX) / (CharaterNumber - 1);//求步长
                for (int i = 0; i < CharaterNumber; i++)//初始化特征点X坐标，求对应特征点Y坐标
                {
                    EndPoint newPoint = new EndPoint();//生成特征点
                    if (i == 0)
                    {
                        newPoint.preX = double.MinValue;
                        newPoint.preY = double.MinValue;
                    }
                    if (i == CharaterNumber)
                    {
                        newPoint.preX = characterSet[characterSet.Count - 1].X;
                        newPoint.preY = characterSet[characterSet.Count - 1].Y;
                        newPoint.backX = double.MaxValue;
                        newPoint.backX = double.MaxValue;
                    }
                    if (i > 0 && i < CharaterNumber)
                    {
                        newPoint.preX = characterSet[characterSet.Count - 1].X;
                        newPoint.preY = characterSet[characterSet.Count - 1].Y;
                    }
                    newPoint.X = startX + i * Xstep;
                    foreach (Edge edge in this.edges)
                    {
                        //if (newPoint.X >= edge.points[0].X && newPoint.X <= edge.points[edge.points.Count - 1].X)用于三点弧
                        switch (edge.edgeType)
                        {
                            case EdgeType.Line://是直线
                                {
                                    if (edge.points[0].Y <= 10 && edge.points[1].Y <= 10 && newPoint.X >= edge.points[0].X && newPoint.X <= edge.points[1].X)
                                        newPoint.Y = ((Line)edge).getY(newPoint);
                                    if (edge.points[0].X >= 0 && edge.points[1].X <= 60 && (edge.points[0].Y > 10 || edge.points[1].Y > 10))
                                    {
                                        string tempstr = "(" + edge.points[0].X.ToString() + "," + edge.points[0].Y.ToString() + ")--"
                                            + "(" + edge.points[1].X.ToString() + "," + edge.points[1].Y.ToString() + ")";

                                        if (!this.modelNotes.Contains(tempstr)) this.modelNotes += "模型中直线" + tempstr + "尺寸出错\n";
                                    }
                                    break;
                                }
                            case EdgeType.ArcCtrEdge://是三点圆弧
                                {
                                    //if (this.modelName.Contains("Flat3_Head20")&&newPoint.X>20)
                                    //    new ShowException("Flat3_Head20");
                                    if (edge.points[1].Y <= 10 && edge.points[2].Y <= 10 && newPoint.X >= edge.points[1].X && newPoint.X <= edge.points[2].X)
                                    {
                                        newPoint.Y = ((ArcCtrEdge)edge).getYbyCenterTwoPoints(newPoint);
                                        if (double.IsPositiveInfinity(newPoint.Y))
                                            this.modelName += "有弧含双值点";
                                    }
                                    if (edge.points[1].Y > 10 || edge.points[2].Y > 10)
                                    {
                                        string tempstr = "(" + edge.points[1].X.ToString() + "," + edge.points[1].Y.ToString() + ")--"
                                            + "(" + edge.points[2].X.ToString() + "," + edge.points[2].Y.ToString() + ")";

                                        if (!this.modelNotes.Contains(tempstr)) this.modelNotes += "模型中圆弧" + tempstr + "尺寸出错\n";
                                    }
                                    break;
                                }
                        }
                    }

                    if (i == CharaterNumber)
                    {
                        characterSet[characterSet.Count - 1].backX = newPoint.X;
                        characterSet[characterSet.Count - 1].backY = newPoint.Y;
                    }
                    if (i > 0 && i < CharaterNumber)
                    {
                        newPoint.preX = characterSet[characterSet.Count - 1].X;
                        newPoint.preY = characterSet[characterSet.Count - 1].Y;
                        characterSet[characterSet.Count - 1].backX = newPoint.X;
                        characterSet[characterSet.Count - 1].backY = newPoint.Y;
                    }
                    this.characterSet.Add(newPoint);
                }
            }
            catch (Exception ex)
            {
                new ShowException(ex.Message);
            }
        }

        /// <summary>
        /// 按Y坐标轴向采集指定个数特征点，并存入模型特征集合
        /// </summary>
        /// <param name="CharaterNumber"></param>
        /// <param name="startX"></param>
        /// <param name="endX"></param>
        public void GenerateModelCharaterByY(int CharaterNumber, double startY, double endY)
        {
            characterSet.Clear();

        }


        private List<Edge> getEdges(string jsText)
        {
            List<Edge> edges = new List<Edge>();

            foreach (int e in Enum.GetValues(typeof(EdgeType)))
            {
                List<int> locals = new List<int>();
                List<string> XYstring = new List<string>();
                getSubStrLocal(jsText, Enum.GetName(typeof(EdgeType), e) + "(", locals, XYstring);//获取模型脚本中当前关键边所有JS代码文本位置
                foreach (string XYstr in XYstring)
                {
                    List<EndPoint> edgePoints = getXY(XYstr);
                    switch ((EdgeType)e)
                    {
                        case EdgeType.Line://是直线
                            {
                                Line newLine = new Line(edgePoints, (EdgeType)e);
                                edges.Add(newLine);
                                break;
                            }
                        case EdgeType.ArcCtrEdge://是三点圆弧
                            {
                                ArcCtrEdge newArcCtrEdge = new ArcCtrEdge(edgePoints, (EdgeType)e);
                                edges.Add(newArcCtrEdge);
                                break;
                            }
                    }
                }
            }
            return edges;
        }


        //递归获取子串所有位置
        private void getSubStrLocal(string mother, string sub, List<int> locals, List<string> XYstring)
        {
            if (mother.Contains(sub))
            {
                int local = mother.IndexOf(sub);
                if (locals.Count == 0)
                {
                    locals.Add(local);
                }
                else
                {
                    locals.Add(local + locals[locals.Count - 1] + sub.Length);
                }
                int XYstartPosition = local + sub.Length;
                int len = mother.Substring(XYstartPosition).IndexOf(");");
                string str = mother.Substring(XYstartPosition, len);
                XYstring.Add(str);
                mother = mother.Substring(XYstartPosition);
                getSubStrLocal(mother, sub, locals, XYstring);
            }
        }
        //根据给定位置获取模型边端点坐标键值对集合
        private List<EndPoint> getXY(string XYstr)
        {
            List<EndPoint> XYs = new List<EndPoint>();
            //string XYstr = mother.Substring(local, mother.IndexOf(");") - local);
            try
            {
                string[] strXYs = XYstr.Split(',');
                int i = 0;
                EndPoint XY = new EndPoint();
                foreach (string str in strXYs)
                {
                    if (i % 2 == 0)
                    {
                        XY.X = Convert.ToDouble(System.Text.RegularExpressions.Regex.Replace(str, @"X(?<x>-?\d+.\d+) Y(?<y>-?\d+.\d+) Z-?\d+.\d+", ""));
                    }
                    else
                    {
                        XY.Y = Convert.ToDouble(System.Text.RegularExpressions.Regex.Replace(str, @"X(?<x>-?\d+.\d+) Y(?<y>-?\d+.\d+) Z-?\d+.\d+", ""));
                        XYs.Add(XY);
                        XY = new EndPoint();
                    }
                    i++;
                }
                return XYs;
            }
            catch (Exception ex)
            {
                new ShowException(ex.Message);
                return null;
            }

        }
        /// <summary>
        /// 执行JS
        /// </summary>
        /// <param name="sExpression">JS函数脚本</param>
        /// <param name="sCode">JS代码字符集</param>
        /// <returns></returns>
        private string ExecuteScirpt(string sExpression, string sCode)
        {
            MSScriptControl.ScriptControl scriptControl = new MSScriptControl.ScriptControl();
            scriptControl.UseSafeSubset = true;
            scriptControl.Language = "JScript";
            scriptControl.AddCode(sCode);
            try
            {
                string str = scriptControl.Eval(sExpression).ToString();
                return str;
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            return null;
        }
    }
}
