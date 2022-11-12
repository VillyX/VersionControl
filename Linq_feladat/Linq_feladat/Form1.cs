﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Linq_feladat
{
    public partial class Form1 : Form
    {
        List<Country> countries = new List<Country>();
        public Form1()
        {
            InitializeComponent();
            LoadData("ramen.csv");
        }

        void LoadData(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            sr.ReadLine(); //átugrik az első soron, mert az a fejléc
            while (!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split(';');
                string orszag = sor[2];
                
                //var ered = countries.Where(i => i.Name.Equals(orszag)).FirstOrDefault(); //LINQ lekérdezés a köv sor ugyanez másképpen felírva:
                var ered = (from c in countries where c.Name.Equals(orszag) select c).FirstOrDefault();

                if (ered == null) //ha nincs ilyen ország a listában
                {
                    ered = new Country
                    {
                        ID = countries.Count,
                        Name = orszag
                    };
                    countries.Add(ered);
                }
            }
            sr.Close();
        }

    }
}
