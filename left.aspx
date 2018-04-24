<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Left.aspx.cs" Inherits="Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <LINK href="zengarden-sample.css" rel="stylesheet" type="text/css">
</head>
<body>
        <script language="javascript" type="text/javascript">

            function Init() {
                NavPath();
            }



            function NavCalcDist() {
                top.frames['topp'].document.location.href = 'Header.aspx';
                top.frames['right'].document.location.href = 'Calc_dist.aspx';
            }

            function NavPathAlgo() {
                top.frames['topp'].document.location.href = 'Header.aspx';
                top.frames['right'].document.location.href = 'ShortestPathAlgo.aspx';
            }

            function NavPath() {
                top.frames['topp'].document.location.href = 'Header.aspx';
                top.frames['right'].document.location.href = 'ShortestPath.aspx';
            }

            function NavPathG() {
                top.frames['topp'].document.location.href = 'Header.aspx';
                top.frames['right'].document.location.href = 'ShortestPathG.aspx';
            }

            function NavUrlMaster() {
                top.frames['topp'].document.location.href = 'Header.aspx';
                top.frames['right'].document.location.href = 'UrlMaster.aspx';
            }

            function NavRoomPrice() {
                top.frames['topp'].document.location.href = 'Header.aspx';
                top.frames['right'].document.location.href = 'RoomPrice.aspx';
            }

            function NavRoomBook() {
                top.frames['topp'].document.location.href = 'Header.aspx';
                top.frames['right'].document.location.href = 'RoomBook.aspx';
            }


            function NavRoomRpt() {
                top.frames['topp'].document.location.href = 'Header.aspx';
                top.frames['right'].document.location.href = 'RoomRpt.aspx';
            }


            function NavUserP() {
                top.frames['topp'].document.location.href = 'Header.aspx';
                top.frames['right'].document.location.href = 'UserPasswd.aspx?MODE=Change';
            }

            function NavLogout() {
                top.frames['topp'].document.location.href = 'Header.aspx';
                top.frames['left'].document.location.href = 'Blank.aspx';
                top.frames['right'].document.location.href = 'login.aspx?Logout=Y';
            }
        
        </script>
    <form id="form1" runat="server">
    <div class="left">
        <table class="left">
            <!--tr>
                <td class="left">
                    <asp:HyperLink ID="lnkCalcDist" NavigateUrl="javascript:NavCalcDist();" runat="server">Generate Excel</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="left">
                    <asp:HyperLink ID="HyperLink1" NavigateUrl="javascript:NavPathAlgo();" runat="server">Shortest Path Algos</asp:HyperLink>
                </td>
            </tr>
           <tr>
                <td class="left">
                    <asp:HyperLink ID="lnkPath" NavigateUrl="javascript:NavPath();" runat="server">Find Shortest Path</asp:HyperLink>
                </td>
            </tr>
           <tr>
                <td class="left">
                    <asp:HyperLink ID="lnkPathG" NavigateUrl="javascript:NavPathG();" runat="server">Generic Shortest Path</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="left">
                    <asp:HyperLink ID="lnkRoomPrice" NavigateUrl="javascript:NavRoomPrice();" runat="server">Room Pricings</asp:HyperLink>
                </td>
            </tr>
           <tr>
                <td class="left">
                    <asp:HyperLink ID="HyperLink2" NavigateUrl="javascript:NavRoomBook();" runat="server">Room Book</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="left">
                    <asp:HyperLink ID="lnkUrlMaster" NavigateUrl="javascript:NavUrlMaster();" runat="server">Room Master</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="left">
                    <asp:HyperLink ID="lnkRoomRpt" NavigateUrl="javascript:NavRoomRpt();" runat="server">Room Report</asp:HyperLink>
                </td>
            </tr-->

        </table>
    </div>
    </form>
       <script language="javascript" type="text/javascript">

</body>
</html>
