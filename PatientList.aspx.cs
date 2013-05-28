using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PatientList : System.Web.UI.Page
{
    List<Patient> listOfPatient = new List<Patient>();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                DropDownList DDL = sender as DropDownList;
                DBservices dbs = new DBservices();

                string nameWorker = ((string)Session["name"]);
                string paswordWorker = ((string)Session["password"]);

                listOfPatient = dbs.ReadPatient(nameWorker, paswordWorker);


                Table PatientTbl = new Table();
                PatientTbl.Attributes.Add("class", "CSSTableGenerator");

                TableRow CRow = new TableRow();

                TableCell ZantarCell = new TableCell();
                ZantarCell.Text = "שימוש בצנטר";
                CRow.Cells.Add(ZantarCell);

                TableCell KupahCell = new TableCell();
                KupahCell.Text = "קופת חולים";
                CRow.Cells.Add(KupahCell);

                TableCell NumCell = new TableCell();
                NumCell.Text = "מספר מטופל";
                CRow.Cells.Add(NumCell);


                TableCell NameCell = new TableCell();
                NameCell.Text = "שם המטופל";
                CRow.Cells.Add(NameCell);

                
                
                

                PatientTbl.Rows.Add(CRow);


                foreach (Patient x in listOfPatient)
                {
                    TableRow tRow = new TableRow();

                    TableCell zantarCell = new TableCell();
                    if (x.Zantar =="False")
                        zantarCell.Text = "לא";
                    else
                        zantarCell.Text = "כן";
                    tRow.Cells.Add(zantarCell);

                    TableCell kupahCell = new TableCell();
                    kupahCell.Text = x.Kupah;
                    tRow.Cells.Add(kupahCell);

                    TableCell numCell = new TableCell();
                    numCell.Text = x.Num;
                    tRow.Cells.Add(numCell);

                    HyperLink link = new HyperLink();
                    link.NavigateUrl = "UpDatePatient.aspx?P_id=" + x.P_id;
                    link.Text = x.Name;
                    TableCell nameCell = new TableCell();
                    nameCell.Controls.Add(link);
                    tRow.Cells.Add(nameCell);

                    

                   PatientTbl.Rows.Add(tRow);

                }


                divPatient.Controls.Add(PatientTbl);
            }
        }

        catch (Exception ex)
        {
            ErrHandler.WriteError(ex.Message);
            Response.Write("ארעה שגיאה");
        }
    }
}

