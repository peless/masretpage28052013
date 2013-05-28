<%@ Page Title="" Language="C#" MasterPageFile="~/neframor.master" AutoEventWireup="true" CodeFile="newPASS.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 165px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<center><h1>עדכון סיסמא</h1></center>
<br /><br />
<table dir="rtl" id="savePASS" style="width:100% ; margin-left:-10px">
    <tr>
        <td class="style1"><p>הכנס מספר תעודת זהות</p></td>
        <td><asp:TextBox ID="TBIDworker" runat="server" class="textcls"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="style1"><p>הכנס סיסמא חדשה</p></td>
        <td><asp:TextBox ID="TBPASSworker" runat="server" class="textcls" > </asp:TextBox></td>
    </tr>
        <tr>
        <td></td>
        <td><asp:Button ID="Button1" runat="server" Text="שמור סיסמא" onclick="Button1_Click" /></td>
    </tr>
</table>



</asp:Content>

