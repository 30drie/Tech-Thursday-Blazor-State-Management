using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_Web_Forms_Application
{
	public partial class About : Page
	{

		protected void Page_Load(object sender, EventArgs e)
		{
			SetViewStateCounter();
			SetSessionCounter();
			SetApplicationCounter();
			SetCookieCounter();
		}

		private void SetViewStateCounter()
		{
			object o = ViewState[_Default.ViewStateCounting];
			int i = 0;
			if (o != null)
			{
				i = (int)o;
			}
			ViewStateCounter.Counter = i;
		}

		private void SetSessionCounter()
		{
			object o = Session[_Default.SessionCounting];
			int i = 0;
			if (o != null)
			{
				i = (int)o;
			}
			SessionStateCounter.Counter = i;
		}

		private void SetApplicationCounter()
		{
			object o = Application[_Default.ApplicationCounting];
			int i = 0;
			if (o != null)
			{
				i = (int)o;
			}
			ApplicationCounter.Counter = i;
		}

		private void SetCookieCounter()
		{
			string value = Request.Cookies[_Default.CookieCounting].Value;
			int.TryParse(value, out var i);
			CookieCounter.Counter = i;
		}

		protected void ViewStateCounter_CountingChangedEvent(object sender, CounterEventArgs e)
		{
			ViewState[_Default.ViewStateCounting] = e.Counter;
		}

		protected void SessionStateCounter_CountingChangedEvent(object sender, CounterEventArgs e)
		{
			Session[_Default.SessionCounting] = e.Counter;
		}

		protected void ApplicationCounter_CountingChangedEvent(object sender, CounterEventArgs e)
		{
			Application[_Default.ApplicationCounting] = e.Counter;
		}

		protected void CookieCounter_CountingChangedEvent(object sender, CounterEventArgs e)
		{
			Response.Cookies[_Default.CookieCounting].Value = e.Counter.ToString();
			Response.Cookies[_Default.CookieCounting].Expires = DateTime.Now.AddDays(1);

		}
	}
}