<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASP.NET_Web_Forms_Application._Default" %>

<%@ Register Src="~/StateCounter.ascx" TagPrefix="uc1" TagName="StateCounter" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ShareValue's Tech Thursday on Blazor State Management</p>
        <%--<p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>--%>
    </div>

    <div class="row">
		<uc1:StateCounter runat="server" id="ViewStateCounter" Title="ViewState" OnCountingChangedEvent="ViewStateCounter_CountingChangedEvent" 
            Content="When the page is processed, the current state of the page and controls is hashed into a string and saved in the page as a hidden field, or multiple hidden fields if the amount of data stored in the ViewState property exceeds the specified value in the MaxPageStateFieldLength property. You can store values in view state as well."/>

		<uc1:StateCounter runat="server" id="SessionStateCounter" Title="Session" OnCountingChangedEvent="SessionStateCounter_CountingChangedEvent"
            Content="Session state is similar to application state, except that it is scoped to the current browser session. If different users are using your application, each user session will have a different session state. In addition, if a user leaves your application and then returns later, the second user session will have a different session state from the first."/>

		<uc1:StateCounter runat="server" id="ApplicationCounter" Title="Application" OnCountingChangedEvent="ApplicationCounter_CountingChangedEvent"
            Content="Application state is useful for storing information that needs to be maintained between server round trips and between requests for pages. Application state is stored in a key/value dictionary that is created during each request to a specific URL. You can add your application-specific information to this structure to store it between page requests."/>

        <uc1:StateCounter runat="server" id="CookieCounter" Title="Cookies" OnCountingChangedEvent="CookieCounter_CountingChangedEvent"
            Content="Cookies store data across requests. Because cookies are sent with every request, their size should be kept to a minimum. Ideally, only an identifier should be stored in a cookie with the data stored by the app. Most browsers restrict cookie size to 4096 bytes. Only a limited number of cookies are available for each domain."/>

    </div>
</asp:Content>
