using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SpaSample.Models;
using SpaSample.Filters;

namespace SpaSample.Controllers
{
    public class EventController : ApiController
    {
        private static readonly EventRepository _repository = new EventRepository();

        // GET: api/Event
        public IEnumerable<EventModel> Get()
        {
            return _repository.GetAll();
        }

        // GET: api/Event
        public IEnumerable<EventModel> Get(string category)
        {
            IEnumerable<EventModel> result = new List<EventModel>();

            switch (category)
            {
                case "opening":
                    result = _repository.GetAll().Where(e => e.Status == Status.Opening);
                    break;
                case "closed":
                    result = _repository.GetAll().Where(e => e.Status == Status.Closed);
                    break;
                default:
                    result = _repository.GetAll();
                    break;
            }
            return result.OrderBy(e=>e.Id);
        }

        // GET: api/Event/5
        public EventModel Get(int id)
        {
            EventModel item = _repository.GetById(id);
            if (item == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return item;
        }

        // POST: api/Event
        [ValidateModel]
        public HttpResponseMessage Post(EventModel item)
        {
            item.Status = Status.Opening;
            _repository.Add(item);

            var response = Request.CreateResponse<EventModel>(HttpStatusCode.Created, item);
            var url = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(url);
            return response;
        }

        /// <summary>
        /// Update event
        /// </summary>
        /// <param name="item">updated event</param>
        [ValidateModel]
        public void Put(EventModel item)
        {
             if (!_repository.Update(item))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        /// PUT: api/Event/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        [ValidateModel]
        public HttpResponseMessage Put(int id, EventModel item)
        {
            item.Id = id;
            _repository.Update(item);

            var response = Request.CreateResponse<EventModel>(HttpStatusCode.OK, item);
            var url = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(url);
            return response;
        }

        [Route("api/event/{id}/close")]
        public HttpResponseMessage Put(int id)
        {
            var item = _repository.GetById(id);
            if (item == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            item.Status = Status.Closed;
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        // DELETE: api/Event/5
        public HttpResponseMessage Delete(int id)
        {
            _repository.Remove(id);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}
