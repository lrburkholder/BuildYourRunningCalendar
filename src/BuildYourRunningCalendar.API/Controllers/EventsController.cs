using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Ical.Net;
using Ical.Net.DataTypes;
using Ical.Net.Interfaces.DataTypes;
using Ical.Net.Serialization.iCalendar.Serializers;
using Ical.Net.Serialization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BuildYourRunningCalendar.API.Controllers
{
    [Route("api/[controller]")]
    public class EventsController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var now = DateTime.Now;
            var later = now.AddHours(1);

            //Repeat daily for 5 days
            var rrule = new RecurrencePattern(FrequencyType.Daily, 1) { Count = 5 };

            var e = new Event
            {
                DtStart = new CalDateTime(now),
                DtEnd = new CalDateTime(later),
                RecurrenceRules = new List<IRecurrencePattern> { rrule },                
            };

            var calendar = new Calendar();
            calendar.Events.Add(e);

            var serializer = new CalendarSerializer(new SerializationContext());
            var serializedCalendar = serializer.SerializeToString(calendar);
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
