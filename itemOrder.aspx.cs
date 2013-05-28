using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class itemOrder : System.Web.UI.Page
{

    string Vendor;
    string workerName;
    string password;
    string status;
    string OrderDate;
    string workerID;
    string Branch;
    int BID;
    DBservices dbs = new DBservices();
    List<Item> listOfItem = new List<Item>();
    int i = 0;
    string SN;
    int Quantity;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Vendor = (string)(Session["vendor"]);
            listOfItem = dbs.ReadItem(Vendor);


            TableRow HRow = new TableRow();

            TableCell Cell1 = new TableCell();
            Cell1.Text = "";
            HRow.Cells.Add(Cell1);

            TableCell Cell2 = new TableCell();
            Cell2.Text = "מקט";
            HRow.Cells.Add(Cell2);

            TableCell Cell3 = new TableCell();
            Cell3.Text = "שם";
            HRow.Cells.Add(Cell3);


            TableCell Cell4 = new TableCell();
            Cell4.Text = "קטגוריה";
            HRow.Cells.Add(Cell4);

            TableCell Cell5 = new TableCell();
            Cell5.Text = "כמות בקופסא";
            HRow.Cells.Add(Cell5);

            TableCell Cell6 = new TableCell();
            Cell6.Text = "כמות להזמנה";
            HRow.Cells.Add(Cell6);

            tb.Rows.Add(HRow);

            int runNum = 0;
            foreach (Item x in listOfItem)
            {
                TableRow tRow = new TableRow();

                TableCell RNCell = new TableCell();
                RNCell.Text = (runNum).ToString();
                tRow.Cells.Add(RNCell);


                TableCell NCell = new TableCell();
                NCell.Text = x.Name;
                tRow.Cells.Add(NCell);


                TableCell SNCell = new TableCell();
                SNCell.Text = x.Serialnumber;
                tRow.Cells.Add(SNCell);


                TableCell CCell = new TableCell();
                CCell.Text = x.Category;
                tRow.Cells.Add(CCell);


                TableCell NIBCell = new TableCell();
                NIBCell.Text = (x.Numinbox).ToString();
                tRow.Cells.Add(NIBCell);

                TableCell QuantCell = new TableCell();
                TextBox QuantItem = new TextBox();


                QuantItem.ID = "objBox" + (runNum++).ToString();

                QuantCell.Controls.Add(QuantItem);
                tRow.Cells.Add(QuantCell);

                tb.Rows.Add(tRow);

            }
        }
        catch (Exception ex)
        {
            ErrHandler.WriteError(ex.Message);
            Response.Write("ארעה שגיאה");
        }



    }


    protected void saveOrder(object sender, EventArgs e)
    {

        try
        {
            workerName = (string)(Session["Name"]);
            password = (string)(Session["Password"]);
            status = "open";
            OrderDate = (string)(Session["OrderDate"]);

            workerID = dbs.getWorkerID(workerName, password);
            Branch = dbs.getWorkerBranch(workerID);

            dbs.insertOrder(status, OrderDate, workerID, Branch);
            string poId = dbs.getPO_ID();

            int i = 0;
            foreach (Item x in listOfItem)
            {

                string ObjID = "objBox" + i;
                TextBox Box = (TextBox)tb.FindControl(ObjID);

                double num;
                bool isNum = double.TryParse(Box.Text, out  num);

                if (Box.Text != "" && Box.Text != Convert.ToString(0) && isNum == true)
                {
                    SN = x.Serialnumber;
                    Quantity = Convert.ToInt32(Box.Text);
                    dbs.insertItemOrder(poId, SN, Quantity);

                }
                i++;
            }

            tb.Visible = false;
            saveBTN.Visible = false;
            massageOrder.Visible = true;
        }
        catch (Exception ex)
        {
            ErrHandler.WriteError(ex.Message);
            Response.Write("ארעה שגיאה");
        }



    }





}