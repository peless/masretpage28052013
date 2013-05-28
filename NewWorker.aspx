<%@ Page Title="" Language="C#" MasterPageFile="~/neframor.master" AutoEventWireup="true" CodeFile="NewWorker.aspx.cs" Inherits="NewWorker" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 132px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<center><h1>יצירת עובד חדש</h1></center>
<br /><br />
<table dir="rtl" id="savePASS" style="width:100% ; margin-left:-10px">
    <tr>
        <td class="style1"><p>שם העובד</p></td>
        <td><asp:TextBox ID="TBworkerName" runat="server" class="textcls"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="style1"><p>מספר תעודת זהות</p></td>
        <td><asp:TextBox ID="TBworkerID" runat="server" class="textcls"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="style1"><p>סיסמא ראשונית</p></td>
        <td><asp:TextBox ID="TBworkerPass" runat="server" class="textcls"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="style1"><p>הגדרת תפקיד</p></td>
        <td>
            <asp:DropDownList ID="DDLworkerTitle" runat="server" >
                <asp:ListItem Text="worker" />
                <asp:ListItem Text="manager" />
                <asp:ListItem Text="economist" />
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td></td>
        <td><asp:Button ID="ButtonNewWorker" runat="server" Text="הוסף עובד" onclick="ButtonNewWorker_Click" /></td>
    </tr>
</table>




</asp:Content>

