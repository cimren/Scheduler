using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Scheduler
{
    class Schedule
    {
        public List<Lecture> lectureList;
        public Schedule(List<Lecture> lectureList)
        {
            this.lectureList = lectureList;
        }

    }
}
