using ConfOrganizer.Entities;
using ConfOrganizer.Services;
using ConfOrganizer.Web.Models;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.UnitOfWork;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace ConfOrganizer.Web
{
    public class AttendeesController : ApiController
    {
        private IAttendeeService _attendeeService;
        private IUnitOfWorkAsync _unitOfWork;

        public AttendeesController(IAttendeeService attendeeService, IUnitOfWorkAsync unitOfWork)
        {
            _attendeeService = attendeeService;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Attendees
        [HttpGet]
        [Route("api/Attendees")]
        public IQueryable<AttendeeModel> GetAll()
        {
            var results = _attendeeService.GetAll().ToList();
            var models = new List<AttendeeModel>();
            results.ForEach(x => models.Add(ModelFactory.Create(x)));
            return models.AsQueryable();
        }

        // GET: api/Attendees/5
        [HttpGet]
        [Route("api/Attendees/{id:int}")]
        [ResponseType(typeof(AttendeeModel))]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var attendee = await _attendeeService.FindAsync(id);
            if (attendee == null)
            {
                return NotFound();
            }
            var model = ModelFactory.Create(attendee);
            return Ok(model);
        }

        // PUT: api/Attendees/5
        [ResponseType(typeof(void))]
        [HttpPost, HttpPatch]
        [Route("api/Attendees/{id:int}")]
        public async Task<IHttpActionResult> PutAttendees(int id, AttendeeModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.Id)
            {
                return BadRequest();
            }

            try
            {
                var attendee = _attendeeService.Find(id);
                attendee = ObjectFactory.Parse(model, attendee);
                attendee.ObjectState = ObjectState.Modified;
                _attendeeService.Update(attendee);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttendeesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Attendees
        [HttpPost]
        [Route("api/Attendees")]
        [ResponseType(typeof(AttendeeModel))]
        public async Task<IHttpActionResult> PostAttendees(AttendeeModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var attendee = new Attendee();
            attendee = ObjectFactory.Parse(model, attendee);
            attendee.ObjectState = ObjectState.Added;
            _attendeeService.Insert(attendee);
            await _unitOfWork.SaveChangesAsync();

            model = ModelFactory.Create(attendee);
            return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
        }

        // DELETE: api/Attendees/5
        [HttpDelete]
        [Route("api/Attendees/{id:int}")]
        [ResponseType(typeof(AttendeeModel))]
        public async Task<IHttpActionResult> DeleteAttendees(int id)
        {
            Attendee attendee = await _attendeeService.FindAsync(id);
            if (attendee == null)
            {
                return NotFound();
            }

            _attendeeService.Remove(id);
            await _unitOfWork.SaveChangesAsync();
            var model = ModelFactory.Create(attendee);
            return Ok(model);
        }

        private bool AttendeesExists(int id)
        {
            return _attendeeService.GetById(id) != null;
            //return db.AttendeesSet.Count(e => e.Id == id) > 0;
        }
    }
}