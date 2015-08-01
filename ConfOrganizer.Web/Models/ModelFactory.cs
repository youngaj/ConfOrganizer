using ConfOrganizer.Entities;
using ConfOrganizer.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConfOrganizer.Web.Models
{
    public class ModelFactory
    {
        public static AttendeeModel Create(Attendee obj)
        {
            if (obj == null)
                return null;

            var model = new AttendeeModel()
            {
                Id = obj.Id,
                Code  = obj.Code,
                EmailAddress = obj.EmailAddress,
                JobTitle = obj.JobTitle,
                Name =obj.Name
            };

            var proposals = new List<TalkProposalModel>();
            if (obj.TalkProposals != null)
            {
                foreach (var talkProposalReference in obj.TalkProposals)
                {
                    proposals.Add(Create(talkProposalReference));
                }
            }
            model.TalkProposals = proposals;

            return model;
        }

        private static TalkProposalModel Create(TalkProposal obj)
        {
            if (obj == null)
                return null;

            var model = new TalkProposalModel()
            {
                Id = obj.Id,
                AttendeeId = obj.AttendeeId,
                Abstract = obj.Abstract,
                Discipline = Create(obj.Discipline),
                Duration = obj.Duration,
                Title = obj.Title,
            };

            return model;
        }

        private static string Create(DisciplineCategory category)
        {
            return category.ToString();
        }
    }
}