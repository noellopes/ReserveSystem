namespace ReserveSystem.Models
    {
        public class EventsViewModel
        {
            public IEnumerable<Events> Events { get; set; }
            public PagingInfo PagingInfo { get; set; }

            public string SearchName { get; set; }
        }
    }
