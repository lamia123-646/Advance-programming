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
    public partial class Form4 : Form
    {
        Database1Entities db = new Database1Entities();
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            var i = db.Subjects.ToArray();
            foreach (var i1 in i)
            {
                domainUpDown1.Items.Add(i1.Id);
            }

            var i2 = db.Subjects.ToArray();
            foreach (var i3 in i2)
            {
                domainUpDown2.Items.Add(i3.Id);
            }

            dataGridView1.DataSource = db.SubjectLectures.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SubjectLecture sub = new SubjectLecture
            {
                Title = textBox1.Text
            ,

                Content = textBox2.Text
            ,
                SubjectId = Convert.ToInt32(domainUpDown1.Text
            )};
            var i = db.Subjects.ToArray();
            foreach (var i1 in i)
            {
                if (Convert.ToInt32(domainUpDown1.Text) == i1.Id)
                {
                    db.SubjectLectures.Add(sub);
                    db.SaveChanges();
                    MessageBox.Show("Added Complete");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox6.Text);
            SubjectLecture sub = db.SubjectLectures.SingleOrDefault(dep => dep.Id == id);
            if (sub != null)
            {
                db.SubjectLectures.Remove(sub);
                db.SaveChanges();
                MessageBox.Show("Deteted Complete");
            }
            else
            {
                MessageBox.Show("Note Found");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
             int id = int.Parse(textBox3.Text);
            SubjectLecture sub = db.SubjectLectures.SingleOrDefault(dep => dep.Id == id);
            if (sub != null)
            {
                sub.Title = textBox4.Text;
                sub.Content = textBox5.Text;
                sub.SubjectId = Convert.ToInt32(domainUpDown2.Text);
                var i = db.Students.ToArray();
                foreach (var i1 in i)
                {
                    if (Convert.ToInt32(domainUpDown2.Text) == i1.Id)
                    {
                        db.SaveChanges();
                        MessageBox.Show("Updated Complete");
                    }
                }
            }
            else
            {
                MessageBox.Show("Note Found");
            }
        }
    }
}
