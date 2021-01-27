<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormConsume.aspx.cs" Inherits="Consume_Services.FormConsume" %>


<!DOCTYPE html >
 
<html xmlns="http://www.w3.org/1999/xhtml">
   <head id="Head1" runat="server">
      <title>Getting Data Agreement from WebService</title>
       <style type="text/css">
           .auto-style1 {
               height: 34px;
           }
       </style>
   </head>
   <body>
      <form id="form1" runat="server">
         <div>
            <table>
               <tr>
                  <td class="auto-style1">
                      Part NO <b>:<asp:TextBox ID="txtPartNo" runat="server"></asp:TextBox>
                      </b>
                      <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" Text="requireQty :"></asp:Label>
&nbsp;<asp:TextBox ID="txtQty" runat="server"></asp:TextBox>
&nbsp;<asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" Text="WorkOrderID :"></asp:Label>
                      <asp:TextBox ID="txtWo" runat="server"></asp:TextBox>
                      <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Medium" Text="ProductID :"></asp:Label>
                      <asp:TextBox ID="txtProductId" runat="server"></asp:TextBox>
&nbsp;<asp:DropDownList ID="DropDownList1" runat="server">
                          <asp:ListItem>Reserve IMEI</asp:ListItem>
                          <asp:ListItem>Reserve  MAC</asp:ListItem>
                          <asp:ListItem>Reserve  KEYBOX</asp:ListItem>
                          <asp:ListItem>Reserve  ATTKEY</asp:ListItem>
                          <asp:ListItem>Get Single IMEI</asp:ListItem>
                          <asp:ListItem>Get Single MAC</asp:ListItem>
                          <asp:ListItem>Get Single KEYBOX</asp:ListItem>
                          <asp:ListItem>Get Single ATTKEY</asp:ListItem>
                          <asp:ListItem>Get IMEI by WO</asp:ListItem>
                          <asp:ListItem>Get MAC by Wo</asp:ListItem>
                          <asp:ListItem>Get KEYBOX by WO</asp:ListItem>
                          <asp:ListItem>Get ATTKEY by WO</asp:ListItem>
                      </asp:DropDownList>
                      <asp:Button ID="btnGetKey" runat="server" Text="Get Key" OnClick="Button1_Click" style="height: 26px" />
                  </td>
                  
               </tr>
            </table>
         </div>
         <div>
         </div>
          <asp:GridView ID="GridView1" runat="server">
              <RowStyle BackColor="#EFF3FB" />
               <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
               <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
               <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
               <AlternatingRowStyle BackColor="White" />
          </asp:GridView>
      </form>
   </body>
</html>

