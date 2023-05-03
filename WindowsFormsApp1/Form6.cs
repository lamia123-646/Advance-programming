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
    public partial class Form6 : Form
    {
        Database1Entities  db = new Database1Entities();

        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
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

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Student st = new Student
            {
                UserName = textBox1.Text
            ,
                Email = textBox2.Text,
                Phone = textBox3.Text
            ,
                RegisterDate = Convert.ToInt32(textBox4.Text)
            ,
                DepartmentId = Convert.ToInt32(domainUpDown1.Text)
            };
            var i = db.Departments.ToArray();
            foreach (var i1 in i)
            {
                if(Convert.ToInt32(domainUpDown1.Text) == i1.Id)
                {
                    db.Students.Add(st);
                    db.SaveChanges();
                    MessageBox.Show("Added Complete");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox6.Text);
            Student st = db.Students.SingleOrDefault(dep => dep.Id == id);
            if (st != null)
            {
                st.UserName = textBox7.Text;
                st.Email = textBox8.Text;
                st.Phone = textBox9.Text;
                st.RegisterDate = Convert.ToInt32(textBox10.Text);
                st.DepartmentId = Convert.ToInt32(domainUpDown2.Text);
                var item = db.Departments.ToArray();
                foreach (var item1 in item)
                {
                    if (Convert.ToInt32(domainUpDown2.Text) == item1.Id)
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

        private void button4_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox5.Text);
            Student st = db.Students.SingleOrDefault(dep => dep.Id == id);
            if (st != null)
            {
                db.Students.Remove(st);
                db.SaveChanges();
                MessageBox.Show("Deteted Complete");
            }
            else
            {
                MessageBox.Show("Note Found");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Students.ToList();
        }
    }
}