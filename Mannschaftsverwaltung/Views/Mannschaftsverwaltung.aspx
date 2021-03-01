﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mannschaftsverwaltung.aspx.cs" Inherits="Mannschaftsverwaltung.Views.Mannschaftsverwaltung" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Mannschaftsverwaltung</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Mannschaftsverwaltung</h1>
            <h2>Mannschaften View</h2>
            <asp:DropDownList ID="selectTeam" runat="server" AutoPostBack="true" OnSelectedIndexChanged="selectTeam_SelectedIndexChanged">
            </asp:DropDownList> <br />
            <asp:Table ID="tblPersonen" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableCell BorderWidth="1" Font-Bold="true">Person-ID</asp:TableCell>
                    <asp:TableCell BorderWidth="1" Font-Bold="true">Name</asp:TableCell>
                    <asp:TableCell BorderWidth="1" Font-Bold="true">Geburtsdatum</asp:TableCell>
                    <asp:TableCell BorderWidth="1" Font-Bold="true">Mannschafts-ID</asp:TableCell>
                </asp:TableHeaderRow>
            </asp:Table> <br />
        </div>
        <div>
            <h2>Mannschaften Verwalten</h2>
            MID: <asp:TextBox ID="txtMID" runat="server" TextMode="Number"></asp:TextBox> <asp:Button runat="server" ID="btnDelete" Text="Del" BackColor="Red" BorderWidth="0" OnClick="btnDelete_Click"/> <br />
            NAME: <asp:TextBox runat="server" ID="txtNAME"></asp:TextBox>
            <asp:Button ID="btnAdd" runat="server" Text="Hinzufügen" BackColor="LightGreen" BorderWidth="0" OnClick="btnAdd_Click"/> <br />
            <h2>Personen Zuweisen</h2>
            <asp:DropDownList ID="listSpieler" runat="server"><asp:ListItem>Personen</asp:ListItem></asp:DropDownList> <asp:Button ID="btnZuweisen" runat="server" text="Hinzufügen" OnClick="btnZuweisen_Click" />

        </div>
    </form>
</body>
</html>