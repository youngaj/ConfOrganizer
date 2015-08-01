using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfOrganizer.Web.Models
{
    public class AttendeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Code { get; set; }
        public string JobTitle { get; set; }

        public List<TalkProposalModel> TalkProposals { get; set; }
    }
}
