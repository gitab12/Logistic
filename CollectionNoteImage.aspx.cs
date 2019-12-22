using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;


public partial class CollectionNoteImage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FileUpload FileCtrl = (FileUpload)Session["FileCtrl"];
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
    }
}
