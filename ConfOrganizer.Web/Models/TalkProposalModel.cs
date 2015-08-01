using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfOrganizer.Web.Models
{
    public class TalkProposalModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Discipline { get; set; }
        public int Duration { get; set; }

        public int AttendeeId { get; set; }
    }
}
