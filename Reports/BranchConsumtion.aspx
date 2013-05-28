<%@ Page Title="" Language="C#" MasterPageFile="~/neframor.master" AutoEventWireup="true" CodeFile="BranchConsumtion.aspx.cs" Inherits="Reports_BranchConsumtion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

<center><h1>דוח צריכת מכון</h1></center>
<br /><br />

<asp:DropDownList ID="ddlBranches" runat="server"  AutoPostBack="True"  DataTextField="B_ID" DataValueField="B_ID" OnSelectedIndexChanged="ddlBranches_SelectedIndexChanged">
    </asp:DropDownList>


 <asp:BarChart ID="BarChart1" runat="server" ChartHeight="300" ChartWidth = "450"
    ChartType="Column" ChartTitleColor="#0E426C" Visible = "false"
    CategoryAxisLineColor="#D08AD9" ValueAxisLineColor="#D08AD9" BaseLineColor="#A156AB">
</asp:BarChart>

</asp:Content>

