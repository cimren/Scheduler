using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scheduler
{
    class NonOverlappedSchedule : Schedule
    {

        public NonOverlappedSchedule(List<Lecture> lectureList)
            : base(lectureList)
        {
          
        }
    }
}
