<%@ Page Title="" Language="C#" MasterPageFile="~/neframor.master" AutoEventWireup="true" CodeFile="itemOrder.aspx.cs" Inherits="itemOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<center><h1>טופס הזמנת רכש</h1></center>
<center><div id="massageOrder" runat="server" visible="false" style="width:400px; height:200px"><p style="text-align:center;  margin-top:20%">ההזמנה בוצעה בהצלחה &nbsp;&nbsp;&nbsp;&nbsp;<img src="images/v.png" /></p></div></center>
<center><div id="TBLdiv" runat="server" style="overflow:auto; height:300px; width:100%;">
<asp:Table ID="tb" runat="server" class="CSSTableGenerator" dir="rtl" style="width:100%">
    </asp:Table>
</div></center>
<br />
<center><asp:Button ID="saveBTN" class="BTN" runat="server" Text="שמור" OnClick="saveOrder" /></center>
</asp:Content>

