using ASP.NET.MVC.Models;
using System;
using System.Web.Mvc;

namespace ASP.NET.MVC.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			var sessionCounterModel = GetSessionCounterModel();
			Session["SessionCounter"] = sessionCounterModel;

			var viewDataCounterModel = GetViewDataCounterModel();
			ViewData["ViewDataCounter"] = viewDataCounterModel;

			var cookie = Request.Cookies["CookieCounter"];
			if (string.IsNullOrWhiteSpace(cookie.Value))
			{
				Response.Cookies["CookieCounter"].Value = "0";
				Response.Cookies["CookieCounter"].Expires = DateTime.Now.AddHours(1);
			}

			return View();
		}

		public ActionResult CountUp(string key)
		{
			switch (key)
			{
				case "SessionCounter":
					var counterSessionModel = GetSessionCounterModel();
					counterSessionModel.Counter++;
					Session["SessionCounter"] = counterSessionModel;
					break;
				case "ViewDataCounter":
					var counterViewDataModel = GetViewDataCounterModel();
					counterViewDataModel.Counter++;
					ViewData["ViewDataCounter"] = counterViewDataModel;
					break;
				case "CookieCounter":
					var cookie = Request.Cookies["CookieCounter"];
					if (!string.IsNullOrWhiteSpace(cookie.Value))
					{
						int.TryParse(cookie.Value, out var i);
						i++;
						Response.Cookies["CookieCounter"].Value = i.ToString();
					}
					break;
			}


			//write your logic here to save the file on a disc            
			Response.Redirect("/Home");
			return View("Index");
		}

		private CounterModel GetSessionCounterModel()
		{
			var counterModel = Session["SessionCounter"];

			if (counterModel is null)
			{
				counterModel = new CounterModel
				{
					Title = "Session",
					Content = "Session state is similar to application state, except that it is scoped to the current browser session. If different users are using your application, each user session will have a different session state. In addition, if a user leaves your application and then returns later, the second user session will have a different session state from the first",
					Counter = 0,
					Key = "SessionCounter"
				};
				Session["SessionCounter"] = counterModel;
			}

			return (CounterModel)counterModel;
		}

		private CounterModel GetViewDataCounterModel()
		{
			var counterModel = ViewData["ViewDataCounter"];
			
			if (counterModel is null)
			{
				counterModel = new CounterModel
				{
					Title = "ViewData",
					Content = "ViewData is a container for data to be passed from the PageModel to the content page. ViewData is a dictionary of objects with a string-based key. ViewBag internally uses ViewData and as storage is the same, it lasts only the current HTTP request. It can only transfers data from Controller to View.",
					Counter = 0,
					Key = "ViewDataCounter"
				};
				ViewData["ViewDataCounter"] = counterModel;
			}

			return (CounterModel)counterModel;
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}