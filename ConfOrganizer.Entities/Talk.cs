using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfOrganizer.Entities
{
    public interface ITalk
    {
        int Id { get; set; }
        string Title { get; set; }
        string Abstract { get; set; }
        DisciplineCategory Discipline { get; set; }
        int Duration { get; set; }

        int SpeakerId { get; set; }
        Speaker Speaker { get; set; }
    }

    public class Talk: ITalk
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public DisciplineCategory Discipline { get; set; }
        public int Duration { get; set; }

        public int SpeakerId { get; set; }
        public virtual Speaker Speaker { get; set; }
    }
}
