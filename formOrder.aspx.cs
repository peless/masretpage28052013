using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



public partial class formOrder : System.Web.UI.Page
{
    DropDownList DDL;
    
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            DDL = new DropDownList();
            ListItem item = new ListItem();
            DBservices dbs = new DBservices();
            List<string> itemList = new List<string>();
            itemList = dbs.getVendorName();
            DDL.Items.Add(" ");
            foreach (string name in itemList)
            {
                DDL.Items.Add(name);
            }



            DDL.SelectedIndexChanged += new EventHandler(dynamicDDL_SelectedIndexChanged);

            VendorDDL.Controls.Add(DDL);
        }
        catch (Exception ex)
        {
            ErrHandler.WriteError(ex.Message);
            Response.Write("ארעה שגיאה");
        }
     
        
    }


    protected void dynamicDDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            DropDownList DDL = sender as DropDownList;
            string vendor = (DDL.SelectedItem).ToString();

            DBservices dbs = new DBservices();
            string SNvendor = dbs.getVendorSN(vendor);
            Session["vendor"] = SNvendor;
        }
        catch (Exception ex)
        {
            ErrHandler.WriteError(ex.Message);
            Response.Write("ארעה שגיאה");
        }
      
    }
      
    

  protected void goToitemOrder(object sender, EventArgs e)
  {
      try
      {
          string OrderDate = TBdate.Text;
          //OrderDateCalendar.SelectedDate.ToShortDateString();
          Session["OrderDate"] = OrderDate;

          Response.Redirect("itemOrder.aspx",false);
      }
      catch (Exception ex)
      {
          ErrHandler.WriteError(ex.Message);
          Response.Write("ארעה שגיאה");
      }
     
  }



}