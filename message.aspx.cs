using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class message : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int runNum = 0;

        try
        {
            DropDownList DDL = sender as DropDownList;
            DBservices dbs = new DBservices();

            List<Message> ListMessage = new List<Message>();
            Table MessageTbl = new Table();

            ListMessage = dbs.ReadMessage();

            MessageTbl.Attributes.Add("class", "CSSTableGenerator");

            TableRow CRow = new TableRow();

            TableCell CHEAKCell = new TableCell();
            CHEAKCell.Text = "סימון למחיקה";
            CRow.Cells.Add(CHEAKCell);


            TableCell MessageCell = new TableCell();
            MessageCell.Text = "הודעות";
            CRow.Cells.Add(MessageCell);

            MessageTbl.Rows.Add(CRow);


            foreach (Message x in ListMessage)
            {

                TableRow tRow = new TableRow();

                TableCell ChekCell = new TableCell();
                CheckBox ChekItem = new CheckBox();
                ChekItem.ID = "ChekBox" + (runNum++).ToString();
                ChekCell.Controls.Add(ChekItem);
                tRow.Cells.Add(ChekCell);


                TableCell textCell = new TableCell();
                textCell.Text = x.Text_message;
                tRow.Cells.Add(textCell);


                MessageTbl.Rows.Add(tRow);

            }

            divmessage.Controls.Add(MessageTbl);
            Session["MessageTbl"] = MessageTbl;


        }
        catch (Exception ex)
        {
            ErrHandler.WriteError(ex.Message);
            Response.Write("ארעה שגיאה");
        }


    }


    protected void Delete_Click(object sender, EventArgs e)
    {
        try
        {

            int i = 0;
            Table TBL = new Table();
            TBL = (Table)(Session["MessageTbl"]);
            int num = TBL.Rows.Count;

            foreach (TableRow x in TBL.Rows)
            {
                if (((x.Cells[1].Text) != "הודעות") && (i < num - 1))
                {
                    CheckBox itemBox = divmessage.FindControl("ChekBox" + i.ToString()) as CheckBox;
                    i++;
                    if (itemBox.Checked == true)
                    {
                        DBservices.DeleteMessage(x.Cells[1].Text);
                    }
                }
            }
            Response.Redirect("message.aspx");




        }
        catch (Exception ex)
        {
            ErrHandler.WriteError(ex.Message);
            Response.Write("ארעה שגיאה");
        }


    }


    protected void AddMessage_Click(object sender, EventArgs e)
    {
        DBservices dbs = new DBservices();
        try
        {

            string text_message =TBnewMessage.Text;

            dbs.insertNewMessage(text_message);

            Response.Write("<script>alert('נוספה הודעה חדשה במערכת');</script>");
            Response.Redirect("message.aspx");
        }
        catch (Exception ex)
        {
            ErrHandler.WriteError(ex.Message);
            Response.Write("קיימת בעיה אנא נסה שנית מאוחר יותר");
        }
    }
}