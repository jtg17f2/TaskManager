using SupportTicketApplication.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;


namespace APISerializationExample
{
    public class ProductJsonConverter : JsonCreationConverter<SupportTicket>
    {
        protected override SupportTicket Create(Type objectType, JObject jObject)
        {
            if (jObject == null) throw new ArgumentNullException("jObject");

            if (jObject["Deadline"] != null || jObject["deadline"] != null)
            {
                return new Task();
            }
            else if (jObject["Starttime"] != null || jObject["starttime"] != null)
            {
                return new Appointment();
            }
            else
            {
                return new Task();
            }
        }
    }
}
