using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Net;

namespace StorageService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string storeWebPage(string url)
        {
            //Uri fileUri = new Uri(url);
            const string virtualPath = "http://localhost:63959/UploadedFiles/";
            //string fileName = Path.GetFileName(url);
            string[] urlSplit = url.Split('/');
            int n = urlSplit.Length;
            string fileName = urlSplit[3];
            WebClient webClient = new WebClient();
            string localPath = HttpContext.Current.Server.MapPath(".") + "\\" + "UploadedFiles\\";
            if (!Directory.Exists(localPath))
            {
                Directory.CreateDirectory(localPath);
            }
            if (File.Exists(localPath + fileName))
            {
                string[] x = fileName.Split('.');
                string temp = "";
                for (int i = 0; i < x.Length; i++)
                {
                   temp += x[i];
                   if (i == x.Length - 2)
                   {
                       temp += "1.";
                   }
                }
            }
            webClient.DownloadFile(url, localPath + fileName);
            
            return virtualPath + fileName;
        }
    }
}
