using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Entities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    { 
        List<Tick> ticks;
        PortfolioEntities context = new PortfolioEntities(); //4-es feladat
        List<PortfolioItem> portfolio = new List<PortfolioItem>();
    
        public Form1()
        {
            InitializeComponent();
            ticks = context.Tick.ToList();
            dataGridView1.DataSource = ticks; //a ticks lista (5-ös feladat)

            CreatePortfolio(); //nem fgv, hanem eljárás a visszaadott érték hiánya miatt (5-ös feladat még mindig)
        }

        private void CreatePortfolio()
        {
            portfolio.Add(new PortfolioItem() { Index = "OTP", Volume = 10 });
            portfolio.Add(new PortfolioItem() { Index = "ZWACK", Volume = 10 });
            portfolio.Add(new PortfolioItem() { Index = "ELMU", Volume = 10 });

            dataGridView2.DataSource = portfolio;
        }
    }
}
