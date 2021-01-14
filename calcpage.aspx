<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="calcpage.aspx.cs" Inherits="gurpsmoontest.calcpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-weight: normal;
            font-style: normal;
            font-size: small;
        }
    </style>
</head>
<body style="font-weight: 700; font-style: italic; font-size: x-large">
    <form id="form1" runat="server">
        <div>
            Step 2: Calculation</div>
        <asp:Label ID="lblWorldsGot" runat="server" Text=" "></asp:Label>
        <p class="auto-style1">
            X
            <asp:Label ID="lblWorldsGet" runat="server" Text=" "></asp:Label>
        </p>
        <p class="auto-style1">
            X
            <asp:Label ID="lblWorldsInitialize" runat="server" Text=" "></asp:Label>
        </p>
        <asp:Button ID="btnProceed" runat="server" Enabled="False" OnClick="btnProceed_Click" Text="PROCEED" />
    </form>
</body>
</html>
