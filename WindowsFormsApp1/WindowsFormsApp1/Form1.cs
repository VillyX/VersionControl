using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    { 
        List<Tick> ticks;
        PortfolioEntities context = new PortfolioEntities(); //4-es feladat


    
        public Form1()
        {
            InitializeComponent();
            ticks = context.Tick.ToList();
            dataGridView1.DataSource = ticks; //a ticks lista (5-ös feladat)
        }
    }
}
