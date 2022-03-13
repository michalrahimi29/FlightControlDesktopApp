using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FlightMobileApp.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlightMobileApp.Controllers
{
    [Route("api/[controller]")]
    public class ScreenshotController : Controller
    {
        Model model;

        public ScreenshotController(Model m)
        {
            model = m;
        }

        // GET: api/Screenshot
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                WebRequest request = WebRequest.Create("http://localhost:5000/screenshot");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    //read the content
                    MemoryStream ms = new MemoryStream();
                    stream.CopyTo(ms);
                    byte[] img = ms.ToArray();
                    return File(img, "image/png");
                };
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }
    }
}
