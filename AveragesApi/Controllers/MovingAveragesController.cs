using Microsoft.AspNetCore.Mvc;

namespace AveragesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovingAveragesController : Controller
    {
        private readonly IAveragesManager _mgr;
        public MovingAveragesController(IAveragesManager mgr)
        {
            _mgr = mgr;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var info = "Call Post to get Moving Average. Inputs: {window: 3, values: [0,1.0,2.0,3.0]}";
            return Ok(info);
        }

        [HttpPost]
        public IActionResult Post(AveragesData valuesToCompute)
        {
            if (valuesToCompute.Window < 1)
            {
                return UnprocessableEntity("Error: Invalid window value");
            }
            var result = _mgr.ComputeMovingAverage(valuesToCompute.Window, valuesToCompute.Values);

            return Ok(result);

        }

    }
}
