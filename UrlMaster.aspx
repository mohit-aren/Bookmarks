<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UrlMaster.aspx.cs" Inherits="UrlMaster" %>
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
                <td class="initial" colspan="6" align="center">
                    <asp:Label ID="capInsur" runat="server" Width="557px"
                        Text="Urls Master" Font-Bold="True" 
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
                <td class="initial">
                      <asp:DropDownList ID="cmbCat" runat="server" AutoPostBack="true" onselectedindexchanged="cmbCat_SelectedIndexChanged"
                         ></asp:DropDownList>
                </td>
          </tr>
          <tr>
                <td class="initial">
                      <asp:Label ID="capUrl" runat="server" Text="Url:" Width="157px"></asp:Label>
                </td>
               <td>
                      <asp:TextBox ID="txtUrl" MaxLength="1000" runat="server" Width="653px"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="rfvUrl" runat="server" Display="Dynamic" ControlToValidate="txtUrl" ErrorMessage="Please enter Url."></asp:RequiredFieldValidator>
                     
                </td>
            </tr>
          <tr>
                <td class="initial">
                      <asp:Label ID="capRem" runat="server" Text="Url Remarks:" Width="157px"></asp:Label>
                </td>
               <td>
                      <asp:TextBox ID="txtRem" MaxLength="100" runat="server" Width="653px" Text="Reference"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="rfvRem" runat="server" Display="Dynamic" ControlToValidate="txtRem" ErrorMessage="Please enter Url Remarks."></asp:RequiredFieldValidator>
                     
                </td>
            </tr>
          <tr>
                <td class="initial">
                      <asp:Label ID="capNam" runat="server" Text="Url Added By:" Width="157px"></asp:Label>
                </td>
               <td>
                      <asp:TextBox ID="txtNam" MaxLength="100" runat="server" Width="653px" Text="User"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="rfvNam" runat="server" Display="Dynamic" ControlToValidate="txtNam" ErrorMessage="Please enter Url Added By."></asp:RequiredFieldValidator>
                     
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
                <td class="initial" colspan="6" align="left">
                    <asp:Label ID="lblUrls" runat="server" Width="857px"
                        Text="" Font-Bold="True" 
                        ForeColor="#0066FF"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="initial" colspan="4">
                    <asp:DataGrid ID="grdIns" runat="server">
                    <columns>
                             <asp:hyperlinkcolumn headertext="Edit Record"
                                datatextfield="URLID"
                                datanavigateurlformatstring="UrlMaster.aspx?ROWNUM={0}"
                                datanavigateurlfield="URLID" />
                          </columns>
                    </asp:DataGrid>
                </td>
           </tr>
             <tr>
              <td align="left" colspan="4">
                     <asp:Button ID="btnOpenAll" runat="server" Text="Open All Links" CausesValidation="false"
                         EnableTheming="True" onclick="btnOpenAll_Click" />
              </td>
             </tr>
        
        </table>    
    
    </div>
    <asp:HiddenField ID="hidPasswd" Value="0" runat="server" />    </form>
</body>
</html>
