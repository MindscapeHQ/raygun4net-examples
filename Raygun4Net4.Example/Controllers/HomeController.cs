using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using Mindscape.Raygun4Net;

namespace WebApplication1.Controllers
{
    public class HomeController : CorrelationControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UnhandledNullReference()
        {
            string x = null;

            var message = $"The string is {x.Length} characters long";

            return View("Index");
        }

        public ActionResult HandledNullReferenceSync()
        {
            try
            {
                string x = null;
                var message = $"The string is {x.Length} characters long";
            }
            catch (Exception e)
            {
                new RaygunClient().Send(e);
            }

            return View("Index");
        }

        public ActionResult HandledNullReferenceAsync()
        {
            try
            {
                string x = null;
                var message = $"The string is {x.Length} characters long";
            }
            catch (Exception e)
            {
                new RaygunClient().SendInBackground(e);
            }

            return View("Index");
        }

        public ActionResult UnhandledExceptionOnSeparateThread()
        {
            var task1 = Task.Run(() => CausesAnError());

            DoMaths();

            task1.Wait();

            return View("Index");
        }

        public ActionResult UnhandledExceptionWithInnerError()
        {
            DoMaths();

            try
            {
                CausesAnError();
            }
            catch (Exception e)
            {
                throw new ApplicationException("Oh noes!", e);
            }

            return View("Index");
        }

        public ActionResult HandledExceptionWithInnerError()
        {
            try
            {
                DoMaths();

                try
                {
                    CausesAnError();
                }
                catch (Exception e)
                {
                    throw new ApplicationException("Oh noes!", e);
                }
            }
            catch (Exception e)
            {
                new RaygunClient().Send(e);
            }

            return View("Index");
        }
    }
}