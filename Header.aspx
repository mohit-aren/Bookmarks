<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Header.aspx.cs" Inherits="Header" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <LINK href="zengarden-sample.css" rel="stylesheet" type="text/css">
    <style type="text/css">
        .auto-style1 {
            width: 743px;
        }
    </style>
</head>
<body>
        <script language="javascript" type="text/javascript">

            function NavBuySell() {
                top.frames['topp'].document.location.href = 'Header.aspx';
                top.frames['right'].document.location.href = 'Register.aspx';
            }


            function NavUser() {
                top.frames['topp'].document.location.href = 'Header.aspx';
                top.frames['right'].document.location.href = 'CreateLogin.aspx?MODE=Add';
            }
            
            function NavUserP() {
                top.frames['topp'].document.location.href = 'Header.aspx';
                top.frames['right'].document.location.href = 'CreateLogin.aspx?MODE=Change';
            }

            function NavLogout() {
                //top.frames['left'].document.location.href = 'Blank.aspx';
                //top.frames['topp'].document.location.href = 'Blank.aspx';
                //top.frames['right'].document.location.href = 'Default.aspx?Logout=Y';

                window.parent.location.assign('Default.aspx?Logout=Y');
            }

            function NavRpt() {
                top.frames['topp'].document.location.href = 'Header.aspx';
                top.frames['right'].document.location.href = 'Reports.aspx';
            }

        </script>
    <form id="form1" runat="server">
    <div class="header">

        <table class="header">
            <tr>
                <!--td>
                    <asp:Image ID="ImgSocialTrade" runat="server" ImageUrl="~/images/logo.png" Height="77px" 
                        Width="195px" />
                </td-->
                <td class="auto-style1" align="center">
                    
                     <asp:Label ID="capProjName" runat="server" Font-Bold="True" Font-Italic="True" 
                        Font-Size="40px">Project Name</asp:Label>
                </td>
                 <!--td>
                     <asp:HyperLink ID="Reports" NavigateUrl="javascript:NavRpt();" 
                         runat="server" ImageUrl="~/Reports.GIF">Reports</asp:HyperLink>
                </td-->
                <!--td>
                     <asp:HyperLink ID="HyperLink1"  NavigateUrl="javascript:NavUser();" 
                         runat="server" ImageUrl="~/AddUser.GIF" ToolTip="Add User">Add User</asp:HyperLink>
                </td>
                <td>
                     <asp:HyperLink ID="ChgPasswd"  NavigateUrl="javascript:NavUserP();"
                         runat="server" ImageUrl="~/ChgPasswd.GIF" ToolTip="Change Password">Change Password</asp:HyperLink>
                </td>
                <td>
                     <asp:HyperLink ID="Logout" NavigateUrl="javascript:NavLogout();" runat="server" 
                         ImageUrl="~/LogOut.GIF" ToolTip="Sign Out">Sign Out</asp:HyperLink>
                </td-->
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
