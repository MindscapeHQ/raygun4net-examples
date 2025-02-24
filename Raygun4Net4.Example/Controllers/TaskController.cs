using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
  public class TaskController : CorrelationControllerBase
  {
    // GET
    public ActionResult SingleRunTaskCase()
    {
      ViewBag.Message = "Ran case: Task.Run(() => Thread1StartDoWork());";

      var task1 = Task.Run(() => Thread1StartDoWork());

      DoMaths();
      
      task1.Wait();

      return View("TaskCase");
    }
    
    public ActionResult SingleRunTaskGenericResultCase()
    {
      ViewBag.Message = "Ran case: Task.Run<int>(() => Thread1StartDoWorkWithResult());";

      var task1 = Task.Run(() => Thread1StartDoWorkWithResult());

      DoMaths();
      
      task1.Wait();

      ViewBag.Message += " :: The result was " + task1.Result;

      return View("TaskCase");
    }
    
    // GET
    public ActionResult SingleRunTaskCombinableCase()
    {
      ViewBag.Message = "Ran case: Task.Run(() => Thread1StartDoWork()).Wait();";

      Task.Run(() => Thread1StartDoWork()).Wait();

      DoMaths();
      
      return View("TaskCase");
    }
    
    // GET
    public ActionResult SingleRunTaskNoWaitCase()
    {
      ViewBag.Message = "Ran case: Task.Run(() => Thread1StartDoWork()); with no wait";

      Task.Run(() => Thread1StartDoWork());

      DoMaths();
      
      return View("TaskCase");
    }
    
    // GET
    public ActionResult SingleRunTaskWithContinuationCase()
    {
      ViewBag.Message = "Ran case: Task.Run(() => Thread1StartDoWork()).ContinueWith(t => Thread1StartDoWorkWithResult());";

      var task1 = Task
        .Run(() => Thread1StartDoWork())
        .ContinueWith(t => Thread1StartDoWorkWithResult());

      DoMaths();
      
      task1.Wait();

      return View("TaskCase");
    }
    
    // GET
    public ActionResult SingleRunTaskKitchenSinkCase()
    {
      ViewBag.Message = "Ran case: Task.Run(() => Thread1StartDoWork()).ContinueWith(t => Thread1StartDoWorkWithResult());";

      ThreadPool.QueueUserWorkItem(state =>
      {
        FireAndForgetMe();
      });
      
      var task1 = Task
        .Run(() => StarHere())
        .ContinueWith(t => FirstContinuation())
        .ContinueWith(t => SecondContinuation());

      DoMaths();
      
      task1.Wait();

      return View("TaskCase");
    }
    
    public ActionResult SingleNewTaskStartCase()
    {
      ViewBag.Message = "Ran case: new Task(Thread1StartDoWork).Start();";

      var task1 = new Task(Thread1StartDoWork);
      task1.Start();

      DoMaths();
      
      task1.Wait();

      return View("TaskCase");
    }
    
    //RunSynchronously
    public ActionResult SingleRunSynchronouslyTaskCase()
    {
      ViewBag.Message = "Ran case: new Task(Thread1StartDoWork).RunSynchronously();";

      new Task(Thread1StartDoWork).RunSynchronously();

      DoMaths();
      
      return View("TaskCase");
    }
  }
}