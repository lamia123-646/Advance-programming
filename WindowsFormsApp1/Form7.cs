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
    public partial class Form7 : Form
    {
        Database1Entities db = new Database1Entities();

        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Departments.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        { 
            Department de = new Department { Name = textBox1.Text };
            db.Departments.Add(de);
            db.SaveChanges();
            MessageBox.Show("Added Complete");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox2.Text);
            Department de = db.Departments.SingleOrDefault(dep => dep.Id == id);
            if(de != null)
            {
                db.Departments.Remove(de);
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
            Department de = db.Departments.SingleOrDefault(dep => dep.Id == id);
            if (de != null)
            {
                de.Name = textBox4.Text;
                db.SaveChanges();
                MessageBox.Show("Updated Complete");
            }
            else
            {
                MessageBox.Show("Note Found");
            }
        }
    }
}
