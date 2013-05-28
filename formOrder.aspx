<%@ Page Title="" Language="C#" MasterPageFile="~/neframor.master" AutoEventWireup="true" CodeFile="formOrder.aspx.cs" Inherits="formOrder" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <style type="text/css">
    
    .img
     {
        
         height:30px;
       
     }
    
</style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<center><h1>יצירת הזמנת רכש</h1></center>
<br /><br />
<table  dir="rtl" style="width:100% ; margin-left:-10px">

<tr>

<td style="width:100%">
    

 <p style="display:inline"> בחר ספק</p>&nbsp;&nbsp;&nbsp;&nbsp;

 <div id="VendorDDL" runat="server"  style="display:inline"></div>
    

  <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
    <table><tr>
    <td>
     <br /><br /><p>בחר תאריך הזמנה</p></td><td></td><td>
    <asp:ImageButton ID="ImgCalender" class="img" runat="server" ImageUrl="images/Calendar.png" />
    </td><td>
    <asp:TextBox ID="TBdate" runat="server" class="textcls"></asp:TextBox>
    </td></tr></table>
    <asp:CalendarExtender ID="OrderDateCalendar" runat="server" TargetControlID="TBdate"  PopupButtonID="ImgCalender" Format="dd.MM.yyyy" >
    </asp:CalendarExtender>
 
   
</td>
    
</tr>
<tr><td><asp:Button ID="BTN"  class="BTN" runat="server" Text="ליצירת טופס הזמנה" OnClick="goToitemOrder"  /></td></tr>


</table>
  
</asp:Content>


