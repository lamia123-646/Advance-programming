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
    public partial class Form2 : Form
    {
        Database1Entities db = new Database1Entities();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
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

        }

        private void button3_Click(object sender, EventArgs e)
        {

            Form2 ex = new Form2
            {
                Date = dateTimePicker1.Value
                ,
                Term = Convert.ToInt32(textBox1.Text)
                ,
                SubjectId = Convert.ToInt32(domainUpDown1.Text)
            };
            var i = db.Subjects.ToArray();
            foreach (var i1 in i)
            {
                if (Convert.ToInt32(domainUpDown1.Text) == i1.Id)
                {
                    db.Exams.Add(ex);
                    db.SaveChanges();
                    MessageBox.Show("Added Complete");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox4.Text);
            Form2 ex = db.Exams.SingleOrDefault(dep => dep.Id == id);
            if (ex != null)
            {
                MessageBox.Show("Deteted Complete");
                db.Exams.Remove(ex);
                db.SaveChanges();
            }
            else
            {
                MessageBox.Show("Note Found");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox2.Text);
            Form2 ex = db.Exams.SingleOrDefault(dep => dep.Id == id);
            if (ex != null)
            {
                ex.Term = Convert.ToInt32(textBox3.Text);
                ex.Date = dateTimePicker2.Value;
                ex.SubjectId = Convert.ToInt32(domainUpDown2.Text);
                var i = db.Subjects.ToArray();
                foreach (var i1 in i)
                {
                    if (Convert.ToInt32(domainUpDown2.Text) == i1.Id)
                    {
                        MessageBox.Show("Updated Complete");
                        db.SaveChanges();
                    }
                }
            }
            else
            {
                MessageBox.Show("Not Found");
            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void domainUpDown2_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           dataGridView1.DataSource = db.Exams.ToList();

        }
    }
}
