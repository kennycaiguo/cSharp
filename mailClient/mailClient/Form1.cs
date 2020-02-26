using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
 
using System.Text;
using System.IO;
using System.Linq;
using System.Net;
 
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace mailClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string filePath = "";
        string strfilename;
         
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd =new OpenFileDialog();
            if (DialogResult.OK == ofd.ShowDialog())
            {
                textBox_file.Text = ofd.FileName;
                filePath = textBox_file.Text.Trim();
               int pos= filePath.LastIndexOf("\\");
               strfilename = filePath.Substring(pos+1);
               MessageBox.Show(strfilename );
            }
            else
            {
                MessageBox.Show("No File Selected");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public int UpLoadFile(string address, string fileNamePath, string saveName, ProgressBar progressBar)
        {
            int returnValue = 0;
            //要上传的文件
            FileStream fs = new FileStream(fileNamePath, FileMode.Open, FileAccess.Read);
            //二进制对象
            BinaryReader r = new BinaryReader(fs);
            //时间戳
            string strBoundary = "----------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + strBoundary + "\r\n");
            //请求的头部信息
            StringBuilder sb = new StringBuilder();
            sb.Append("--");
            sb.Append(strBoundary);
            sb.Append("\r\n");
            sb.Append("Content-Disposition: form-data; name=\"");
            sb.Append("file");
            sb.Append("\"; filename=\"");
            sb.Append(saveName);
            sb.Append("\";");
            sb.Append("\r\n");
            sb.Append("Content-Type: ");
            sb.Append("application/octet-stream");
            sb.Append("\r\n");
            sb.Append("\r\n");
            string strPostHeader = sb.ToString();
            byte[] postHeaderBytes = Encoding.UTF8.GetBytes(strPostHeader);
            // 根据uri创建HttpWebRequest对象   
            HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(new Uri(address));
            httpReq.Method = "POST";
            //对发送的数据不使用缓存   
            httpReq.AllowWriteStreamBuffering = false;
            //设置获得响应的超时时间（300秒）   
            httpReq.Timeout = 300000;
            httpReq.ContentType = "multipart/form-data; boundary=" + strBoundary;
            long length = fs.Length + postHeaderBytes.Length + boundaryBytes.Length;
            long fileLength = fs.Length;
            httpReq.ContentLength = length;
            
                progressBar.Maximum = int.MaxValue;
                progressBar.Minimum = 0;
                progressBar.Value = 0;
                //每次上传4k  
                int bufferLength = 4096;
                byte[] buffer = new byte[bufferLength]; //已上传的字节数   
                long offset = 0;         //开始上传时间   
                DateTime startTime = DateTime.Now;
                int size = r.Read(buffer, 0, bufferLength);
                Stream postStream = httpReq.GetRequestStream();         //发送请求头部消息   
                postStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
                while (size > 0)
                {
                    postStream.Write(buffer, 0, size);
                    offset += size;
                    progressBar.Value = (int)(offset * (int.MaxValue / length));
                    TimeSpan span = DateTime.Now - startTime;
                    double second = span.TotalSeconds;
                    labSize.Text = "已用时：" + second.ToString("F2") + "秒";
                    if (second > 0.001)
                    {
                        labSpeed.Text = "平均速度：" + (offset / 1024 / second).ToString("0.00") + "KB/秒";
                    }
                    else
                    {
                        labSpeed.Text = " 正在连接…";
                    }
                    labState.Text = "已上传：" + (offset * 100.0 / length).ToString("F2") + "%";
                    labSize.Text = (offset / 1048576.0).ToString("F2") + "M/" + (fileLength / 1048576.0).ToString("F2") + "M";
                    Application.DoEvents();
                    size = r.Read(buffer, 0, bufferLength);
                }
                //添加尾部的时间戳   
                postStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                postStream.Close();
                //获取服务器端的响应   
                WebResponse webRespon = httpReq.GetResponse();
                Stream s = webRespon.GetResponseStream();
                //读取服务器端返回的消息  
                StreamReader sr = new StreamReader(s);
                String sReturnString = sr.ReadLine();
                s.Close();
                sr.Close();
                if (sReturnString == "Success")
                {
                    returnValue = 1;
                }
                else if (sReturnString == "Error")
                {
                    returnValue = 0;
                }
            
             
                fs.Close();
                r.Close();
            
            return returnValue;
        }

        
        private void Upload(string address, string fileNamePath, string saveName)
        {
            WebClient webClient = new WebClient();
            //使用Windows登录方式
            webClient.Credentials = new NetworkCredential("kennycai", "123");
            
            //上传的链接地址（文件服务器）
            Uri uri = new Uri(address + saveName);
            MessageBox.Show(uri.ToString());
            webClient.UploadFileAsync(uri, "PUT", filePath);
            webClient.Dispose();
        }
        private void btnUpload_Click(object sender, EventArgs e)
        {

            //上传服务器的地址（web服务）
            
            string address = "http://localhost/";//前提是已经配置好了IIS并且部署了网页aspx
            //上传后文件保存的名称
            string saveName = strfilename;
            int count = UpLoadFile(address, filePath, saveName, this.progressBar1);


            if (count == 1)
            {
                MessageBox.Show("success");
            }
            else
            {
                MessageBox.Show("Failed");
            }

            //Upload(address, filePath, saveName);
        }

}

}

