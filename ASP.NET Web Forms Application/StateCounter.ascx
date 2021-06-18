<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StateCounter.ascx.cs" Inherits="ASP.NET_Web_Forms_Application.StateCounter" %>
<div class="col-sm-6">
	<h2><asp:Literal ID="litTitle" runat="server"></asp:Literal></h2>
	<h1 class="display-3">
		<asp:Label ID="lblCounter" runat="server"></asp:Label>
	</h1>
	<p>
		<asp:Literal ID="litContent" runat="server"></asp:Literal>
	</p>
	<p>
		<asp:Button ID="btnClick" runat="server" Text="Count up" CssClass="btn btn-default" OnClick="btnClick_Click" />
	</p>
</div>
