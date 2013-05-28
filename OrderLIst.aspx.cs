using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class OrderList : System.Web.UI.Page
{

    DropDownList DDL;
    List<Order> listOfOrder = new List<Order>();


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

                    listOfOrder = dbs.ReadOrder(nameWorker, paswordWorker);


                    Table OrderTbl = new Table();
                    OrderTbl.Attributes.Add("class", "CSSTableGenerator");

                    TableRow CRow = new TableRow();

                    TableCell IdCell = new TableCell();
                    IdCell.Text = "מספר הזמנה";
                    CRow.Cells.Add(IdCell);

                    TableCell SdCell = new TableCell();
                    SdCell.Text = "תאריך קבלת הזמנה";
                    CRow.Cells.Add(SdCell);

                    TableCell PCell = new TableCell();
                    PCell.Text = "תאריך יצירת הזמנה";
                    CRow.Cells.Add(PCell);

                    TableCell STATUSCell = new TableCell();
                    STATUSCell.Text = "סטטוס הזמנה";
                    CRow.Cells.Add(STATUSCell);


                    OrderTbl.Rows.Add(CRow);


                    foreach (Order x in listOfOrder)
                    {
                        TableRow tRow = new TableRow();

                        TableCell IDceLL = new TableCell();
                        IDceLL.Text = x.Po_id;

                        tRow.Cells.Add(IDceLL);

                        TableCell SDATECell = new TableCell();


                        if (x.Sup_date != "")
                        {
                            DateTime SDATE = new DateTime();
                            SDATE = Convert.ToDateTime(x.Sup_date);
                            SDATECell.Text = SDATE.ToShortDateString();
                        }
                        else
                            SDATECell.Text = x.Sup_date;
                        tRow.Cells.Add(SDATECell);

                      

                        TableCell PDATECell = new TableCell();
                          DateTime PDATE = new DateTime();
                          PDATE = Convert.ToDateTime(x.Po_date);
                       
                          
                          //PDATECell.Text = PDATE.ToShortDateString();
                          PDATECell.Text = PDATE.ToString("dd/MM/yy");
                

                        tRow.Cells.Add(PDATECell);


                        HyperLink link = new HyperLink();
                        link.NavigateUrl = "OrderConfirmation.aspx?Po_id=" + x.Po_id;
                        if (x.Status == "open")
                            link.Text = "פתוחה";
                        else if (x.Status == "cancelled")
                            link.Text = "מבוטלת";
                        else if (x.Status == "close")
                             link.Text = "אושרה";
                        else
                            link.Text = "מאושרת חלקית";
                        

                        TableCell SCell = new TableCell();
                        SCell.Controls.Add(link);
                        tRow.Cells.Add(SCell);

                        OrderTbl.Rows.Add(tRow);

                    }


                    divOrder.Controls.Add(OrderTbl);
                }
              }
            catch (Exception ex)
        {
            ErrHandler.WriteError(ex.Message);
            Response.Write("ארעה שגיאה");
        }
    }
}