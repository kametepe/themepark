using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ThemePark.Services.Interfaces;

namespace ThemePark.Controllers
{
    [RoutePrefix("api/Ride")]
    public class RideController : ApiController
    {
        private IRideService rideService;
        public RideController(IRideService rideSvc)
        {
            rideService = rideSvc;
        }

        [HttpGet]
        public IHttpActionResult GetAllRides()
        {
            return Ok(rideService.GetAllRides());
        }

    }
}
