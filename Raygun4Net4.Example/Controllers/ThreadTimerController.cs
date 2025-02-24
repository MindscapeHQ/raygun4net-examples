using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ThreadTimerController : CorrelationControllerBase
    {
        public ActionResult ThreadTimerSingleInvokeCase()
        {
            ViewBag.Message = "Ran case new Timer(x => Thread1StartDoWork(), state, 0, Timeout.Infinite)";

            var counter = 0;
            var timer = new Timer(x =>
            {
                counter++;
                Thread1StartDoWork();
            }, null, 0, Timeout.Infinite);

            DoMaths();

            timer.Dispose();

            ViewBag.Message += $" :: Called {counter} times";

            return View("ThreadTimerCase");
        }

        public ActionResult ThreadTimerMultipleInvokeCase()
        {
            ViewBag.Message = "Ran case new Timer(x => Thread1StartDoWork(), state, 0, 50)";

            var counter = 0;
            var timer = new Timer(x =>
            {
                counter++;
                Thread1StartDoWork();
            }, null, 0, 50);

            DoMaths();

            timer.Dispose();

            ViewBag.Message += $" :: Called {counter} times";

            return View("ThreadTimerCase");
        }
    }
}