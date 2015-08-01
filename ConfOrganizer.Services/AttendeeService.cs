using Repository.Pattern.Repositories;
using Service.Pattern;
using ConfOrganizer.Entities;
using System;
using System.Linq;

namespace ConfOrganizer.Services
{
    public interface IAttendeeService : IService<Attendee>
    {
        IQueryable<Attendee> GetAll();
        Attendee GetById(int id);
        void Remove(int id);
    }

    public class AttendeeService : Service<Attendee>, IAttendeeService
    {
        private readonly IRepositoryAsync<Attendee> _repo;

        public AttendeeService(IRepositoryAsync<Attendee> repo)
            : base(repo)
        {
            _repo = repo;
        }

        private IQueryable<Attendee> BaseQuery()
        {
            return _repo.Query()
                        .Select();
        }

        public IQueryable<Attendee> GetAll()
        {
            return BaseQuery();
        }

        public Attendee GetById(int id)
        {
            return BaseQuery().FirstOrDefault(x => x.Id == id);
        }

        public override void Insert(Attendee entity)
        {
            var result = Validate(entity);
            if (result.IsSuccessful)
                base.Insert(entity);
            else
                throw new ArgumentException(result.Message);
        }

        private IResult Validate(Attendee entity)
        {
            var result = ResultFactory.CreateInstance();
            result.Type = ResultType.Successful;

            if (BaseQuery().Any( x => x.EmailAddress == entity.EmailAddress))
            {
                result.AddMessage("Duplicate Email Address");
                result.Type = ResultType.Failure;
            }
            return result;
        }


        public void Remove(int id)
        {
            base.Delete(id);
        }
    }
}
