using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Scheduler
{
    class ScheduleController
    {
        public List<Schedule> overlappedSchedules=new List<Schedule>();
        public List<Schedule> nonOverlappedSchedules=new List<Schedule>();

        public List<Schedule> createSchedules(List<Course> courses, ArrayList combinations)
        {
            List<Schedule> schedules = new List<Schedule>();
            overlappedSchedules.Clear();
            nonOverlappedSchedules.Clear();

            foreach (Combination cmb in combinations)
            {
                List<Lecture> lectureList = new List<Lecture>();
                for (int i = 0; i < cmb.combination.Length; i++)
                {
                    Lecture lec = new Lecture(courses[i], courses[i].sections[cmb.combination[i] - 1]);
                    lectureList.Add(lec);
                }

                foreach (int i in cmb.combination)
                {
                    Console.Write(i.ToString() + " ");
                }
                Console.WriteLine();

                ScheduleFactory schf = new ScheduleFactory();

                OverlapController oc=new OverlapController();
                bool overlap = oc.isOverlapped(lectureList);

                Schedule schedule = schf.createSchedule(overlap, lectureList);
                schedules.Add(schedule);

                if (schedule.GetType()==typeof(OverlappedSchedule))
                {
                    overlappedSchedules.Add(schedule);
                }

                else 
                {
                    nonOverlappedSchedules.Add(schedule);
                }

            }

            return schedules;
        }

    }
}
