using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {

        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            lblFullName.Text = Resource1.FullName; // label1
            btnAdd.Text = Resource1.Add; // button1
            btnWriteToFile.Text = Resource1.WriteToFile;
            btnDelete.Text = Resource1.Delete;

            listBox1.DataSource = users; //a megoldásban a listUsers
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            User u = new User();
            u.FullName = textBox1.Text;
            users.Add(u);
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Application.StartupPath;
            sfd.Filter = "Vesszövel tagolt szöveg (*.csv) |*.csv";
            sfd.DefaultExt = "csv";
            sfd.AddExtension = true;


            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName, true, Encoding.UTF8)) // true hogy ne írja felül az eddigieket
                {
                    foreach (User u in users)
                    {
                        sw.WriteLine($"{u.ID};{u.FullName}");
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selectID = ((Guid)listBox1.SelectedValue);
            Console.WriteLine(selectID);

            var userSelect = (from u in users
                              where selectID == u.ID
                              select u).FirstOrDefault();

            users.Remove(userSelect);
        }
    }
}
