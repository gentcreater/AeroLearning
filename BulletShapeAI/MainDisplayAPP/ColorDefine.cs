using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace MainDisplayAPP
{
    public partial class ColorDefine : ComboBox
    {
        public ColorDefine()
        {            
            InitItems();
        }
        /// <summary>
        /// 构造下拉颜色选择框
        /// </summary>
        private void InitItems()
        {
            this.DrawMode = DrawMode.OwnerDrawFixed;//手动绘制所有元素
            this.DropDownStyle = ComboBoxStyle.DropDownList;//下拉框样式设置为不能编辑
            this.Items.Clear();//清空原有项
            Array allColors = Enum.GetValues(typeof(KnownColor));//获取系统颜色名存入列表
            foreach (KnownColor var in allColors)
            {
                this.Items.Add(var.ToString()); //加载该选项框的子项
            }
            this.SelectedIndex = 0;
        }
        /// <summary>
        /// 重写OnDrawItem方法
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index >= 0)//判断是否需要重绘
            {
                string colorName = this.Items[e.Index].ToString();//获取颜色名
                SolidBrush brush = new SolidBrush(Color.FromName(colorName));//定义画刷
                Font font = new Font("宋体", 9);//定义字体
                Rectangle rect = e.Bounds;
                rect.Inflate(-2, -2);

                Rectangle rectColor = new Rectangle(rect.Location, new Size(20, rect.Height));
                e.Graphics.FillRectangle(brush, rectColor);//填充颜色
                e.Graphics.DrawRectangle(Pens.Black, rectColor);//绘制边框
                e.Graphics.DrawString(colorName, font, Brushes.Black, (rect.X + 22), rect.Y);//绘制文字
            }
        }
        /// <summary>
        /// 选择的颜色名称
        /// </summary>
        public string SelectColorName
        {
            get { return this.Text; }
        }

        /// <summary>
        /// 选择的颜色
        /// </summary>
        public Color SelectColor
        {
            get { return Color.FromName(this.Text); }
        }


        //private void ColorDefine_ClientSizeChanged(object sender, EventArgs e)
        //{
        //    Color color = Color.FromName(this.Text);

        //}
    }
}