using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scheduler
{
    class Course
    {
        public int numOfSections;
        public string name;
        public int[] sectionNumbers;
        public List<Section> sections;

        public Course(string name, int numOfSections, List<Section> sections)
        {
            this.name = name;
            this.numOfSections = numOfSections;
            this.sections = sections;

            sectionNumbers=new int[numOfSections];
            for (int i = 0; i < numOfSections; i++)
            {
                sectionNumbers[i] = i + 1;
            }
             
        }
    }
}
