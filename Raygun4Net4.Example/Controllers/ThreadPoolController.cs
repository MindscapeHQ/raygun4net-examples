using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ThreadPoolController : CorrelationControllerBase
    {
        public ActionResult ThreadPoolSingleQueueUserWorkItemCase()
        {
            ViewBag.Message = "Ran case ThreadPool.QueueUserWorkItem() with wait";

            var resetEvent = new ManualResetEvent(false);
            ThreadPool.QueueUserWorkItem(state =>
            {
                Thread1StartDoWork();
                resetEvent.Set();
            });

            DoMaths();

            resetEvent.WaitOne();

            return View("ThreadPoolCase");
        }

        public ActionResult ThreadPoolSingleQueueUserWorkItemNoWaitCase()
        {
            ViewBag.Message = "Ran case ThreadPool.QueueUserWorkItem() with no wait";

            ThreadPool.QueueUserWorkItem(state =>
            {
                Thread1StartDoWork();
            });

            DoMaths();

            return View("ThreadPoolCase");
        }
    }
}