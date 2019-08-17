using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CaculateCd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //private bool IsNumeric(string str) //接收一个string类型的参数,保存到str里
        //{
        //    if (str == null || str.Length == 0)    //验证这个参数是否为空
        //        return false;                           //是，就返回False
        //    ASCIIEncoding ascii = new ASCIIEncoding();//new ASCIIEncoding 的实例
        //    byte[] bytestr = ascii.GetBytes(str);         //把string类型的参数保存到数组里

        //    foreach (byte c in bytestr)                   //遍历这个数组里的内容
        //    {
        //        if (c < 48 || c > 57)                          //判断是否为数字
        //        {
        //            return false;                              //不是，就返回False
        //        }
        //    }
        //    return true;                                        //是，就返回True
        //}
        double Diameter, headlength, bodylength, rearLength, rearDim, speed, speedMa, Viscosity, density, headDim, CirHeadLenght;

        private void textheadDim_TextChanged(object sender, EventArgs e)
        {
            this.txtCirHeadLenght.Text = (Convert.ToDouble(this.textheadDim.Text.Trim())/2).ToString();
        }

        private void txtV_TextChanged(object sender, EventArgs e)
        {
            this.txtVma.Text = (Convert.ToDouble(this.txtV.Text.Trim())/341.2).ToString();
        }

        private void txtCirHeadLenght_TextChanged(object sender, EventArgs e)
        {

        }

        const double PI = 3.1415926;
        double length, R, headR, rearR,Ma,nama,kesi;
        double L1, rearL1;
        double Cxf, Cxb, Cxh_zhui, Cxh_dan, Cxwb;

        protected bool isNumberic(TextBox txtmessage, out double result)
        {
            //判断是否为整数字符串
            //是的话则将其转换为数字并将其设为out类型的输出值、返回true, 否则为false
            result = -1;   //result 定义为out 用来输出值
            string message = txtmessage.Text.Trim();
            try
            {
                //当数字字符串的为是少于4时，以下三种都可以转换，任选一种
                //如果位数超过4的话，请选用Convert.ToInt32() 和int.Parse()

                //result = int.Parse(message);
                //result = Convert.ToInt16(message);
                result = Convert.ToDouble(message);
                return true;
            }
            catch
            {
                MessageBox.Show(txtmessage.Name + "输入格式有问题.");
                return false;
            }
        }
        private Boolean checkInput()
        {
            if (!isNumberic(this.txtDiameter, out Diameter)) return false;
            if (!isNumberic(this.txtHeadLength, out headlength)) return false;
            if (!isNumberic(this.txtBodylength, out bodylength)) return false;
            if (!isNumberic(this.txtRearLength, out rearLength)) return false;
            if (!isNumberic(this.txtRearDim, out rearDim)) return false;
            if (!isNumberic(this.txtV, out speed)) return false;
            //if (!isNumberic(this.txtVma, out speedMa)) return false;
            if (!isNumberic(this.txtViscosity, out Viscosity)) return false;
            if (!isNumberic(this.txtdensity, out density)) return false;
            if (!isNumberic(this.textheadDim, out headDim)) return false;
            //if (!isNumberic(this.txtCirHeadLenght, out CirHeadLenght)) return false;          
           
            R = 0.5 * Diameter;
            headR = 0.5 * headDim;
            rearR = 0.5 * rearDim;
            CirHeadLenght = headR;
            length = headlength + bodylength + rearLength + CirHeadLenght;
            nama = length / Diameter;
            kesi = rearDim / Diameter;
            Ma = Convert.ToDouble(this.txtV.Text.Trim()) / 341.2;
            this.txtCirHeadLenght.Text = (Convert.ToDouble(this.textheadDim.Text.Trim()) / 2).ToString();
            this.txtVma.Text = Ma.ToString();
            return true;
        }

        private void ComputeCxf()
        {
            //计算雷诺数
            double Re = density * speed * length / Viscosity;

            //计算大头母线长度
            L1 = Diameter * headlength / (Diameter - headDim);
            double L = Math.Sqrt(L1 * L1 + this.R * this.R);
            //计算小头母线长度
            double LL;
            if (rbtZhui.Checked)
                LL = Math.Sqrt((L1 - headlength - headR) * (L1 - headlength - headR) + headR * headR);
            else
                LL = Math.Sqrt((L1 - headlength) * (L1 - headlength) + headR * headR);
            //计算尾椎大母线
            rearL1 = Diameter * rearLength / (Diameter - rearDim);
            double rearL = Math.Sqrt(rearL1 * rearL1 + this.R * this.R);
            //计算尾椎小母线
            double rearLL = Math.Sqrt((rearL1 - headlength) * (rearL1 - headlength) + rearR * rearR);

            //计算侧面积
            double Sce;
            if (rbtZhui.Checked)
            {
                //计算小头母线长度
                Sce =(PI * this.R * L - PI * headR * LL) //锥台侧面积
                    + PI * Diameter * bodylength //圆柱侧面积
                    + (PI * R * rearL - PI * rearR * rearLL);//尾椎台侧面积
            }
            else
            {
                Sce = 0.5 * PI * headDim * headDim   //顶半球面积
                    + (PI * this.R * L - PI * headR * LL) //锥台侧面积
                    + PI * Diameter * bodylength //圆柱侧面积
                    + (PI * R * rearL - PI * rearR * rearLL);//尾椎台侧面积
            }

            //计算截面积
            double Sjie = R * R * PI;

            //计算摩阻系数_dan
            Cxf = 0.032 * (Sce / Sjie) / (Math.Pow(Re, 0.145) * Math.Sqrt(1 + 0.12 * Math.Pow(Ma, 2)));
            this.txtRe.Text = Re.ToString();
            this.txtSce.Text = Sce.ToString();
            this.txtSjie.Text = Sjie.ToString();
            this.txtSceSjie.Text = (Sce / Sjie).ToString();
            this.txtCxf.Text = Cxf.ToString();

        }

        private void ComputeCxb()
        {
            this.txtDanJinbi.Text = nama.ToString();
            this.txtDiSousuobi.Text = kesi.ToString();
            //计算摩阻系数
            Cxb = 1.14 * Math.Pow(kesi, 4) * (2/Ma-Math.Pow(kesi,2)/nama) / nama;
            this.txtCxb.Text = Cxb.ToString();
        }

        private void ComputeCxh()
        {
            //计算半顶角
            double Fic = Math.Atan(R / L1) * 180 / PI;
            //计算尾椎角
            double ak = Math.Atan(R/rearL1) * 180 / PI;
            //计算锥型头部波阻系数
             Cxh_zhui = (0.0016 + 0.002 / Math.Pow(Ma, 2)) * Math.Pow(Fic, 1.7);

            this.txtBanDingjiao.Text = Fic.ToString();
            this.txtWeizhuijiao.Text = ak.ToString();
            this.txtZhuiTouBoZuxishu.Text = Cxh_zhui.ToString();

            //计算弹形头部波阻系数
             Cxh_dan = Cxh_zhui * 0.08 * (15.5 + Ma) / (3 + Ma);
            this.txtDanTouBozuxishu.Text = Cxh_dan.ToString();

            //计算尾部波阻系数
            Cxwb = (0.0016 + 0.002 / Math.Pow(Ma, 2)) * Math.Pow(ak, 1.7) * Math.Sqrt(1 - kesi * kesi);
            this.txtWeizhuiBozuxishu.Text = Cxwb.ToString();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (checkInput()) {
                ComputeCxf();
                ComputeCxb();
                ComputeCxh();
                double Cxh;
                //if (rbtDan.Checked) Cxh = Cxh_dan;
                if (rbtZhui.Checked) Cxh = Cxh_zhui;
                else Cxh = Cxh_dan;

                if (Ma > 1)
                    this.lblCx0.Text = (Cxf + Cxb + Cxh + Cxwb).ToString();
                else
                    this.lblCx0.Text = (Cxf + Cxb + Cxh).ToString();
            }

        }
    }
}
