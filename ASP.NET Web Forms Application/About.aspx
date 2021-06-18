<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="ASP.NET_Web_Forms_Application.About" %>

<%@ Register Src="~/StateCounter.ascx" TagPrefix="uc1" TagName="StateCounter" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<h2><%: Title %>.</h2>


	<div class="row">
		<uc1:StateCounter runat="server" ID="ViewStateCounter" Title="ViewState" OnCountingChangedEvent="ViewStateCounter_CountingChangedEvent"
			Content="When the page is processed, the current state of the page and controls is hashed into a string and saved in the page as a hidden field, or multiple hidden fields if the amount of data stored in the ViewState property exceeds the specified value in the MaxPageStateFieldLength property. You can store values in view state as well." />

		<uc1:StateCounter runat="server" ID="SessionStateCounter" Title="Session" OnCountingChangedEvent="SessionStateCounter_CountingChangedEvent"
			Content="Session state is similar to application state, except that it is scoped to the current browser session. If different users are using your application, each user session will have a different session state. In addition, if a user leaves your application and then returns later, the second user session will have a different session state from the first." />

		<uc1:StateCounter runat="server" ID="ApplicationCounter" Title="Application" OnCountingChangedEvent="ApplicationCounter_CountingChangedEvent"
			Content="Application state is useful for storing information that needs to be maintained between server round trips and between requests for pages. Application state is stored in a key/value dictionary that is created during each request to a specific URL. You can add your application-specific information to this structure to store it between page requests." />

		<uc1:StateCounter runat="server" ID="CookieCounter" Title="Cookies" OnCountingChangedEvent="CookieCounter_CountingChangedEvent"
			Content="Application state is useful for storing information that needs to be maintained between server round trips and between requests for pages. Application state is stored in a key/value dictionary that is created during each request to a specific URL. You can add your application-specific information to this structure to store it between page requests." />

	</div>


</asp:Content>
