using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Data;



public partial class OrderConfirmation : System.Web.UI.Page
{
    
    List<ItemInOrder> listItemInOrder = new List<ItemInOrder>();
    Table ItemInOrderTbl = new Table();
    int runNum = 0;
    private string I;
    string NumberOrder;
    int count=0;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        try
        {
            DropDownList DDL = sender as DropDownList;
            DBservices dbs = new DBservices();


            NameValueCollection coll = Request.QueryString;
            NumberOrder = coll["Po_id"];

            listItemInOrder = dbs.ReadItemInOrder(NumberOrder);


            ItemInOrderTbl.Attributes.Add("class", "CSSTableGenerator");
            

            TableRow CRow = new TableRow();

            string status = DBservices.CheckStatus(Convert.ToInt32(NumberOrder));

            if (status != "cancelled" && status != "close")
            {
                TableCell CHACKCell = new TableCell();
                CHACKCell.Text = "אישור קבלה";
                CRow.Cells.Add(CHACKCell);
            }
            if (status == "partially approved")
            {
                
                CancelBTN.Visible = false;
            }

            TableCell NOCell = new TableCell();
            NOCell.Text = "כמות בהזמנה";
            CRow.Cells.Add(NOCell);

            TableCell SnCell = new TableCell();
            SnCell.Text = "מספר מקט";
            CRow.Cells.Add(SnCell);

            ItemInOrderTbl.Rows.Add(CRow);



            foreach (ItemInOrder x in listItemInOrder)
            {

                TableRow tRow = new TableRow();

                TableCell ChekCell = new TableCell();
                CheckBox ChekItem = new CheckBox();
                ChekItem.ID = "ChekBox" + (runNum++).ToString();
                ChekCell.Controls.Add(ChekItem);
                tRow.Cells.Add(ChekCell);

                //check order status

                if (status=="cancelled" || status=="close")
                {
                    //if PO is closed/cancelled makes following fields not visible.
                    ChekItem.Visible = false;
                    CancelBTN.Visible = false;
                    Button1.Visible = false;
                    Approval.Visible = false;
                    //TBdate.Visible = false;
                    //TBDelivery.Visible = false;
                    TRorderNum.Visible = false;
                    TRdate.Visible = false;
                    //delets the checkbox cell
                    tRow.Cells.Remove(ChekCell);

                   
                }
                else
                {
                    ChekItem.Enabled = true;
                }

                if (x.Stat == "True")
                {
                    ChekItem.Checked = true;
                    ChekItem.Enabled = false;
                }


                TableCell QCell = new TableCell();
                QCell.Text = x.Quant;
                tRow.Cells.Add(QCell);

                TableCell SNCell = new TableCell();
                SNCell.Text = x.Serialnumber;
                tRow.Cells.Add(SNCell);


                count++;
                ItemInOrderTbl.Rows.Add(tRow);

            }


            Session["itemINoRDER"] = ItemInOrderTbl;

            divOrder.Controls.Add(ItemInOrderTbl);
            //GridView gv = new GridView();
            //gv.DataSource = ItemInOrderTbl;
            //gv.Attributes.Add("class", "hovertable");
            //gv.DataBind();
            //divOrder.Controls.Add(gv);
        }
        catch (Exception ex)
        {
            ErrHandler.WriteError(ex.Message);
            Response.Write("ארעה שגיאה");
        }
        

    }




    
    protected void Approval_Click(object sender, EventArgs e)
    {
        try
        {
            string NumberDelivery = TBDelivery.Text;


            int i = 0;
            int numcheck = 0;
            DBservices dbs = new DBservices();
            Table TBL = new Table();
            TBL = (Table)(Session["itemINoRDER"]);
            int num = TBL.Rows.Count;

            foreach (TableRow x in TBL.Rows)
            {
                if (TBL.Rows.GetRowIndex(x) != 0)
                {
                    if (i < num - 1)
                    {
                        CheckBox itemBox = divOrder.FindControl("ChekBox" + i.ToString()) as CheckBox;
                        i++;
                        if (itemBox.Checked == true)
                        {
                            numcheck++;
                            DBservices.AprroveItem(NumberOrder, x.Cells[2].Text);
                        }
                    }
                }
            }


            // string sup_date = ShippingDateCalendar.SelectedDate.ToShortDateString();
            string sup_date = TBdate.Text;

            if (numcheck == count)
                dbs.UpDateOrder(NumberOrder, "close", NumberDelivery, sup_date);
            else
                dbs.UpDateOrder(NumberOrder, "partially approved", NumberDelivery, sup_date);

            Response.Redirect("OrderList.aspx",false);
        }
        catch (Exception ex)
        {
            ErrHandler.WriteError(ex.Message);
            Response.Write("ארעה שגיאה");
        }
      
        
    }


    protected void ChekAll_Click(object sender, EventArgs e)
    {
        
            
        try
        {
            if (TBdate.Text != string.Empty || TBDelivery.Text != string.Empty)
                {
                int i = 0;
                Table TBL = new Table();
                TBL = (Table)(Session["itemINoRDER"]);
                int num = TBL.Rows.Count;
                    foreach (TableRow x in TBL.Rows)
                    {
                    if (i < num - 1)
                    {
                        CheckBox itemBox = divOrder.FindControl("ChekBox" + i.ToString()) as CheckBox;
                        itemBox.Checked = true;
                        i++;
                    }
                    }
                    DBservices dbs = new DBservices();
                    string NumberDelivery = TBDelivery.Text;
                    string sup_date = TBdate.Text;

                    dbs.UpDateOrder(NumberOrder, "close", NumberDelivery, sup_date);
                    Response.Redirect("OrderList.aspx", false);
                 }
           
            else
            {
                //Response.Write(@"<SCRIPT LANGUAGE=""JavaScript"">alert('שדה תאריך או שדה מספר הזמנה אינו מלא')</SCRIPT>");
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('שדה תאריך או שדה מספר הזמנה אינו מלא');", true);

            }
        }
        catch (Exception ex)
        {
            ErrHandler.WriteError(ex.Message);
            Response.Write("ארעה שגיאה");
        }
                }

    
    protected void  CancelBTN_Click(object sender, EventArgs e)
{
         try
        {
            //gets order num from querystring
            NameValueCollection coll = Request.QueryString;
            int po_id = Convert.ToInt32( coll["Po_id"]);

            DBservices.DeleteOrder(po_id);
            Response.Redirect("OrderList.aspx", false);
        }
        catch (Exception ex)
        {
            ErrHandler.WriteError(ex.Message);
            Response.Write("ארעה שגיאה");
        }
}

   
    protected void BackToOrderlist_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrderList.aspx", false);
    }
    protected void Barcode_Click(object sender, EventArgs e)
    {
        try
        {


            string[] allLines = TextArea1.InnerText.Split('\n');


            DataTable dt = DBservices.GetItemInfo();

            

            DataTable DSGV = new DataTable();
            DSGV.Columns.Add("SN");
            DSGV.Columns.Add("Name");
            DSGV.Columns.Add("Price");

            for (int i = 0; i < allLines.Length; i++)
            {
                allLines[i] = allLines[i].Replace("\r", string.Empty);
            }

            foreach (string str in allLines)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr[0].ToString() == str)
                    {
                        DSGV.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[4].ToString());
                       
                    }

                }
            }

            Table DStable = new Table();

            DStable.Attributes.Add("class", "CSSTableGenerator");

          

            TableRow TRtable = new TableRow();

            TableCell PriceCell = new TableCell();
            PriceCell.Text = "מחיר";
            TRtable.Cells.Add(PriceCell);


            TableCell NameCell = new TableCell();
            NameCell.Text = "שם";
            TRtable.Cells.Add(NameCell);

            TableCell SNcell = new TableCell();
            SNcell.Text = "מקט";
            TRtable.Cells.Add(SNcell);

            DStable.Rows.Add(TRtable);

            foreach (DataRow dr in DSGV.Rows)
            {
                TableRow tr = new TableRow();

                TableCell tcP = new TableCell();
                TableCell tcN = new TableCell();
                TableCell tcS = new TableCell();

                tcS.Text = dr[2].ToString();
                tcN.Text = dr[1].ToString();
                tcP.Text = dr[0].ToString();

                tr.Cells.Add(tcS);
                tr.Cells.Add(tcN);
                tr.Cells.Add(tcP);

                DStable.Rows.Add(tr);
               
            }




            PHGV.Controls.Add(DStable);

        }
        catch (Exception ex)
        {
            ErrHandler.WriteError(ex.Message);
            Response.Write("ארעה שגיאה");
        }


        
       


        
    

    }
}