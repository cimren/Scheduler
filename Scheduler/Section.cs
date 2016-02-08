using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scheduler
{
    class Section
    {
        string day;
        string time;

        public int sectionNumber;
        public SectionIndex index;

        public Section(int sectionNumber, string day, string time)
        {
            this.sectionNumber = sectionNumber;
            this.day = day;
            this.time = time;

            index = findSectionIndex(day, time);
        }

        
        private SectionIndex findSectionIndex(string day, string time)
        {
            string[] days = Day.days;
            string[] hours = Hour.hours;

            int i=0, j=0;

            for (int a = 0; a < hours.Length; a++)
            {
                if(hours[a]==time)
                    i=a;
            }

            for (int b = 0; b < days.Length; b++)
            {
                if (days[b] == day)
                    j = b;
            }

            return new SectionIndex(i, j);
        }
        
    }
}
