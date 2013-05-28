using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;


public partial class Getexcel2 : System.Web.UI.Page

{
    DataTable dt = new DataTable();
    bool FUused = false;
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void UploadButton_Click(object sender, EventArgs e)
    {
        try
        {
            FUused = true;
            // Before attempting to save the file, verify
            // that the FileUpload control contains a file.
            if (FileUpload1.HasFile)
                // Call a helper method routine to save the file.
                SaveFile(FileUpload1.PostedFile);
            else
                // Notify the user that a file was not uploaded.
                UploadStatusLabel.Text = "לא נבחר קובץ להעלאה.";
        }
        catch (Exception ex)
        {
            ErrHandler.WriteError(ex.Message);
            Response.Write("ארעה שגיאה");
        }
    }

    void SaveFile(HttpPostedFile file)
    {
        try
        {
            String ID = null;

            // Specify the path to save the uploaded file to.
            //string savePath = "c:\\temp\\";
            //string savePath = "~\\Excel\\";
            string savePath = Server.MapPath("~/Excel/");

            // Get the name of the file to upload.
            string fileName = FileUpload1.FileName;

            // Create the path and file name to check for duplicates.
            string pathToCheck = savePath + fileName;

            // Create a temporary file name to use for checking duplicates.
            string tempfileName = "";


            // Check to see if a file already exists with the
            // same name as the file to upload.        
            if (System.IO.File.Exists(pathToCheck))
                if (FileUpload1.PostedFile.ContentType == "application/vnd.ms-excel" || FileUpload1.PostedFile.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    int counter = 2;
                    while (System.IO.File.Exists(pathToCheck))
                    {
                        // if a file with this name already exists,
                        // prefix the filename with a number.
                        tempfileName = counter.ToString() + fileName;
                        pathToCheck = savePath + tempfileName;
                        counter++;
                    }

                    fileName = tempfileName;

                    // Notify the user that the file name was changed.
                    UploadStatusLabel.Text = "File Name: " + fileName;
                }
                else
                    // Notify the user that a file was not an excel file.
                    UploadStatusLabel.Text = "ניתן לעלות רק קבצי אקסל ו-סי אס וי";
            else
            {
                // Notify the user that the file was saved successfully.
                UploadStatusLabel.Text = "הקובץ הועלה בהצלחה.";
            }

            // Append the name of the file to upload to the path.
            savePath += fileName;

            // Call the SaveAs method to save the uploaded
            // file to the specified directory.
            FileUpload1.SaveAs(savePath);
            //Branch_NUM	INV_NUM	DEL_ID	SN	Quant	Price	Sum	date


            dt.Columns.Add("DEL_ID", typeof(String));
            dt.Columns.Add("SN", typeof(String));
            dt.Columns.Add("Quant", typeof(int));
            dt.Columns.Add("Price", typeof(float));
            dt.Columns.Add("Sum", typeof(float));
            dt.Columns.Add("Date", typeof(DateTime));
            dt.Columns.Add("Branch_NUM", typeof(String));

            //DEL_ID	SN	Quant	Price	Sum	date	Branch_NUM



            string[] csvRows = File.ReadAllLines(savePath);
            csvRows[0] = null;
            csvRows = csvRows.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            string[] fields = null;
            foreach (string rows in csvRows)
            {
                fields = rows.Split(',');
                DataRow row = dt.NewRow();
                row.ItemArray = fields;
                dt.Rows.Add(row);

            }

            GridView1.Attributes.Add("class", "CSSTableGenerator");
            GridView1.DataSource = dt;
            GridView1.DataBind();



            DBservices dbs = new DBservices();
            ID = dbs.insertINV(dt);

            //invinsertlbl.Text = ID + "מספר החשבונית במערכת הוא: ";
            Session.Add("ID", ID);
        }
        catch (Exception ex)
        {
            ErrHandler.WriteError(ex.Message);
            Response.Write("ארעה שגיאה");
        }
    }


    protected void CreateReport(object sender, EventArgs e)
    {
        try
        {
            string ID = (string)(Session["id"]);
            Response.Redirect("Teva_Pay.aspx?ID=" + ID,false);
        }
        catch (Exception ex)
        {
            ErrHandler.WriteError(ex.Message);
            Response.Write("ארעה שגיאה");
        }
        
    } 
}