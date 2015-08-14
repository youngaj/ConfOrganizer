using Repository.Pattern.Ef6;
using System.Collections.Generic;

namespace ConfOrganizer.Entities
{
    public interface IAttendee
    {
        int Id { get; set; }

        string Name { get; set; }

        string EmailAddress { get; set; }

        string Code { get; set; }

        string JobTitle { get; set; }

        List<TalkProposal> TalkProposals { get; set; }
    }

    public class Attendee : Entity, IAttendee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string EmailAddress { get; set; }

        public string Code { get; set; }

        public string JobTitle { get; set; }

        public virtual List<TalkProposal> TalkProposals { get; set; }
    }
}