using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaSample.Models
{
    public class EventRepository
    {
        private List<EventModel> _events;
        private int _nextId = 1;

        public EventRepository()
        {
            _events = new List<EventModel>();
            Add(new EventModel
            {
                Title = "To meet end-user!",
                Description = "Some details of requirements have to clarify!!!",
                StartDate = DateTime.Parse("11/10/2014 10:00:00"),
                EndDate = DateTime.Parse("11/10/2014 11:30:00"),
                Owner = "Alan Yu",
                Status = Status.Opening,
            });
            Add(new EventModel
            {
                Title = "Let's have Korean food together!",
                Description = "",
                StartDate = DateTime.Parse("11/11/2014 18:30:00"),
                EndDate = DateTime.Parse("11/11/2014 20:00:00"),
                Owner = "Leo Hotz",
                Status = Status.Opening,
            });
            Add(new EventModel
            {
                Title = "Ux designer",
                Description = "There are a lot need to do :-(!",
                StartDate = DateTime.Parse("11/13/2014 10:00:00"),
                EndDate = DateTime.Parse("11/13/2014 11:30:00"),
                Owner = "Alan Yu",
                Status = Status.Opening,
            });
            Add(new EventModel
            {
                Title = "Go to crazy party!",
                Description = "Go GO GO !",
                StartDate = DateTime.Parse("11/16/2014 10:00:00"),
                EndDate = DateTime.Parse("11/16/2014 11:30:00"),
                Owner = "Carol",
                Status = Status.Opening,
            });
        }

        public IList<EventModel> GetAll()
        {
            return _events;
        }

        public EventModel GetById(int id)
        {
            return _events.Find(e => e.Id == id);
        }

        public EventModel Add(EventModel item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            item.Id = _nextId++;
            _events.Add(item);
            return item;
        }

        public bool Update(EventModel item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            int index = _events.FindIndex(e => e.Id == item.Id);
            if (index == -1) return false;

            _events[index] = item;
            return true;
        }

        public void Remove(int id)
        {
            _events.RemoveAll(e => e.Id == id);
        }
    }
}