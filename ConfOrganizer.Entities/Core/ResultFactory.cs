using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfOrganizer.Entities
{
    public class ResultFactory
    {
        public static IResult CreateInstance()
        {
            return new Result();
        }
    }
}
