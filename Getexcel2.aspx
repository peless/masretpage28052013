<%@ Page Title="" Language="C#" MasterPageFile="~/neframor.master" AutoEventWireup="true" CodeFile="Getexcel2.aspx.cs" Inherits="Getexcel2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<style type="text/css"> 




</style>
    



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <center><h1>צירוף חשבונית</h1></center>

    
    
        <p style="float:right; margin-right:10px">בחר קובץ להעלאה</p>
        <br />
        <div id="buttons" style="float:right ;">
        <asp:FileUpload id="FileUpload1" CssClass="hi"                
            runat="server" >
        </asp:FileUpload>

      

        <br />
       <center><table>

    <td> <asp:Button id="UploadButton" CssClass="BTN" 
            Text="העלה קובץ"
            OnClick="UploadButton_Click"
            runat="server" >
        </asp:Button></td>


        <td><asp:Button id="Report" CssClass="BTN" 
            Text="צור דוח תשלום"
            OnClick="CreateReport"
            runat="server"  >
        </asp:Button></td>   
        
       </tr></table></center>

        <br />

        <asp:Label id="UploadStatusLabel" runat="server">
        </asp:Label>  
        
        <br />

        <asp:Label id="invinsertlbl" runat="server">
        </asp:Label>   
 
        <br />
        </div>
    <asp:PlaceHolder ID="PH" runat="server">
        <asp:GridView ID="GridView1" runat="server" class="CSSTableGenerator">
        </asp:GridView>
    </asp:PlaceHolder>

</asp:Content>


