using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;
using FlightMobileApp.Models;
using System.Net.Http;
using System.Net;

namespace FlightMobileApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        Command com = new Command();
        Model model;
        public CommandController(Model m)
        {
            model = m;
        }

        [HttpPost]
        public HttpResponseMessage Post(JsonElement planJson)
        {
            try
            {
                string plan = planJson.ToString();
                dynamic jsonObj = JsonConvert.DeserializeObject(plan);
                //parsing the json
                com.Aileron = jsonObj["aileron"];
                com.Elevator = jsonObj["elevator"];
                com.Rudder = jsonObj["rudder"];
                com.Throttle = jsonObj["throttle"];
                model.SetElevator(com.Aileron.ToString());
                model.SetAileron(com.Aileron.ToString());
                model.SetThrottle(com.Aileron.ToString());
                model.SetRudder(com.Rudder.ToString());
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (TimeoutException)
            {
                return new HttpResponseMessage(HttpStatusCode.RequestTimeout);
            }

            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}