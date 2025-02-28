using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ThreadStartController : CorrelationControllerBase
    {
        public ActionResult ThreadStartKitchenSinkCase()
        {
            ViewBag.Message = "Start multiple threads using new Thread().Start() with one thread starting a child thread and waiting for all to complete.";

            var thread1 = new Thread(Thread1StartDoWork);
            thread1.Start();

            DoMaths();

            var thread2 = new Thread(Thread2StartDoWork);
            thread2.Start();

            Thread.Sleep(100);

            thread1.Join();
            thread2.Join();

            return View("ThreadStartCase");
        }
    }
}