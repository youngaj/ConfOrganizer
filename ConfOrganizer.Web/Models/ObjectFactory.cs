using ConfOrganizer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConfOrganizer.Web.Models
{
    public class ObjectFactory
    {
        internal static Entities.Attendee Parse(AttendeeModel model, Attendee obj)
        {
            if (model == null)
            {
                return null;
            }

            if (obj != null)
            {
                obj.Name = model.Name;
                obj.JobTitle = model.JobTitle;
                obj.Code = model.Code;
                obj.EmailAddress = model.EmailAddress;

            }

            return obj;
        }
    }
}