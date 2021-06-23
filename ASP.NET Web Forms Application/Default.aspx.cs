using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_Web_Forms_Application
{
	public partial class _Default : Page
	{
		public const string ViewStateCounting = "ViewStateCounting";
		public const string SessionCounting = "SessionCounting";
		public const string ApplicationCounting = "ApplicationCounting";
		public const string CookieCounting = "CookieCounting";


		protected void Page_Load(object sender, EventArgs e)
		{
			SetViewStateCounter();
			SetSessionCounter();
			SetApplicationCounter();
			SetCookieCounter();
		}

		private void SetViewStateCounter()
		{
			object o = ViewState[ViewStateCounting];
			int i = 0;
			if (o != null)
			{
				i = (int)o;
			}
			ViewStateCounter.Counter = i;
		}

		private void SetSessionCounter()
		{
			object o = Session[SessionCounting];
			int i = 0;
			if (o != null)
			{
				i = (int)o;
			}
			SessionStateCounter.Counter = i;
		}

		private void SetApplicationCounter()
		{
			object o = Application[ApplicationCounting];
			int i = 0;
			if (o != null)
			{
				i = (int)o;
			}
			ApplicationCounter.Counter = i;
		}

		private void SetCookieCounter()
		{
			string value = Request.Cookies[CookieCounting].Value;
			int.TryParse(value, out var i);
			CookieCounter.Counter = i;
		}

		protected void ViewStateCounter_CountingChangedEvent(object sender, CounterEventArgs e)
		{
			ViewState[ViewStateCounting] = e.Counter;
		}

		protected void SessionStateCounter_CountingChangedEvent(object sender, CounterEventArgs e)
		{
			Session[SessionCounting] = e.Counter;
		}

		protected void ApplicationCounter_CountingChangedEvent(object sender, CounterEventArgs e)
		{
			Application[ApplicationCounting] = e.Counter;
		}

		protected void CookieCounter_CountingChangedEvent(object sender, CounterEventArgs e)
		{
			Response.Cookies[CookieCounting].Value = e.Counter.ToString();
			Response.Cookies[CookieCounting].Expires = DateTime.Now.AddHours(1);
			
		}
	}
}