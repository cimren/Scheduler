using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scheduler
{
    class Lecture
    {
        public Course course;
        public Section section;

        public Lecture(Course course, Section section)
        {
            this.course = course;
            this.section = section;

        }
    }
}
