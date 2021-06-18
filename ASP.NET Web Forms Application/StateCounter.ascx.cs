using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_Web_Forms_Application
{
	public partial class StateCounter : System.Web.UI.UserControl
	{

		public event EventHandler<CounterEventArgs> CountingChangedEvent;

		public string Title { get; set; }

		public string Content { get; set; }

		public int Counter { get; set; }


		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				litTitle.Text = Title;
				litContent.Text = Content;
				lblCounter.Text = Counter.ToString();
			}
		}

		protected void btnClick_Click(object sender, EventArgs e)
		{
			Counter++;
			lblCounter.Text = Counter.ToString();
			CountingChangedEvent?.Invoke(this, new CounterEventArgs(Counter));
		}
	}

	public class CounterEventArgs : EventArgs
	{

		public CounterEventArgs(int counting)
		{
			Counter = counting;
		}

		public int Counter { get; set; }
	}
}