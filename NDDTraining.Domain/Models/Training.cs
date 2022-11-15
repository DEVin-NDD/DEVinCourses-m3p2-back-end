using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NDDTraining.Domain.Models
{
    public class Training
    {
        public int Id { get; internal set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Teacher { get; set; }
        public TimeSpan Duration { get; set; }
        public bool Active { get; set; }
        public string Category { get; set; }
        public virtual List<Module> Modules { get; set; }

        public Training()
        {
        }
    }
}