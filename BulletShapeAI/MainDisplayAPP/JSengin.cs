using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Permissions;
using System.Windows.Forms;
using System.IO;

namespace MainDisplayAPP
{
    /// <summary>
    /// 访问模型JS文件
    /// </summary>

    class JSengin
    {
        public string JsPath;
        public List<string> SubJsPaths;
        public List<List<string>> JsFiles;
        public List<List<Model>> ModelsSet;
        public int CHARATERNUMBER;//特征采集数
        public EndPoint modelRectangleStartPoint, modelRectangleEndPoint;//模型采集矩形区域对角坐标点
        public JSengin(string JsPath,int CharaterNumber, EndPoint modelRectangleStartPoint,EndPoint modelRectangleEndPoint)
        {
            //this.JsPath = AppDomain.CurrentDomain.BaseDirectory + @"ModelSamples\";
            this.JsPath = JsPath;
            this.CHARATERNUMBER = CharaterNumber;
            this.modelRectangleStartPoint = modelRectangleStartPoint;
            this.modelRectangleEndPoint = modelRectangleEndPoint;
            this.SubJsPaths = new List<string>();
            this.JsFiles = new List<List<string>>();
            this.ModelsSet = new List<List<Model>>();
            getDirectory(this.JsPath);//初始化获取JsPath目录下所有子目录和JS文件
            transferAllJsToModel();
        }
        /*
        * 获得指定路径下所有文件名
        * string subpath      子文件路径
        */
        public void getFileName(string subpath,List<string> subJsFiles)
        {
            DirectoryInfo root = new DirectoryInfo(subpath);
            foreach (FileInfo f in root.GetFiles())
            {
                subJsFiles.Add(f.Name);
            }
        }

        /// <summary>
        /// //获得指定路径下所有子目录名和文件
        /// </summary>
        /// <param name="path"></param>
        public void getDirectory(string path)
        {
            this.SubJsPaths.Add(path);
            List<string> subfiles = new List<string>();
            getFileName(path,subfiles);//获取当前路径下所有文件名
            this.JsFiles.Insert(this.SubJsPaths.IndexOf(path), subfiles);//将子文件集加入文件大家和与目录集合对应位置

            DirectoryInfo root = new DirectoryInfo(path);
            foreach (DirectoryInfo d in root.GetDirectories())
            {
                getDirectory(d.FullName);
            }
        }

        /// <summary>
        /// 根据JS模型文件生成模型对象
        /// </summary>
        public void transferAllJsToModel()
        {
            foreach (string path in this.SubJsPaths)
            {
                int i = this.SubJsPaths.IndexOf(path);
                List<Model> newSubModels = new List<Model>();                
                foreach (string file in this.JsFiles[i])
                {
                    int j = this.JsFiles[i].IndexOf(file);
                    string FilePathName = path +"\\"+ file;
                    Model newModel = new Model(file,FilePathName);
                    //if (file.Contains("Flat1_Head15_chamfer_cd0.48075213"))
                    //    new ShowException("Flat1_Head15_chamfer_cd0.48075213");

                    newModel.GenerateModelCharaterByX(this.CHARATERNUMBER,this.modelRectangleStartPoint.X,this.modelRectangleEndPoint.X);//以X轴坐标生成模型特征集
                    newSubModels.Insert(j,newModel);
                }
                this.ModelsSet.Insert(i,newSubModels);
            }
        }

    }
}
