using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveIt.Core.Models
{
    public class ClassRegistrations
    {
        public int Id { get; set; }

        public Members? MemberID { get; set; }
        public Classes? ClassId { get; set; }
        public DateOnly RegistrationDate { get; set; }
    }
}
