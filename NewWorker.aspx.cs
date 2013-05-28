using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NewWorker : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ButtonNewWorker_Click(object sender, EventArgs e)
    {


        DBservices dbs = new DBservices();

        try
        {

            string Name = TBworkerName.Text;
            string ID = TBworkerID.Text;
            string Pass = TBworkerPass.Text;
            string Title = (DDLworkerTitle.SelectedItem).ToString();
            dbs.insertNewWorker(Name, ID, Pass, Title);

            Response.Write("<script>alert('העובד נקלט במערכת בהצלחה');</script>");
        }
        catch (Exception ex)
        {
            ErrHandler.WriteError(ex.Message);
            Response.Write("קיימת בעיה אנא נסה שנית מאוחר יותר");
        }

    }
}