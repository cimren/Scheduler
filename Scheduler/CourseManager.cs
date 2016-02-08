using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scheduler
{
    class CourseManager
    {
        private static CourseManager instance=new CourseManager();

        public List<Course> courseList=new List<Course>();

        private CourseManager()
        {
           
        }

        public static CourseManager getInstance()
        {
            return instance;
        }

        public void addCourse(Course course)
        {
            courseList.Add(course);
        }

        public void removeCourse(Course course)
        {
            courseList.Remove(course);
        }
        

    }
}
