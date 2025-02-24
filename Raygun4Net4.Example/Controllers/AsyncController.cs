using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
  public class AsyncController : CorrelationControllerBase
  {
    // GET
    public async Task<ActionResult> BasicAsyncAwaitCase()
    {
      var result = await Task.Run(() => Thread1StartDoWorkWithResult());

      Response.StatusCode = 202;
      
      return View("AsyncCase", result);
    }
    
    // GET
    public async Task<ActionResult> MultipleAsyncAwaitCase()
    {
      var result = await Task.Run(() => Thread1StartDoWorkWithResult());

      DoMaths();
      
      await Task.Run(() => StarHere());
      
      Response.StatusCode = 202;
      
      return View("AsyncCase", result);
    }
  }
}