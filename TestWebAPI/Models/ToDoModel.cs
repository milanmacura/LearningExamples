using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebAPI.Models
{
    public class ToDoModel
    {
        public long Id { get; set; }
        public string Task { get; set; }
        public string Description { get; set; }

        public DateTime Date { get; set; }

        public DateTime Time { get; set; }

        public string Type { get; set; }
    }
}
