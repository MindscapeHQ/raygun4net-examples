using System;
using System.Threading;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
  public abstract class CorrelationControllerBase : Controller
  {
    protected void Thread1StartDoWork()
    {
      Foo();
      Thread.Sleep(250);
    }
    
    protected int Thread1StartDoWorkWithResult()
    {
      Foo();
      Thread.Sleep(250);
      return new Random().Next();
    }
    
    protected void Thread2StartDoWork()
    {
      var thread3 = new Thread(Thread3StartDoWork);
      thread3.Start();
      
      Thread.Sleep(100);

      thread3.Join();
    }
    
    private void Thread3StartDoWork()
    {
      Foo();
      Thread.Sleep(300);
    }

    private void Foo()
    {
      Console.WriteLine("foo");
      DoMaths();
    }

    protected void DoMaths()
    {
      double seed = new Random().NextDouble();
      for (int i = 0; i < 100000; i++)
      {
        Math.Pow(seed, i);
      }
      
      Thread.Sleep(100);
    }
    
    protected void StarHere()
    {
      Foo();
      Thread.Sleep(250);
    }
    
    protected int FirstContinuation()
    {
      Foo();
      Thread.Sleep(250);
      return new Random().Next();
    }
    
    protected void SecondContinuation()
    {
      var thread = new Thread(FireAndWaitForMe);
      thread.Start();
      
      Thread.Sleep(100);

      thread.Join();
    }
    
    private void FireAndWaitForMe()
    {
      Foo();
      Thread.Sleep(300);
    }
    
    protected void FireAndForgetMe()
    {
      Foo();
      Thread.Sleep(250);
    }
    
    protected void CausesAnError()
    {
      var x = 0;
      var y = 2 / x;
    }
    
//    private void DoHttpCall()
//    {
//      var request = WebRequest.CreateHttp("https://www.google.com");
//      WebResponse response = request.GetResponse();
//      
//      Stream dataStream = response.GetResponseStream();
//      StreamReader reader = new StreamReader(dataStream);
//      string responseFromServer = reader.ReadToEnd();
//      
//      Console.WriteLine(responseFromServer);
//      
//      reader.Close();
//      response.Close();
//    }
  }
}