using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Scheduler
{
    public partial class Form1 : Form
    {
        public static Form1 instance = new Form1(); 

        List<Course> courses=new List<Course>();
        List<Course> selectedCourses = new List<Course>();

        ScheduleController sc = new ScheduleController();

        int selectedIndex;

        public static Form1 getInstance()
        {
            return instance;
        }

        private Form1()
        {
            InitializeComponent();

            Section s1 = new Section(1, Day.Monday, Hour.h_8_30);
            Section s2 = new Section(2, Day.Monday, Hour.h_11_30);
            Section s3 = new Section(3, Day.Tuesday, Hour.h_12_30);
            Section s4 = new Section(4, Day.Wednesday, Hour.h_13_30);
            Section s5 = new Section(2, Day.Thursday, Hour.h_10_30);
            Section s6 = new Section(1, Day.Friday, Hour.h_14_30);

            List<Section> sections1 = new List<Section>();
            List<Section> sections2 = new List<Section>();
            List<Section> sections3 = new List<Section>();

            sections1.Add(s1);
            sections1.Add(s2);
            sections1.Add(s3);
            sections1.Add(s4);

            sections2.Add(s1);
            sections2.Add(s5);

            sections3.Add(s6);
            sections3.Add(s2);
            sections3.Add(s3);

            Course c1 = new Course("Fizik", 4, sections1);
            Course c2 = new Course("Kimya", 2, sections2);
            Course c3 = new Course("Matematik", 3, sections3);

            CourseManager.getInstance().addCourse(c1);
            CourseManager.getInstance().addCourse(c2);
            CourseManager.getInstance().addCourse(c3);

        }

        public void Form1_Load(object sender, EventArgs e)
        {
            cbxCourses.Items.Clear();
            courses = CourseManager.getInstance().courseList;

            foreach (Course c in courses)
            {
                cbxCourses.Items.Add(c.name.ToString());
            }

            dataGridView1.Rows.Clear();
            insertRows();
        }

        void insertRows()
        {
            
            for (int i = 0; i < Hour.numOfHours; i++)
            {
                if (i != Hour.numOfHours - 1)
                    dataGridView1.Rows.Insert(i, "", "", "", "", "");

                dataGridView1.Rows[i].HeaderCell.Value = Hour.hours[i];
            }
            dataGridView1.RowHeadersWidth = 63;
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            Course selectedCourse = courses[selectedIndex];
            selectedCourses.Add(selectedCourse);
            lbxSelectedCourses.Items.Add(selectedCourse.name.ToString());
        }

        private void cbxCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCourses.SelectedIndex!=-1)
            {
                selectedIndex = cbxCourses.SelectedIndex;
            }
        }

        private void btnCreateSchedule_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            cbxSchedules.Items.Clear();

            List<Array> myList = new List<Array>();

            for (int i = 0; i < selectedCourses.Count; i++)
            {
                myList.Add(selectedCourses[i].sectionNumbers);
            }

            CombinationContext cmbContext = new CombinationContext();
            cmbContext.setCombinationStrategy(new StringCombination(myList));

            ArrayList combinations = cmbContext.getCombinations();
    
            List<Schedule> schedules = sc.createSchedules(selectedCourses, combinations);

            richTextBox1.Text+="\nCakisma olmayan programlar: \n ";
            foreach (Schedule sch in sc.nonOverlappedSchedules)
            {
                foreach (Lecture lec in sch.lectureList)
                {
                    richTextBox1.Text+=lec.section.sectionNumber.ToString() + " ";
                }
                richTextBox1.Text+="\n" ;
                
            }

            insertRows();

            lblSchedules.Text = sc.nonOverlappedSchedules.Count.ToString() + " schedules possible.";
            for (int i = 1; i <= sc.nonOverlappedSchedules.Count; i++)
            {
                cbxSchedules.Items.Add(i.ToString());
            }
        }

        private void btnAddNewCourse_Click(object sender, EventArgs e)
        {      
            Form2 form2 = new Form2();
            form2.Show();          
        }

        private void cbxSchedules_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            insertRows();

            int selectedIndex = cbxSchedules.SelectedIndex;
            foreach(Lecture lec in sc.nonOverlappedSchedules[selectedIndex].lectureList)
            {
                SectionIndex secIndex=lec.section.index;
                dataGridView1[secIndex.j, secIndex.i].Value = lec.course.name;
            }
            
        }
    }
}
