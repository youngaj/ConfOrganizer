using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConfOrganizer.Web.Models
{
    public class SpeakerModel: AttendeeModel
    {
        public List<TalkModel> Talks { get; set; }
    }
}