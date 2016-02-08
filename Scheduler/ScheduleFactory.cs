using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scheduler
{
    class ScheduleFactory
    {
        public Schedule createSchedule(bool overlap, List<Lecture> lectureList)
        {
            if (overlap == true)
                return new OverlappedSchedule(lectureList);
            else
                return new NonOverlappedSchedule(lectureList);
        }
    }
}
