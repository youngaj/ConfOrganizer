using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConfOrganizer.Entities
{
    public interface ISpeaker
    {
        List<Talk> Talks { get; set; }
    }
    public class Speaker: Attendee, ISpeaker
    {
        public virtual List<Talk> Talks { get; set; }
    }
}