using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;



public partial class Teva_Pay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string id = Request.QueryString["id"];

            DataTable dt = new DataTable();
            DBservices dbs = new DBservices();
            List<ItemInINV> list = new List<ItemInINV>();
            int Disc = 0;


            int Sum = dbs.GetTotSum(id);
            list = dbs.GetITEMINV(ID);

            LBLsum.Text = Sum.ToString() + "  :סכום";

            dt.Columns.Add("Reason");
            dt.Columns.Add("SN");
            dt.Columns.Add("Credit");


            foreach (ItemInINV x in list)
            {
                DataRow row = dt.NewRow();

                row[0] = "חיוב זיכוי";
                row[1] = x.Sn;
                row[2] = ((x.It_price - x.Inv_price) * x.Inv_quant);

                dt.Rows.Add(row);

                Disc += Convert.ToInt32(row[2]);
            }

            GV_PayTBL.DataSource = dt;
            GV_PayTBL.DataBind();

            //DataGrid DG = new DataGrid();
            //DG.DataSource = dt;
            //DG.DataBind();

            //Mailmsg msg = new Mailmsg();
            //string Body = msg.RenderControl(DG);

            //msg.Send(Body, "חשבונית");


            LBLdis.Text = (Sum + Disc).ToString() + " :סכום לאחר זיכוי";
        }
        catch (Exception ex)
        {
            ErrHandler.WriteError(ex.Message);
            Response.Write("ארעה שגיאה");
        }
    }

   


   
  
}