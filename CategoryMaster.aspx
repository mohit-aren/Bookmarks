<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CategoryMaster.aspx.cs" Inherits="CategoryMaster" %>
<%@ Register Src="MenuCommon.ascx" TagName="MenuCommon" TagPrefix="RCMDEV" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <LINK href="zengarden-sample.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <RCMDEV:MenuCommon ID="topmenu" runat="server" />
    <table class="initial">
        <tr>
                <td class="initial">
                      <asp:Label ID="capPasswd" runat="server" Text="Admin Password:"  Width="157px"></asp:Label>
                </td>
               <td>
                      <asp:TextBox ID="txtPasswd" MaxLength="50" runat="server" TextMode="Password" Width="157px"></asp:TextBox>
                      <asp:Button ID="btnEnable" runat="server" Text="Enable Page" 
                         EnableTheming="True" onclick="btnEnable_Click" CausesValidation="false" />
                     <asp:Button ID="btnLogout" runat="server" Text="Logout Page" 
                         EnableTheming="True" CausesValidation="false" onclick="btnLogout_Click" />
                </td>
            </tr>
            <tr>
                <td class="initial" colspan="6" align="center">
                    <asp:Label ID="capInsur" runat="server" Width="557px"
                        Text="Category Master" Font-Bold="True" 
                        ForeColor="#FF0066"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="initial" colspan="6" align="center">
                    <asp:Label ID="lblMessg" runat="server" Width="557px"
                        Text="" Font-Bold="True" 
                        ForeColor="#0066FF"></asp:Label>
                </td>
            </tr>
          <tr>
                <td class="initial">
                      <asp:Label ID="capCat" runat="server" Text="Category:" Width="157px"></asp:Label>
                </td>
               <td>
                      <asp:TextBox ID="txtCat" MaxLength="50" runat="server" Width="157px"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="rfvCat" runat="server" Display="Dynamic" ControlToValidate="txtCat" ErrorMessage="Please enter Category."></asp:RequiredFieldValidator>
                     
                </td>
            </tr>
 
          <tr>
               <td align="left" colspan="4">
                     <asp:Button ID="btnAdd" runat="server" Text="Save details" 
                         EnableTheming="True" OnClick="btnAdd_Click" />
                     <asp:Button ID="btnUpdate" runat="server" Text="Update details" 
                         EnableTheming="True" onclick="btnUpdate_Click"  />
                     <asp:Button ID="btnNew" runat="server" Text="New Record" 
                         EnableTheming="True" onclick="btnNew_Click" CausesValidation="false" />
                     <asp:Button ID="btnDel" runat="server" Text="Delete details" 
                         EnableTheming="True" onclick="btnDel_Click"  />
                    
                </td>
            </tr>
            <tr>
                <td class="initial" colspan="4">
                    <asp:DataGrid ID="grdIns" runat="server">
                    <columns>
                             <asp:hyperlinkcolumn headertext="Edit Record"
                                datatextfield="CATID"
                                datanavigateurlformatstring="CategoryMaster.aspx?ROWNUM={0}"
                                datanavigateurlfield="CATID" />
                          </columns>
                    </asp:DataGrid>
                </td>
           </tr>
         
        </table>    
    
    </div>
    <asp:HiddenField ID="hidPasswd" Value="0" runat="server" />    </form>
</body>
</html>
