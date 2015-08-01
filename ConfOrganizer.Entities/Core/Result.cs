using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfOrganizer.Entities
{
    public interface IResult
    {
        //int ReturnVal { get; set; }
        ResultType Type { get; set; }
        string Message { get; set; }
        bool IsSuccessful { get; }
        Object Obj { get; set; }
        void AddMessage(string msg);
        void ClearMessages();
    }

    public class Result : IResult
    {

        private ICollection<String> messages;
        /// <summary>
        /// Gets or set result message
        /// </summary>
        public string Message
        {
            get
            {
                StringBuilder msgOut = new StringBuilder();
                foreach (var msg in messages)
                {
                    msgOut.Append(msg);
                }
                return msgOut.ToString();
            }
            set
            {
                ClearMessages();
                AddMessage(value);
            }
        }

        public ResultType Type { get; set; }

        public Object Obj { get; set; }

        public bool IsSuccessful
        {
            get
            {
                bool result;
                if (Type == ResultType.Successful)
                    result = true;
                else
                    result = false;
                return result;
            }
        }

        public Result()
        {
            messages = new List<String>();
        }

        /// <summary>
        /// Adds a message to the result message queue.
        /// </summary>
        /// <param name="msg"></param>
        public void AddMessage(string msg)
        {
            messages.Add(msg);
        }

        public void ClearMessages()
        {
            messages.Clear();
        }
    }


    public interface IResultFactory
    {
        IResult CreateInstance();
    }
}
