<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="AramaDemo1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Site İçi Arama</title>
    <style type="text/css">
        .auto-style1 {
            height: 30px;
        }
        .auto-style3 {
            height: 30px;
            width: 73px;
        }
        .auto-style4 {}
    </style>
</head>

<body style="margin:0px; padding:0px;">
            <div style="margin:0px; padding:0px; width:100%">
    <form id="form1" runat="server" style="margin:0px; padding:0px;">
        <table width="100%" style="margin-top:0px;">
            <tr>
                <td class="auto-style3" align="left" style="border-collapse: collapse; line-height: 25px; vertical-align: middle; text-align: left">
        <asp:Button ID="btnAra" runat="server" OnClick="btnAra_Click" Text="Ara" Font-Bold="False" Font-Size="14px" Height="30px" Width="60px" />
                </td>
                <td class="auto-style1">
        <asp:TextBox ID="txtAra" runat="server" Height="22px" style="margin-left: 0px" Width="165px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4" colspan="2">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=.;Initial Catalog=HaberPortali;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [Haberler]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 22px">
                    <asp:GridView ID="GridView1" runat="server" Width="100%">
                    </asp:GridView>
                    </td>
            </tr>
            <tr>
                <td colspan="2">
        <asp:Label ID="lblBilgi" runat="server" ForeColor="#333333" Font-Bold="False" Font-Size="14px" Font-Names="Verdana"></asp:Label>

                </td>
            </tr>
        </table>

    </form>
                </div>
</body>
</html>
