using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;




public partial class UpDatePatient : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Patient> listPatient = new List<Patient>();
        try
        {
            if (!IsPostBack)
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

                DropDownList DDL = sender as DropDownList;
                


                NameValueCollection coll = Request.QueryString;
                string IdPatient = coll["P_id"];

                listPatient = dbs.InfoPatient(IdPatient);

                foreach (Patient x in listPatient)
                {

                    Label lbName = new Label();
                    lbName.Text = x.Name;
                    PHPatientName.Controls.Add(lbName);

                    Label lbNum = new Label();
                    lbNum.Text = x.Num;
                    PHPatientNum.Controls.Add(lbNum);

                    Label lbID = new Label();
                    lbID.Text = x.P_id;
                    PHPatientID.Controls.Add(lbID);

                    DDPatientKupah.SelectedValue = x.Kupah;


                    if (x.Zantar == "False")
                        DDPatientZantar.SelectedValue = "לא";
                    else
                        DDPatientZantar.SelectedValue = "כן";

                    DDneedle.SelectedValue = x.Needle;
                    DDcoil.SelectedValue = x.Coil;
                    DDinfusionBag.SelectedValue = x.InfusionBag;
                    DDsolutions.SelectedValue = x.Solutions;
                   

                }
            }

        }
        catch (Exception ex)
        {
            ErrHandler.WriteError(ex.Message);
            Response.Write("ארעה שגיאה");
        }
    }


    protected void ButtonPatient_Click(object sender, EventArgs e)
    {
        DBservices dbs = new DBservices();
        try
        {
            NameValueCollection coll = Request.QueryString;
            string ID = coll["P_id"];
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

            dbs.UpDatePatient(ID, Kupah, Zantar,needle,coil,infusionBag,solutions);
            Response.Redirect("PatientList.aspx");
            
        }
        catch (Exception ex)
        {
            ErrHandler.WriteError(ex.Message);
            Response.Write("קיימת בעיה אנא נסה שנית מאוחר יותר");
        }
    }

}