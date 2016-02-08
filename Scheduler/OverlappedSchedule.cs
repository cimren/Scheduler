﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scheduler
{
    class OverlappedSchedule : Schedule
    {

        public OverlappedSchedule(List<Lecture> lectureList) 
            : base(lectureList)
        {
            
        }
    }
}
