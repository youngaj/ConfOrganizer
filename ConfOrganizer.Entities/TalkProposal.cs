using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfOrganizer.Entities
{
    public interface ITalkProposal
    {
        int Id { get; set; }
        string Title { get; set; }
        string Abstract { get; set; }
        DisciplineCategory Discipline { get; set; }
        int Duration { get; set; }

        int AttendeeId { get; set; }
        Attendee Attendee { get; set; }
    }

    public class TalkProposal: ITalkProposal
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public DisciplineCategory Discipline { get; set; }
        public int Duration { get; set; }

        public int AttendeeId { get; set; }
        public virtual Attendee Attendee { get; set; }
    }

    public enum DisciplineCategory
    {
        Developer = 1,
        Designer = 2,
        IT_Pro = 3,
    }
}
