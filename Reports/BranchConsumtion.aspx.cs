using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Reports_BranchConsumtion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                DataTable dt = new DataTable();

                dt = DBservices.GetBranches();

                ddlBranches.DataSource = dt;
                ddlBranches.DataTextField = "Name";
                ddlBranches.DataValueField = "B_ID";
                ddlBranches.DataBind();
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                Response.Write("ארעה שגיאה");
            }
        }
    }

    protected void ddlBranches_SelectedIndexChanged(object sender, EventArgs e)
    {
        string query = string.Format("SELECT dbo.PO.B_ID AS [Branch num], SUM(dbo.Item.Price) AS Total FROM dbo.ITEM_PO INNER JOIN dbo.PO ON dbo.ITEM_PO.PO_ID = dbo.PO.PO_ID INNER JOIN dbo.Item ON dbo.ITEM_PO.SN = dbo.Item.SN GROUP BY dbo.PO.B_ID");
        DataTable dt = DBservices.GetBranchesData(query);

        string[] x = new string[dt.Rows.Count];
        decimal[] y = new decimal[dt.Rows.Count];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            x[i] = dt.Rows[i][0].ToString();
            y[i] = Convert.ToInt32(dt.Rows[i][1]);
        }
        BarChart1.Series.Add(new AjaxControlToolkit.BarChartSeries { Data = y });
        BarChart1.CategoriesAxis = string.Join(",", x);
        BarChart1.ChartTitle = string.Format("{0} דוח צריכת מכון-מכונים", ddlBranches.SelectedItem.Value);
        if (x.Length > 3)
        {
            BarChart1.ChartWidth = (x.Length * 100).ToString();
        }
        BarChart1.Visible = ddlBranches.SelectedItem.Value != "";
    }
}