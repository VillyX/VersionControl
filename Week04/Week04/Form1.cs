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
        List<Flat> flats; //4.1
        RealEstateEntities re = new RealEstateEntities(); //4.2

        // 6.1 feladat
        Excel.Application xlApp; // A Microsoft Excel alkalmazás
        Excel.Workbook xlWB; // A létrehozott munkafüzet
        Excel.Worksheet xlSheet; // Munkalap a munkafüzeten belül

        void LoadData() //4.3
        {
            flats = re.Flat.ToList(); //4.4
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
        private void CreateTable() //7.1
        {
            string[] headers = new string[] { //7.2
             "Kód",
             "Eladó",
             "Oldal",
             "Kerület",
             "Lift",
             "Szobák száma",
             "Alapterület (m2)",
             "Ár (mFt)",
             "Négyzetméter ár (Ft/m2)"};

            object[,] values = new object[flats.Count, headers.Length]; //7.4
            int counter = 0;

            for (int i = 0; i < headers.Length; i++) //7.3
            {
                xlSheet.Cells[1, i + 1] = headers[i]; //[sor, oszlop] az excelben
            }

            foreach (var f in flats) //7.5
            {
                values[counter, 0] = f.Code;
                values[counter, 1] = f.Vendor;
                values[counter, 2] = f.Side;
                values[counter, 3] = f.District;
                values[counter, 4] = f.Elevator;
                values[counter, 5] = f.NumberOfRooms;
                values[counter, 6] = f.FloorArea;
                values[counter, 7] = f.Price;
                values[counter, 8] = "";
                counter++;
            }

        }

        public Form1()
        {
            InitializeComponent();
            LoadData(); //4.3
            CreateExcel();
        }
    }
}
