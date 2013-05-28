<%@ Page Title="" Language="C#" MasterPageFile="~/neframor.master" AutoEventWireup="true" CodeFile="NewIteam.aspx.cs" Inherits="NewIteam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<center><h1>עדכון פריט</h1></center>

<table dir="rtl"  style="width:100% ; margin-left:-10px">
    <tr>
        <td ><p>שם המוצר</p></td>
        <td><asp:TextBox ID="TBNameItem" runat="server" class="textcls"></asp:TextBox></td>
    </tr>
    <tr>
        <td ><p>מספר מק"ט</p></td>
        <td><asp:TextBox ID="TBsn" runat="server" class="textcls"></asp:TextBox></td>
    </tr>
        <tr>
        <td><p>קטגוריה</p></td>
        <td>
            <asp:DropDownList ID="DDCatgory" runat="server" >
                <asp:ListItem Text=" " />
                <asp:ListItem Text="סליל" />
                <asp:ListItem Text="תמיסה"/>
                <asp:ListItem Text="שקית עירוי" />
                <asp:ListItem Text="מחטים" />
                <asp:ListItem Text="כפפות" />
                <asp:ListItem Text="מתכלה" />
                <asp:ListItem Text="אחר" />
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="style1"><p>כמות באריזה</p></td>
        <td><asp:TextBox ID="TBNumInBox" runat="server" class="textcls"></asp:TextBox></td>
    </tr>
    <tr>
        <td><p>מחיר</p></td>
        <td><asp:TextBox ID="TBPrice" runat="server" class="textcls"></asp:TextBox></td>
    </tr>
    <tr>
        <td><p>שם הספק</p></td>
        <td><asp:DropDownList ID="DDvandor" runat="server" ></asp:DropDownList></td>
    </tr>
    <tr>
        <td></td>
        <td><asp:Button ID="Button1" runat="server" Text="הוסף" onclick="addIteam_Click" /></td>
    </tr>
</table>



</asp:Content>

