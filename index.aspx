<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bookmarking System</title>
</head>
<frameset name="masterframe" rows="90,*" frameborder="NO" border="0" framespacing="0">
    <frame name="topp" src="Header.aspx" scrolling="no">
    <frameset cols="60,*" frameborder="NO" border="0" framespacing="0">
       <frame name="left" src="left.aspx" scrolling="yes">
       <frame name="right" src="CategoryMaster.aspx">
    </frameset>
</frameset>
</html>
