using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeDoc.Models
{
    public class Scheduling
    {

        public int IdPacient { get; set; }
        public string NamePatient { get; set; }
        public int IdDoctor { get; set; }
        public string NameDoctor { get; set; }
        public string Adress { get; set; }
        public DateTime? StartDate { get; set; }
        public string DayOfWeek { get; set; }
        public bool Confirmed { get; set; }
    }

    public class SchedulingRequest
    {
        public int IdPacient { get; set; }
        public int IdDoctor { get; set; }
        public DateTime? StartDate { get; set; }
    }
}
