using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scheduler
{
    class OverlapController
    {

        public List<SectionIndex> findOverlapIndices(List<Lecture> lectureList)
        {
             int[,] counters = new int[Hour.numOfHours, Day.numOfDays];
             List<SectionIndex> overlapIndices = new List<SectionIndex>();

             foreach (Lecture lec in lectureList)
             {
                 counters[lec.section.index.i, lec.section.index.j]++;

                 if (counters[lec.section.index.i, lec.section.index.j] > 1)
                 {
                     if (!overlapIndices.Contains(lec.section.index))
                     {
                         overlapIndices.Add(lec.section.index);
                     }
                 }

             }

             return overlapIndices;
        }


        /*
        public List<Lecture>[,] findOverlappedLectures(List<Lecture> lectureList)
        {
             List<Lecture>[,] lectures = new List<Lecture>[10, 5];
             foreach (Lecture lec in lectureList)
             {             
                 lectures[lec.section.index.i, lec.section.index.j].Add(lec);

                 if (lectures[lec.section.index.i, lec.section.index.j].Count > 1)
                 {
                     return lectures;
                 }

             }
        }
        */

        public bool isOverlapped(List<Lecture> lectureList)
        {
            int[,] counters = new int[Hour.numOfHours, Day.numOfDays];
            foreach (Lecture lec in lectureList)
            {
                counters[lec.section.index.i, lec.section.index.j]++;

                if (counters[lec.section.index.i, lec.section.index.j] > 1)
                {
                    return true; //overlap

                }
            }

            return false;
        }
    }
}
