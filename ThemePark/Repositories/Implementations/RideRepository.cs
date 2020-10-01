using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThemePark.Domains;
using ThemePark.Models;
using ThemePark.Repositories.Interfaces;

namespace ThemePark.Repositories.Implementations
{
    public class RideRepository : IRideRepository
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