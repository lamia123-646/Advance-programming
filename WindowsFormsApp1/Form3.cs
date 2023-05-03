using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        Database1Entities db = new Database1Entities();

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            var i = db.Departments.ToArray();
            foreach (var i1 in i)
            {
                domainUpDown1.Items.Add(i1.Id);
            }

            var i2 = db.Departments.ToArray();
            foreach (var i3 in i2)
            {
                domainUpDown2.Items.Add(i3.Id);
            }

            dataGridView1.DataSource = db.Subjects.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Subject subject = new Subject
            {
                Name = textBox1.Text
                ,
                Term = Convert.ToInt32(textBox2.Text)
                ,
                Year = Convert.ToInt32(textBox3.Text)
                ,
                MinimumDegree = Convert.ToInt32(textBox4.Text)
                ,
                DepartmentId = Convert.ToInt32(domainUpDown1.Text)
            };
            var i = db.Departments.ToArray();
            foreach (var i1 in i)
            {
                if (Convert.ToInt32(domainUpDown1.Text) == i1.Id)
                {
                    db.Subjects.Add(subject);
                    db.SaveChanges();
                    MessageBox.Show("Added Complete");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox5.Text);
            Subject su = db.Subjects.SingleOrDefault(dep => dep.Id == id);
            if (su != null)
            {
                db.Subjects.Remove(su);
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
            int id = int.Parse(textBox6.Text);
            Subject su = db.Subjects.SingleOrDefault(dep => dep.Id == id);
            if (su != null)
            {
                su.Name = textBox7.Text;
                su.Term = Convert.ToInt32(textBox8.Text);
                su.Year = Convert.ToInt32(textBox9.Text);
                su.MinimumDegree = Convert.ToInt32(textBox10.Text);
                su.DepartmentId = Convert.ToInt32(domainUpDown2.Text);
                var i = db.Departments.ToArray();
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

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
