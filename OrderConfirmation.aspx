<%@ Page Title="" Language="C#" MasterPageFile="~/neframor.master" AutoEventWireup="true" CodeFile="OrderConfirmation.aspx.cs" Inherits="OrderConfirmation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .tb
     {
        float:right;
        
     }
    .img
     {
         float:right;
         height:30px;
         display:inline;
        
        
     }
  
     .style1
     {
         width: 102px;
     }
     .style2
     {
         width: 51px;
     }
     .style3
     {
         width: 45px;
     }
  
 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server" />
    <center><h1>אישור הזמנה</h1></center>
    <table dir="rtl" style="width:100% ">
    <tr id="TRorderNum" runat="server">
        <td class="style1"><p  >הכנס מספר משלוח</p></td>
        <td><asp:TextBox ID="TBDelivery"   runat="server" class="textcls"></asp:TextBox>
            <br /></td>
    </tr>
    </table>
    <table dir="rtl" style="width:100% ">
    <tr id="TRdate" runat="server">
       <td class="style2"> <p >תאריך</p></td>
       <td class="style3"><asp:ImageButton ID="ImgCalender" class="img"  runat="server" ImageUrl="images/Calendar.png"  /></td>
       <td><asp:TextBox ID="TBdate" class="textcls" runat="server"></asp:TextBox>
        </td>
       <td><asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TBdate"  PopupButtonID="ImgCalender" Format="dd.MM.yyyy" >
                </asp:CalendarExtender></td>
      
    </tr>
    </table>

  
   <center><div id="divOrder"  runat="server">
      </div></center>

    
     <table style="float:right; height: 105px; margin-top: 22px; margin-right: 100px;"><tr><td>
     <asp:Button ID="Approval" class="BTN" runat="server" Text="אישור שדות מסומנים" onclick="Approval_Click"   />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </td>
    <td>
    <asp:Button ID="Button1" runat="server"  class="BTN" Text="אישור כל ההזמנה" onclick="ChekAll_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </td>
    <td>
    <asp:Button ID="CancelBTN" runat="server"  class="BTN" Text="ביטול הזמנה" 
            onclick="CancelBTN_Click" />
    </td>
    </tr>

    <tr>
     <td>

    <asp:Button ID="BackToOrderlist" runat="server"  class="BTN" 
             Text="חזרה לרשימת הזמנות" onclick="BackToOrderlist_Click" 
             />
             </td>
             
             
             <td>
             
    <asp:Button ID="Barcode" runat="server"  class="BTN" style="width: 157px"
             Text="קריאת מברקוד" onclick="Barcode_Click" 
             />



    </td>
   <td> <asp:Label ID="LBapproval" runat="server" Text=""></asp:Label></td>
    <td><asp:Label ID="ans" runat="server" Text=""></asp:Label></td>
   </tr>
    <tr>
    <td>
        
            
          
    </td>


    </tr>
    </table>
    <center>
   
    <div id="TextArea">
    <textarea id="TextArea1" cols="30" rows="10" runat="server"></textarea>
    </div> </center>

    <center>
    <div id="PHDIV" style="width:70%; margin-bottom:30px">
    <asp:PlaceHolder ID="PHGV" runat="server">
    
    </asp:PlaceHolder>
    </div></center>
</asp:Content>

