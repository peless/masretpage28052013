using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NewPatient : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {


            ListItem item = new ListItem();
            DBservices dbs = new DBservices();
            List<Item> itemList = new List<Item>();
            itemList = dbs.getItem();
           
            foreach (Item x in itemList)
            {
                if (x.Category == "מחטים")
                    DDneedle.Items.Add(x.Name);
                else
                    if (x.Category == "סליל")
                        DDcoil.Items.Add(x.Name);
                    else
                        if (x.Category == "שקית עירוי")
                            DDinfusionBag.Items.Add(x.Name);
                        else
                            if (x.Category == "תמיסה")
                                DDsolutions.Items.Add(x.Name);

         }
  
        }
        catch (Exception ex)
        {
            ErrHandler.WriteError(ex.Message);
            Response.Write("ארעה שגיאה");
        }
    }


    protected void ButtonNewPatient_Click(object sender, EventArgs e)
    {
        
        try
        {
            DBservices dbs = new DBservices();
            string Name = TBPatientName.Text;
            string ID = TBPatientId.Text;
            string Num = TBPatientNum.Text;
            string Kupah = (DDPatientKupah.SelectedItem).ToString();
            string Zantar = (DDPatientZantar.SelectedItem).ToString();
    
            if (Zantar == "כן")
                Zantar = "1";
            else
                Zantar = "0";

            string needle = (DDneedle.SelectedItem).ToString();
            string coil = (DDcoil.SelectedItem).ToString();
            string infusionBag = (DDinfusionBag.SelectedItem).ToString();
            string solutions = (DDsolutions.SelectedItem).ToString();


            string USERname = (string)(Session["Name"]);
            string USERpass = (string)(Session["Password"]);
            string USERid = dbs.getWorkerID(USERname, USERpass);
            string USERbranch = dbs.getWorkerBranch(USERid);


            dbs.insertNewPatient(ID, Kupah, Num, Name, Zantar, USERbranch, needle, coil, infusionBag, solutions);
            Response.Write("<script>alert('המטופל נשמר בהצלחה');</script>");
            Response.Redirect("PatientList.aspx");
        }
        catch (Exception ex)
        {
            ErrHandler.WriteError(ex.Message);
            Response.Write("קיימת בעיה אנא נסה שנית מאוחר יותר");
        }
    }

}