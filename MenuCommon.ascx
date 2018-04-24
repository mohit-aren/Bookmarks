<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuCommon.ascx.cs" Inherits="MenuCommon" %>
<script language="javascript" type="text/javascript">

     function NavMenu(aspxpage) {
         //top.frames['topp'].document.location.href = 'Header.aspx';
         //alert(aspxpage);
         top.frames['topp'].document.location.href = 'Header.aspx';
         top.frames['right'].document.location.href = aspxpage;
     }

        </script>

<asp:Panel ID="Panel1" runat="server" CssClass="initial">       
</asp:Panel><asp:Label ID="capManual" runat="server" Text="" CssClass="initial"></asp:Label>

