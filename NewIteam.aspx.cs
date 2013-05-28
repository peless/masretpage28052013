using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NewIteam : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            DBservices dbs = new DBservices();
            List<string> itemVendor = new List<string>();
            itemVendor = dbs.getVendorName();
            
            foreach (string name in itemVendor)
            {
                DDvandor.Items.Add(name);
            }

            
        }
        catch (Exception ex)
        {
            ErrHandler.WriteError(ex.Message);
            Response.Write("ארעה שגיאה");
        }


    }

    protected void addIteam_Click(object sender, EventArgs e)
    {

        try
        {
            DBservices dbs = new DBservices();
            string Name = TBNameItem.Text;
            string sn = TBsn.Text;
            string catrgory = (DDCatgory.SelectedItem).ToString();
            string numINbox = TBNumInBox.Text;
            string price = TBPrice.Text;
            string vandorsn = dbs.getVendorSN((DDvandor.SelectedItem).ToString());


            dbs.insertNewIteam(Name, sn, catrgory, numINbox, price, vandorsn);
            Response.Write("<script>alert('פריט נשמר בהצלחה');</script>");
            
        }
        catch (Exception ex)
        {
            ErrHandler.WriteError(ex.Message);
            Response.Write("קיימת בעיה אנא נסה שנית מאוחר יותר");
        }
    }

}