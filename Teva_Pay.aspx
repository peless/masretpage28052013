<%@ Page Title="" Language="C#" MasterPageFile="~/neframor.master" AutoEventWireup="true" CodeFile="Teva_Pay.aspx.cs" Inherits="Teva_Pay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<center><h1>דוח תשלומים טבע</h1></center>
<asp:Label ID="LBLsum" runat="server" style="float:right"></asp:Label>
<br /> <br />
<asp:GridView ID="GV_PayTBL" runat="server" class="CSSTableGenerator"></asp:GridView>
<br /> <br />
<asp:Label ID="LBLdis" runat="server" style="float:right"></asp:Label>

</asp:Content>

