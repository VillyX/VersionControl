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

        // 6.1 feladat
        Excel.Application xlApp; // A Microsoft Excel alkalmazás
        Excel.Workbook xlWB; // A létrehozott munkafüzet
        Excel.Worksheet xlSheet; // Munkalap a munkafüzeten belül

        void LoadData() //4.3
        {
            Flats = re.Flat.ToList(); //4.4
        }

        void CreateExcel() //6.2
        {
            try
            {
                xlApp = new Excel.Application();
                xlWB = xlApp.Workbooks.Add(Missing.Value);
                xlSheet = xlWB.ActiveSheet;

                CreateTable(); //majd ez tölti fel adatokkal

                xlApp.Visible = true;
                xlApp.UserControl = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source + '\n' + ex.Message);
                xlWB.Close(false);
                xlApp.Quit();
                xlWB = null;
                xlApp = null;
            }
        }
        private void CreateTable()
        {
            

        }

        public Form1()
        {
            InitializeComponent();
            LoadData(); //4.3
        }
    }
}
