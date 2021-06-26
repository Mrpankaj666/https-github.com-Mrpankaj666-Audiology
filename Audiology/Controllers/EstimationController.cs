using System;
using System.Threading.Tasks;
using Audiology.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Audiology.Controllers
{
   [Authorize]
    public class EstimationController : Controller
    {
        private readonly IEstimationService _estimationService;
        public EstimationController(IEstimationService estimationService)
        {
            this._estimationService = estimationService;
        }

        
        public IActionResult EstimationScreen(string userType)
        {
            ViewBag.UserType = userType;
            return View();
        }

        [HttpPost]
        
        public async Task<IActionResult> PrintToFile(float value)
        {
            try
            {
                Response.Headers.Add("fileName", "PrintToPaper.txt");
                return File( _estimationService.PrintToTextFile(value), "text/plain" );
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
