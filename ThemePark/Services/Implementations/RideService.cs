using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThemePark.Domains;
using ThemePark.Models;
using ThemePark.Services.Interfaces;

namespace ThemePark.Services.Implementations
{
    public class RideService : IRideService
    {
        public List<Ride> GetAllRides()
        {
            throw new NotImplementedException();
        }

        public Ride GetRideByID(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Ride> SearchRide(RideParam param)
        {
            throw new NotImplementedException();
        }
    }
}