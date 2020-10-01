﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThemePark.Domains;
using ThemePark.Models;

namespace ThemePark.Repositories.Interfaces
{
    public interface IRideRepository
    {
        List<Ride> GetAllRides();

        Ride GetRideByID(Guid id);

        List<Ride> SearchRide(RideParam param);
    }
}
