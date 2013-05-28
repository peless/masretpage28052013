using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DBservices dbs = new DBservices();

        try
        {
            bool iswork = dbs.chekID(TBIDworker.Text);

            if (iswork == true)
            {
                dbs.insertNewPass(TBIDworker.Text, TBPASSworker.Text);
                Response.Write("<script>alert('הסיסמא שונתה בהצלחה');</script>");
            }
            else
                Response.Write("<script>alert('ת.ז שהוקש אינו קיים במערכת');</script>");
        }
        catch (Exception ex)
        {
            ErrHandler.WriteError(ex.Message);
            Response.Write("קיימת בעיה אנא נסה שנית מאוחר יותר");
        }

    }


}