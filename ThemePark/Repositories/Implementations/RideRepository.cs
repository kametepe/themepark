using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThemePark.Domains;
using ThemePark.Exceptions;
using ThemePark.Models;
using ThemePark.Repositories.Interfaces;

namespace ThemePark.Repositories.Implementations
{
    public class RideRepository : IRideRepository
    {

        public List<Ride> GetAllRides()
        {
            return GetStaticRides();
        }

        public Ride GetRideByID(Guid id)
        {
            Ride ride = GetStaticRides().Where(r => r.ID == id).FirstOrDefault();

            if(ride == null)
            {
                throw new NotFoundException(id.ToString());
            }

            return ride;
        }

        public List<Ride> SearchRide(RideParam param)
        {
            throw new NotImplementedException();
        }

        private List<Ride> GetStaticRides()
        {
            var rides = new List<Ride>();
            rides.Add(new Ride { ID = Guid.NewGuid(), Name = "RollerCoster", Description ="Train ride that speeds you arlong", ThrillFactor = 5, VomitFactor =3 });
            rides.Add(new Ride { ID = Guid.NewGuid(), Name = "Log Flume ", Description= "Boat ride with plenty of splashes", ThrillFactor = 3, VomitFactor = 2 });
            rides.Add(new Ride { ID = Guid.NewGuid(), Name = "Teacups", Description ="Spinning ride in a big tea-cup ",  ThrillFactor = 2, VomitFactor = 1 });
            rides.Add(new Ride { ID  = Guid.NewGuid(), Name = "Bumper cars", Description = "Bumper cars or dodgems is the generic name for a type of flat ride consisting of several small electrically powered cars which draw power from the floor and/or ceiling ", ThrillFactor = 2, VomitFactor = 0 });

            return rides;
        }
    }
}