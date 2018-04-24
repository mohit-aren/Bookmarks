<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Src="MenuCommon.ascx" TagName="MenuCommon" TagPrefix="RCMDEV" %>

<!DOCTYPE html>

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
                
                <td colspan="4" class="initial">
                    <asp:Image ID="Image1" runat="server" ImageUrl="./Bookmark1.jpg" />
                </td>
             </tr>
            
          </table> 
    </div>
    </form>
</body>
</html>
