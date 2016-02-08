using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class Form2 : Form
    {
        int selectedSection;
        string selectedDay, selectedHour;
        int numOfSections;
        List<Section> sections = new List<Section>();

        public Form2()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            cbxSections.Items.Clear();
            numOfSections = Convert.ToInt32(txtNumOfSections.Text);

            for (int i = 1; i <= numOfSections; i++)
            {
                cbxSections.Items.Add(i.ToString());
            }
        }

        private void btnAddSection_Click(object sender, EventArgs e)
        {
            Section sec = new Section(selectedSection, selectedDay, selectedHour);
            sections.Add(sec);
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            Course c = new Course(txtCourseName.Text, numOfSections, sections);
            CourseManager.getInstance().addCourse(c);

            this.Close();
            Form1 form1 = Form1.getInstance();
            form1.Form1_Load(sender, e);
        }

        private void cbxSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSections.SelectedItem!=null)
                selectedSection = Convert.ToInt32(cbxSections.SelectedItem);
        }

        private void cbxDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxDays.SelectedItem!=null)
                selectedDay = cbxDays.SelectedItem.ToString();
        }

        private void cbxHours_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxHours.SelectedItem != null)
                selectedHour = cbxHours.SelectedItem.ToString();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

    }
}
