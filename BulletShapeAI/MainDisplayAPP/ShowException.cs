using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainDisplayAPP
{
    class ShowException
    {
        public ShowException(string message)
        {
            MessageBox.Show(message,"异常捕获");
        }

        public ShowException(string Title,string message, Boolean hasTxtBox)
        {
            Form form = new Form();
            form.Text = Title;
            form.Width = 500;
            form.Height = 1000;
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            TextBox txtbox = new TextBox();
            txtbox.Text = message;
            txtbox.Multiline = true;
            txtbox.ScrollBars = ScrollBars.Vertical;
            txtbox.Location = new System.Drawing.Point(10, 10);
            txtbox.Size = new System.Drawing.Size(470, 940);

            form.Controls.Add(txtbox);
            form.ShowDialog();
        }
    }
}
