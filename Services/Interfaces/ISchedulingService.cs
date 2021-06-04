using HomeDoc.Entities;
using HomeDoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeDoc.Services.Interfaces
{
    public interface ISchedulingService
    {
        List<Scheduling> GetScheduling(int? idPacient);
        int AddScheduling(SchedulingRequest entity);
    }
}

