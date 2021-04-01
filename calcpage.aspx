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
            
            <asp:Label ID="lblWorldsGet" runat="server" Text="Initializing tiny worlds..."></asp:Label>
        </p>
        <p class="auto-style1">
            
            <asp:Label ID="lblWorldsInitialize" runat="server" Text="Tiny worlds complete. Initializing small worlds..." Visible="False"></asp:Label>
        </p>
        <p class="auto-style1">
            
            <asp:Label ID="lblSmWorldsInitialize" runat="server" Text="Small worlds complete. Initializing standard worlds..." Visible="False"></asp:Label>
        </p>
        <p class="auto-style1">
            
            <asp:Label ID="lblNormWorldsInitialize" runat="server" Text="Standard worlds complete. Initializing large worlds..." Visible="False"></asp:Label>
        </p>
        <p class="auto-style1">
            
            <asp:Label ID="lblLargeWorldsInitialize" runat="server" Text=" World initialization complete!" Visible="False"></asp:Label>
        </p>
        <p class="auto-style1">
            
            <asp:Label ID="lblNoWorlds" runat="server" Text="No worlds selected to generate! Go back?" Visible="False"></asp:Label>
        </p>
        <asp:Button ID="btnProceed" runat="server" Enabled="False" OnClick="btnProceed_Click" Text="PROCEED" />
    &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="BACK" />
    </form>
</body>
</html>
