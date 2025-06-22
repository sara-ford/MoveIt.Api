using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveIt.Core.Models
{
    public class Classes
    {
        public int Id { get; set; }
        public string ClassName { get; set; }

        public Trainers TrainerID { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public int MaxCapacity { get; set; }

        public virtual ICollection<ClassRegistrations> ClassRegistrations { get; set; } = new List<ClassRegistrations>();

        public int CurrentRegistrations { get; set; }

    }
}
