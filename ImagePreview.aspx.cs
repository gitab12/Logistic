using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class ImagePreview : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FileUpload FileCtrl =(FileUpload) Session["FileCtrl"];
        if (FileCtrl.HasFile)
        {
            string path = Server.MapPath("TempImages");

            FileInfo oFileInfo = new FileInfo(FileCtrl.PostedFile.FileName);
            string fileName = oFileInfo.Name;

            string fullFileName = path + "\\" + fileName;
            string imagePath = "TempImages/" + fileName;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            FileCtrl.PostedFile.SaveAs(fullFileName);
            Image1.ImageUrl = imagePath;
        }  

        //Rear image
        FileUpload FileCtrlRear = (FileUpload)Session["FileCtrlRear"];
        if (FileCtrlRear.HasFile)
        {
            string path = Server.MapPath("TempImages");

            FileInfo oFileInfo = new FileInfo(FileCtrlRear.PostedFile.FileName);
            string fileName = oFileInfo.Name;

            string fullFileName = path + "\\" + fileName;
            string imagePath = "TempImages/" + fileName;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            FileCtrlRear.PostedFile.SaveAs(fullFileName);
            Image2.ImageUrl = imagePath;
        }

        // FileCtrlSideL image
        FileUpload FileCtrlSideL = (FileUpload)Session["FileCtrlSideL"];
        if (FileCtrlSideL.HasFile)
        {
            string path = Server.MapPath("TempImages");

            FileInfo oFileInfo = new FileInfo(FileCtrlSideL.PostedFile.FileName);
            string fileName = oFileInfo.Name;

            string fullFileName = path + "\\" + fileName;
            string imagePath = "TempImages/" + fileName;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            FileCtrlSideL.PostedFile.SaveAs(fullFileName);
            Image3.ImageUrl = imagePath;
        }
        // FileCtrlSideR image
        FileUpload FileCtrlSideR = (FileUpload)Session["FileCtrlSideR"];
        if (FileCtrlSideR.HasFile)
        {
            string path = Server.MapPath("TempImages");

            FileInfo oFileInfo = new FileInfo(FileCtrlSideR.PostedFile.FileName);
            string fileName = oFileInfo.Name;

            string fullFileName = path + "\\" + fileName;
            string imagePath = "TempImages/" + fileName;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            FileCtrlSideR.PostedFile.SaveAs(fullFileName);
            Image4.ImageUrl = imagePath;
        }



    }
}
