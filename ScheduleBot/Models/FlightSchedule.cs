using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.FormFlow;

namespace ScheduleBot.Models
{
    [Serializable]
    public class FlightSchedule
    {
        public DateTime DepartureDate { get; set; }
        public string FlightNumber { get; set; }
        public string Airport { get; set; }
        public string FlightType { get; set; }

    }
}