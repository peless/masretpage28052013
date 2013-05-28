<%@ Page Title="" Language="C#" MasterPageFile="~/neframor.master" AutoEventWireup="true" CodeFile="NewPatient.aspx.cs" Inherits="NewPatient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 117px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<center><h1>יצירת מטופל חדש</h1></center>

<table dir="rtl" id="savePASS" style="width:100% ; margin-left:-10px">
   <tr>
        <td><h3>פרטי מטופל: </h3></td>
   </tr>
    <tr>
        <td class="style1"><p>שם המטופל</p></td>
        <td><asp:TextBox ID="TBPatientName" runat="server" class="textcls"></asp:TextBox></td>
    </tr>
        <tr>
        <td class="style1"><p>שם קופת החולים</p></td>
        <td>
            <asp:DropDownList ID="DDPatientKupah" runat="server" >
                <asp:ListItem Text=" " />
                <asp:ListItem Text="מכבי" />
                <asp:ListItem Text="כללית" />
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="style1"><p>מספר מטופל</p></td>
        <td><asp:TextBox ID="TBPatientNum" runat="server" class="textcls"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="style1"><p>מספר ת.ז</p></td>
        <td><asp:TextBox ID="TBPatientId" runat="server" class="textcls"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="style1"><p>שימוש בצנטר</p></td>
        <td>
            <asp:DropDownList ID="DDPatientZantar" runat="server" >
                <asp:ListItem Text=" " />
                <asp:ListItem Text="כן" />
                <asp:ListItem Text="לא" />
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td><h3> סט מטופל : </h3></td>
    </tr>
    <tr>
        <td class="style1"><p>מחט </p></td>
        <td><asp:DropDownList ID="DDneedle" runat="server" ></asp:DropDownList></td>
    </tr>
    <tr>
        <td class="style1"><p>סליל </p></td>
        <td><asp:DropDownList ID="DDcoil" runat="server" ></asp:DropDownList></td>
    </tr>
    <tr>
        <td class="style1"><p>שקיות עירוי </p></td>
        <td><asp:DropDownList ID="DDinfusionBag" runat="server" ></asp:DropDownList></td>
    </tr>
    <tr>
        <td class="style1"><p>תמיסות </p></td>
        <td><asp:DropDownList ID="DDsolutions" runat="server" ></asp:DropDownList></td>
    </tr>

    <tr>
        <td class="style1"></td>
        <td><asp:Button ID="ButtonNewPatient" runat="server" Text="שמור" onclick="ButtonNewPatient_Click" 
            /></td>
    </tr>
</table>

</asp:Content>

