<%@ Page Title="" Language="C#" MasterPageFile="~/neframor.master" AutoEventWireup="true" CodeFile="message.aspx.cs" Inherits="message" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


    <style type="text/css">
        .style1
        {
            width: 149px;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<center><h1>הודעות</h1></center> 

<center><div id="divmessage" style="width:90%; overflow:scroll; height:180px;  overflow:auto" runat="server"></div></center>

<table dir="rtl" style="width:100% ">
<tr>
    <td class="style1" ><br /><asp:Button ID="Delete" runat="server" Text="מחיקה " onclick="Delete_Click" /></td>
    <td></td>
</tr>
<tr>
    <td class="style1"><p>כתיבת הודעה חדשה: </p></td>
    <td><asp:TextBox ID="TBnewMessage" runat="server" style="height:100px; width:400px"></asp:TextBox></td>
</tr>
<tr>
    <td></td>
    <td ><asp:Button ID="newmessage" runat="server" Text="הוסף" onclick="AddMessage_Click" /></td>
</tr>

</table>
</asp:Content>


