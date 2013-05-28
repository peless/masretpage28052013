<%@ Page Title="" Language="C#" MasterPageFile="~/Masterlogin.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="loginnew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div id="box">
<div class="elements">
<div class="avatar"></div>
<form action="" method="post">
<asp:TextBox ID="TBusername" runat="server" class="username" ></asp:TextBox>
<asp:TextBox ID="TBpassword" runat="server" class="password" TextMode="Password" ></asp:TextBox><br />

<div class="checkbox">
<input id="check" name="checkbox" type="checkbox" value="1" style="display:none" />
<label for="check">Remember? </label>
</div>
<div class="remember">Remember? </div>

<asp:Button ID="buttenIN" class="BTN" runat="server" Text="login" onclick="buttenIN_Click"  /><br />
      <asp:Label ID="ans" runat="server" Text=""></asp:Label>
</form>
</div>
<asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Forgot your password?</asp:LinkButton>
</div>



</asp:Content>

