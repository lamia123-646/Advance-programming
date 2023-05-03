using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        Database1Entities db = new Database1Entities();
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            var i = db.Students.ToArray();
            foreach (var i1 in i)
            {
                domainUpDown1.Items.Add(i1.Id);
            }

            var i2 = db.Students.ToArray();
            foreach (var i3 in i2)
            {
                domainUpDown4.Items.Add(i3.Id);
            }

            var i4 = db.Exams.ToArray();
            foreach (var i5 in i4)
            {
                domainUpDown2.Items.Add(i5.Id);
            }

            var i6 = db.Exams.ToArray();
            foreach (var i7 in i6)
            {
                domainUpDown3.Items.Add(i7.Id);
            }

            dataGridView1.DataSource = db.StudentMarks.ToArray();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StudentMark st = new StudentMark
            {
                Mark = Convert.ToInt32(textBox2.Text)
            ,
                StudentId = Convert.ToInt32(domainUpDown1.Text)
            ,
                ExamId = Convert.ToInt32(domainUpDown3.Text)
            };
            var i = db.Students.ToArray();
            foreach (var i1 in i)
            {
                if (Convert.ToInt32(domainUpDown1.Text) == i1.Id)
                {
                    var i2 = db.Students.ToArray();
                    foreach (var i3 in i2)
                    {
                        if (Convert.ToInt32(domainUpDown3.Text) == i3.Id)
                        {
                            db.StudentMarks.Add(st);
                            db.SaveChanges();
                            MessageBox.Show("Added Complete");
                        }
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox3.Text);
            StudentMark st = db.StudentMarks.SingleOrDefault(dep => dep.Id == id);
            if (st != null)
            {
                st.StudentId = Convert.ToInt32(domainUpDown4.Text);
                st.Mark = Convert.ToInt32(textBox1.Text);
                st.ExamId = Convert.ToInt32(domainUpDown2.Text);
                var i = db.Students.ToArray();
                foreach (var i1 in i)
                {
                    if (Convert.ToInt32(domainUpDown1.Text) == i1.Id)
                    {
                        var i2 = db.Students.ToArray();
                        foreach (var item3 in i2)
                        {
                            if (Convert.ToInt32(domainUpDown3.Text) == item3.Id)
                            {
                                db.SaveChanges();
                                MessageBox.Show("Updated Complete");
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Note Found");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox5.Text);
            StudentMark st = db.StudentMarks.SingleOrDefault(dep => dep.Id == id);
            if (st != null)
            {
                db.StudentMarks.Remove(st);
                db.SaveChanges();
                MessageBox.Show("Deteted Complete");
            }
            else
            {
                MessageBox.Show("Note Found");
            }
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void domainUpDown3_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void domainUpDown2_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void domainUpDown4_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
