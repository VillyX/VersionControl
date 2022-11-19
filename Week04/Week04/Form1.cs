using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel; //5.2
using System.Reflection; //5.2

namespace Week04
{
    public partial class Form1 : Form
    {
        List<Flat> Flats; //4.1
        RealEstateEntities re = new RealEstateEntities(); //4.2
        
        void LoadData() //4.3
        {
            Flats = re.Flat.ToList(); //4.4
        }
        public Form1()
        {
            InitializeComponent();
            LoadData(); //4.3
        }
    }
}
